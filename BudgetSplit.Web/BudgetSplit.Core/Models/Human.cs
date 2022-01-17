using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSplit.Core.Models
{
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Transaction>? Transactions { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
