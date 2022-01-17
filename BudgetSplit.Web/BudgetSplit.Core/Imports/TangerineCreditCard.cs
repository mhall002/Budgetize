using BudgetSplit.Core.Imports;
using BudgetSplit.Core.Models;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BudgetSplit.New.Services.Imports
{
    public class TangerineCreditCard : ImportDefinition
    {
        public override string Name => "Tangerine Credit";

        private class TangerineImportLine
        {
            //[Name("Date")]
            [Name("Transaction date")]
            public DateTime TransactionDate { get; set; }
            public string Name { get; set; }
            public string Memo { get; set; }
            public decimal Amount { get; set; }
            public string Key => "Tangerine" + TransactionDate.ToString() + Name + Memo + Amount;
        }

        public override async Task<List<TransactionImportLine>> GetTransactions(Stream stream, Account account)
        {
            using (var memStream = new MemoryStream())
            {
                await stream.CopyToAsync(memStream);
                memStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<TangerineImportLine>().ToList();

                    var recordsToAdd = new List<TransactionImportLine>();

                    foreach (var record in records)
                    {
                        TransactionImportLine transaction = new TransactionImportLine();
                        transaction.TransactionDate = record.TransactionDate;
                        transaction.Name = record.Name;
                        transaction.Memo = record.Memo;
                        transaction.Amount = record.Amount;
                        transaction.ImportKey = record.Key;

                        string targetPayeeName = transaction.Name;
                        Regex.Replace(targetPayeeName, "(#\\d\\d*)", "");
                        targetPayeeName = targetPayeeName.Replace("  ", " ");
                        transaction.SuggestedPayee = targetPayeeName;

                        if (transaction.Memo.Contains("Category"))
                        {
                            string cat = transaction.Memo.Substring(transaction.Memo.IndexOf("Category") + "Category:".Length).Trim();
                            if (cat.ToLower() != "other")
                            { 
                                transaction.SuggestedCategory = cat;
                            }
                        }
                        //transaction.Human = account.Owner;
                        //transaction.Account = account;

                        recordsToAdd.Add(transaction);
                    }
                    return recordsToAdd;
                }
            }
        }
    }
}
