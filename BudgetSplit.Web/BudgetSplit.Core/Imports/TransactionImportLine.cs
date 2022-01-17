using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSplit.Core.Imports
{
    public class TransactionImportLine
    {
        public DateTime TransactionDate { get; set; } = DateTime.Today;
        public DateTime Imported { get; set; } = DateTime.Today;
        public string Name { get; set; } = "";
        public string Memo { get; set; } = "";
        public decimal Amount { get; set; }
        public string Reference { get; set; } = "";

        public string? SuggestedPayee { get; set; } = "";
        public string? SuggestedCategory { get; set; } = "";

        public string? ImportKey { get; set; }
    }
}
