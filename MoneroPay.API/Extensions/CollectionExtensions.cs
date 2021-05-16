using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneroPay.API.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static async IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IEnumerable<Task<T>> source)
        {
            foreach (var task in source)
            {
                yield return await task;
            }
        }

        /// <summary>
        /// Returns an existing task from the concurrent dictionary, or adds a new task
        /// using the specified asynchronous factory method. Concurrent invocations for
        /// the same key are prevented, unless the task is removed before the completion
        /// of the delegate. Failed tasks are evicted from the concurrent dictionary.
        /// </summary>
        public static Task<TValue> GetOrAddAsync<TKey, TValue>(
                this ConcurrentDictionary<TKey, Task<TValue>> source,
                TKey key,
                Func<TKey, Task<TValue>> valueFactory)
            where TKey : notnull
        {
            if (!source.TryGetValue(key, out var currentTask))
            {
                Task<TValue>? newTask = null;
                var newTaskTask = new Task<Task<TValue>>(async () =>
                {
                    try { return await valueFactory(key).ConfigureAwait(false); }
                    catch
                    {
                        if (newTask != null) source.TryRemove(KeyValuePair.Create(key, newTask));
                        throw;
                    }
                });
                newTask = newTaskTask.Unwrap();
                currentTask = source.GetOrAdd(key, newTask);
                if (currentTask == newTask)
                    newTaskTask.RunSynchronously(TaskScheduler.Default);
            }
            return currentTask;
        }
    }
}