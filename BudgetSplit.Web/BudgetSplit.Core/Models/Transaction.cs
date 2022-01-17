using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSplit.Core.Models
{
    public class Transaction
    {


        public int Id { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Today;
        public DateTime Imported { get; set; } = DateTime.Today;
        public string Name { get; set; } = "";
        public string Memo { get; set; } = "";
        public decimal Amount { get; set; }
        public string Reference { get; set; } = "";

        public int? ImportId { get; set; }
        public virtual Import? Import {get;set;}

        public int? HumanId { get; set; }
        public virtual Human? Human { get; set; }

        public int? PayeeId { get; set; }
        public virtual Payee? Payee { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public int? AccountId { get; set; }
        public virtual Account? Account { get; set; }

        public string? ImportKey { get; set; }
    }
}
