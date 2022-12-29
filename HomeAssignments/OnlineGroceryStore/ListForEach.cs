using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public partial class CustomList<Type>: IEnumerable,IEnumerator
    {
//get numerator
//in - Move next
//i-reset
// if i==count-1 - return false
        int i;
        public IEnumerator GetEnumerator()
        {
            i=-1;//i=0;
            return (IEnumerator)this;
        }  
        public bool MoveNext()
        {
            if(i<_count -1 )
            {
                ++i;    //delete this for start from i=0
                return true;
            }
            Reset();//Reset Position value if no element in list
            return false;
        } 
        public void Reset() //Resets if or next turn
        {
            i=-1;
        }
        public object Current   //Returns the current array position value
        {
            get 
            { 
                return _array[i];  //for start from i=0  i++;
            }
        }

    }
}