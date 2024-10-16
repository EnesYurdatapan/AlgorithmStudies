using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExamples.Array
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] innerList;
        public int Count { get; private set; }
        public int Capacity => innerList.Length;
        public Array()
        {

        }
        public Array(params T[] initial)
        {
            innerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
            {
                Add(item);
                Count++;
            }
        }
        public Array(IEnumerable<T> collection)
        {
            innerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach (var item in collection)
            {
                Add(item);
                Count++;
            }

        }
        public void Add(T item)
        {
            if (Count == innerList.Length)
                DoubleArray();
            innerList[Count] = item;
            Count++;
        }

        private void DoubleArray()
        {
            var temp = new T[innerList.Length * 2];
            //for (int i = 0; i < innerList.Length; i++)
            //{
            //    temp[i] = innerList[i];
            //}
            System.Array.Copy(innerList, temp, innerList.Length);
            innerList = temp;
        }
        public T Remove()
        {
            if (Count == 0)
                throw new Exception("There is no more item to be removed from the array");
            if (innerList.Length / 4 == Count)
                HalfArray();
            var temp = innerList[Count - 1];
            if (Count > 0)
                Count--;
            return temp;
        }

        private void HalfArray()
        {
            if (innerList.Length > 2)
            {
                var temp = new T[innerList.Length / 2];
                System.Array.Copy(innerList, temp, innerList.Length / 4);
                innerList = temp;
            }
        }

        public object Clone()
        {
            //var arr = new Array<T>();
            //foreach (var item in arr)
            //    arr.Add(item);
            //return arr;
            return this.MemberwiseClone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return innerList.Select(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
