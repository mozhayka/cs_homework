using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    class Cash
    {
        List<DisposableObject> obj;
        int max_size;
        int cur_cnt = 0;
        public Cash(int max_size = 10)
        {
            this.max_size = max_size;
            obj = new List<DisposableObject>(max_size);
        }

        public void Add()
        {
            if (cur_cnt == max_size)
            {
                Cleanup();
            }
        }

        private void Cleanup()
        {

        }
    }
}
