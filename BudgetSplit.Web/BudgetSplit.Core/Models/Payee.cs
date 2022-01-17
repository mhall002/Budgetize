using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSplit.Core.Models
{
    public class Payee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Transaction>? Transactions { get; set; }

        public Payee(string name)
        {
            Name = name;
        }

        public Payee()
        {

        }
    }
}
