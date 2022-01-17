namespace BudgetSplit.New.Pages.Common
{
    public static class DisplayExtensions
    {
        public static string GetName<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return Enum.GetName(typeof(TEnum), value);
        }
    }
}
