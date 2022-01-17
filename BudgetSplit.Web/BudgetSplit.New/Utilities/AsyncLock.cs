namespace BudgetSplit.New.Utilities
{
    public class AsyncLock
    {
        protected SemaphoreSlim _semaphore;

        public AsyncLock()
        {
            _semaphore = new SemaphoreSlim(1,1);
        }

        public async Task<AsyncLockScope> Lock()
        {
            await _semaphore.WaitAsync();
            return new AsyncLockScope(_semaphore);
        }

        
    }

    public class AsyncLockScope : IDisposable
    {
        private SemaphoreSlim _semaphore;

        public AsyncLockScope(SemaphoreSlim semaphore)
        {
            _semaphore = semaphore;
        }

        public void Dispose()
        {
            _semaphore.Release();
        }
    }
}
