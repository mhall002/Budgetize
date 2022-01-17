using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSplit.Core.Models
{
    public class ImportedTransaction
    {
        public int? Id { get; set; }

        public int? TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
