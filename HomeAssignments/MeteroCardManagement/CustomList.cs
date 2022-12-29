using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace MeteroCardManagement
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        public int Count{get{return _count;}}
        public int Capacity{get{return _capacity;}}
        private Type[] _array;
        public Type this[int k]
        {
            get{return _array[k];}
            set{_array[k]=value;}
        }
        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count=0;
            _capacity=size;
            _array=new Type [_capacity];
        }
        public void  Add(Type data)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
                _array[_count]=data;
                _count++;
            
        }
        void GrowSize()
        {
            _capacity*=2;
            Type []temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        void AddRange(CustomList<Type> dataList)
        {
            _capacity+=dataList.Count+_count+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k=0;
            for(int j=_count;j<_count+dataList.Count;j++)
            {
                temp[j]=dataList[k++];
            }
            _array=temp;
            _count+=dataList.Count;
        }
    }
}