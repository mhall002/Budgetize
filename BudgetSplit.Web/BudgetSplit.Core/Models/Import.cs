using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSplit.Core.Models
{
    public class Import
    {
        public int Id { get; set; }
        public DateTime ImportDate { get; set; }
        public int PayeeId { get; set; }
        public virtual Human Human { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

        protected Import()
        {

        }

        public Import(Human human)
        {
            Human = human;
            Transactions = new List<Transaction>();
            ImportDate = DateTime.Now;
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void AddTransaction(DateTime transactionDate, decimal amount)
        {
            Transaction transaction = new Transaction();
            transaction.Imported = ImportDate;
            transaction.Amount = amount;
            transaction.TransactionDate = transactionDate;
            transaction.Human = Human;
            AddTransaction(transaction);
        }
    }
}
