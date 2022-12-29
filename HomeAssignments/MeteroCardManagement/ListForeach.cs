using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace MeteroCardManagement
{
    public partial class CustomList<Type>:IEnumerable,IEnumerator
    {
        int i;
        public IEnumerator GetEnumerator()
        {
            i=-1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if(i<_count-1)
            {
                ++i;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            i=-1;
        }
        public object Current
        {
            get{
                return _array[i];
            }
        }
    }
}