using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BudgetSplit.New.Pages.Common
{
    public partial class EnumSelectorComponent<T> where T : struct, Enum
    {
        class SelectItem
        {
            public string Name { get; set; }
            public T Value { get; set; }
        };

        private List<SelectItem> Items { get; set; } = new List<SelectItem>();
        private T _value;
        [Parameter]
        public T Value
        {
            get => _value; set
            {
                if (_value.Equals(value) == true)
                    return;
                _value = value;
                ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            foreach (var val in Enum.GetValues<T>())
            {
                string name = Enum.GetName<T>(val);
                Items.Add(new SelectItem()
                {
                    Name = name,
                    Value = val
                });
            }
        }
    }
}
