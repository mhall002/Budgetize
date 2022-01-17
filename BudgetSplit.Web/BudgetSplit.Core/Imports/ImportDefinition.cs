using BudgetSplit.Core.Imports;
using BudgetSplit.Core.Models;

namespace BudgetSplit.New.Services.Imports
{
    public abstract class ImportDefinition
    {
        public abstract string Name { get; }
        public virtual string Id => this.GetType().Name;
        public abstract Task<List<TransactionImportLine>> GetTransactions(Stream stream, Account account);
    }
}
