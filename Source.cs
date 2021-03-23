using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            if (capacity == 0)
            {
                array = new T[new_capacity];
                capacity = new_capacity;
                return;
            }

            if (new_capacity < 16) new_capacity = 16;

            T[] new_array = new T[new_capacity];
            array.CopyTo(new_array, 0);
            array = new_array;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            return array[index];
        }

        public void Append(T itm)
        {
            if (count == capacity)
            {
                MakeArray(capacity * 2);
            }

            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index > count)
            {
                throw new IndexOutOfRangeException();
            }

            if (count == capacity)
            {
                capacity *= 2;
            }

            T[] new_array = new T[capacity];

            if (index == 0)
            {
                Array.Copy(array, 0, new_array, 1, count);
            }
            else
            {
                Array.Copy(array, 0, new_array, 0, index);
                Array.Copy(array, index, new_array, index + 1, count - index);
            }

            array = new_array;
            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            if (capacity / 2 > count - 1)
            {
                capacity = capacity * 2 / 3;
                if (capacity < 16) capacity = 16;
            }

            T[] new_array = new T[capacity];
            Array.Copy(array, 0, new_array, 0, index);
            Array.Copy(array, index + 1, new_array, index, count - 1);
            array = new_array;
            count--;
        }

    }
}
