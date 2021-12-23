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

    class DisposableObject : IDisposable
    {
        private readonly UnmanagedResource _resource;
        public Timer _timer;
        public bool isOld { get; private set; }

        public DisposableObject(int max_time)
        {
            isOld = false;
            _resource = new UnmanagedResource();
            _timer = new Timer(Old, null, 0, max_time);
        }

        public void Dispose()
        {
            _resource.Clean();
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
