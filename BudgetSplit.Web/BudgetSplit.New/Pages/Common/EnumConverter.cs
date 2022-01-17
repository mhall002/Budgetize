using MudBlazor;

namespace BudgetSplit.New.Pages.Common
{
    public class EnumConverter<T> : Converter<T> where T : struct
    {
        public EnumConverter()
        {
            GetFunc = (text) => Enum.Parse<T>(text);
            SetFunc = (item) => Enum.GetName(typeof(T), item);
        }
    }
}
