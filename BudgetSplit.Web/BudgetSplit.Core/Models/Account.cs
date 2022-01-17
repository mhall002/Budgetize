using BudgetSplit.New.Services.Imports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSplit.Core.Models
{
    public enum RegisteredType
    {
        Unregistered,
        TFSA,
        RRSP
    }

    public enum AccountType
    {
        CreditCard,
        Chequing,
        Savings,
        Brokerage,
        GIC
    }

    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public int OwnerId { get; set; }
        public Human? Owner { get; set; }

        public AccountType AccountType { get; set; }
        public RegisteredType RegisteredType { get; set; }
        public string? ImportDefinitionId { get; set; }

        [NotMapped]
        public ImportDefinition? ImportDefinition
        {
            get => ImportDefinitionId == null ? null : ImportTypes.GetDefinition(ImportDefinitionId);
            set => ImportDefinitionId = value == null ? null : value.Id;
        }

        public List<Transaction>? Transactions { get; set; }
    }
}
