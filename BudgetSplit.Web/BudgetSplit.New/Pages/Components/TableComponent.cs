using BudgetSplit.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace BudgetSplit.New.Pages.Components
{
    public class TableComponent<T> : MudTable<T> where T : new()
    {
        public TableComponent()
        {
            OnCommitEditClick = EventCallback.Factory.Create<MouseEventArgs>(this, OnCommitEdit);
            OnPreviewEditClick = EventCallback.Factory.Create<object>(this, OnStartEdit);
            RowEditCancel = async e => await OnEditCancel(e);
            CreateNew = () => Task.FromResult(new T());
        }

        protected async Task OnCommitEdit(MouseEventArgs args)
        {
            await UpdateEntry(EditingEntry);
            StateHasChanged();
        }

        protected async Task OnStartEdit(object element)
        {
            EditingEntry = (T)element;
        }

        protected async Task OnEditCancel(object element)
        {
            await ResetEntry((T)element);
            StateHasChanged();
        }

        public T EditingEntry { get; set; }
        public T NewEntry { get; set; }

        [Parameter]
        public Func<T, Task> ResetEntry { get; set; }

        [Parameter]
        public Task<T> InsertEntry { get; set; }

        [Parameter]
        public Func<Task<T>> CreateNew { get; set; }

        [Parameter]
        public Func<T, Task> UpdateEntry { get; set; }

        
    }
}
