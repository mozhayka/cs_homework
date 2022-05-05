using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace task1
{
    internal class UnmanagedResource
    {
        public UnmanagedResource()
        {
            // take some unmanaged resource
            Console.WriteLine("Allocating unmanaged resource");
        }

        public void Clean()
        {
            // free some unmanaged resource
            Int32 generation = GC.GetGeneration(this);
            Console.WriteLine("Cleaning unmanaged resource in {0} generation", generation);
        }
    }

    // Шаблон IDisposable в случае, когда используются неуправляемые ресурсы,
    // должен иметь финализатор, чтобы гарантировать освобождение ресурсов, даже если вдруг кто-то забыл вызвать Dispose метод
    // а если ресурсы критически важны, то лучше вообще использовать CriticalFinalizerObject
    class DisposableObject : IDisposable
    {
        private readonly UnmanagedResource _resource;
        public Timer _timer;
        public bool isOld { get; private set; }

        public DisposableObject(int max_time)
        {
            isOld = false;
            _resource = new UnmanagedResource();
            // timer - это disposable объект, у него тоже нужно удалять ресурсы
            // в этом случае таймер будет вызывать метод Old каждые max_time милисекунд
            // для разового запуска можно испольховать Timeout.InfiniteTimeSpan
            _timer = new Timer(Old, null, 0, max_time);
        }

        public void Dispose()
        {
            _resource.Clean();
            //т.к. у класса не задан финализатор, то вызов GC.SuppressFinalize(this) не имеет смысла
            GC.SuppressFinalize(this);
        }

        private void Old(Object state)
        {
            if(!isOld)
                Console.WriteLine("Obj is old now");
            isOld = true;
        }
    }
}
