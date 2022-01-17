using BudgetSplit.New.Data;
using BudgetSplit.New.Pages.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BudgetSplit.New.Pages.Common
{
    public abstract class SelectorComponent<T> : ComponentBase where T : class, new() 
    {
        [Inject]
        public ApplicationDbContext Context { get; set; }

        protected AutoCompleteNew<T>? _autoComplete;
        protected T EditingItem = new T();
        protected bool CreateDialogVisible { get; set; }

        [Parameter]
        public bool AllowCreate { get; set; } = true;

        private T? _value;
        [Parameter]
        public T? Value
        {
            get => _value; set
            {
                if (_value == null && value == null)
                {
                    return;
                }
                if (_value?.Equals(value) == true)
                    return;
                _value = value;
                ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<T?> ValueChanged { get; set; }

        protected abstract DbSet<T>? DbSet { get; }

        protected void OpenDialog()
        {
            EditingItem = new T();
            CreateDialogVisible = true;
        }

        protected async Task<IEnumerable<T>> Search1(string value)
        {
            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(value))
                return await DbSet.ToListAsync();
            var queryable = SearchFilter(DbSet, value);
            return await queryable.ToListAsync();
        }

        protected abstract IQueryable<T> SearchFilter(IQueryable<T> query, string filterText);

        protected async Task CreateItem()
        {
            DbSet.Add(EditingItem);
            await Context.SaveChangesAsync();
            Value = EditingItem;
            EditingItem = new T();
            CreateDialogVisible = false;
            await _autoComplete.SelectOption(Value);
            StateHasChanged();
        }

        protected virtual Task CancelCreate()
        {
            CreateDialogVisible = false;
            return Task.CompletedTask;
        }
    }
}
