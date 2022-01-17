using BudgetSplit.Core.Imports;

namespace BudgetSplit.New.Services.Imports
{
    public static class ImportTypes
    {
        public static List<ImportDefinition> All { get; }

        static ImportTypes()
        {
            All = new List<ImportDefinition>();
            All.Add(new TangerineCreditCard());
            All.Add(new TangerineChequing());
        }

        public static ImportDefinition GetDefinition(string id)
        {
            return All.First(x => x.Id == id);
        }
    }
}
