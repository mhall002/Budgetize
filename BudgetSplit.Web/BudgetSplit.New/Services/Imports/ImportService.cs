using BudgetSplit.Core.Imports;
using BudgetSplit.Core.Models;
using BudgetSplit.New.Data;
using BudgetSplit.New.Services.Imports;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BudgetSplit.New.Services
{
    public class ImportService
    {
        private ApplicationDbContext _context;

        public ImportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetOrCreateCategory(string name)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            if (category == null)
            {
                category = new Category();
                category.Name = name;
            }
            return category;
        }

        public async Task<Payee> GetOrCreatePayee(string name)
        {
            var item = _context.Payees.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            if (item == null)
            {
                item = new Payee();
                item.Name = name;
            }
            return item;
        }

        public async Task<Transaction> GetTransactionFromImportLine(TransactionImportLine imported, Account account)
        {
            Transaction transaction = new Transaction();
            transaction.Name = imported.Name;
            transaction.Amount = imported.Amount;
            transaction.TransactionDate = imported.TransactionDate;
            transaction.Memo = imported.Memo;
            if (imported.SuggestedCategory != null)
            {
                transaction.Category = await GetOrCreateCategory(imported.SuggestedCategory);
            }

            var targetPayeeName = imported.Name;
            if (imported.SuggestedPayee != null)
            {
                
                targetPayeeName = imported.SuggestedPayee;
                Regex.Replace(targetPayeeName, "(#\\d\\d*)", "");
                targetPayeeName = targetPayeeName.Replace("  ", " ");
            }

            transaction.Payee = await GetOrCreatePayee(targetPayeeName);

            transaction.Account = account;

            return transaction;
        }

        public async Task<List<Transaction>> Import(Stream stream, Account account, ImportDefinition import)
        {
            var data = await import.GetTransactions(stream, account);

            var recordsToAdd = new List<Transaction>();
            foreach (var record in data)
            {
                var exists = _context.Transactions.FirstOrDefault(t => t.AccountId == account.Id && t.ImportKey == record.ImportKey);
                if (exists == null)
                {
                    var tran = await GetTransactionFromImportLine(record, account);
                    recordsToAdd.Add(tran);
                }
            }

            if (recordsToAdd.Count > 0)
            {
                await _context.Transactions.AddRangeAsync(recordsToAdd);
            }

            await _context.SaveChangesAsync();

            return recordsToAdd;
        }
    }
}
