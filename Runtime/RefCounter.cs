namespace AYip.Foundations
{
    /// <summary>
    /// Responsible for counting the reference for the object, then manually deal with the release method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RefCounter<T> : DisposableBase
    {
        protected T instance;
        
        protected RefCounter(T instance)
        {
            this.instance = instance;
            RefCount = 0;
        }
        
        /// <summary>
        /// The current reference count.
        /// </summary>
        public int RefCount { get; private set; }

        public (T instance, RefCounter<T> refCounter) Register()
        {
            RefCount++;
            return (instance, this);
        }
        
        /// <summary>
        /// Complete the usage of this reference.
        /// </summary>
        public void CompleteTask()
        {
            if (--RefCount > 0) return;
            ReleaseInstance();
            instance = default;
            Dispose();
        }

        /// <summary>
        /// Handle your release method.
        /// </summary>
        protected abstract void ReleaseInstance();
    }
}