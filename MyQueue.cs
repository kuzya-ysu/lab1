using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQueueClass
{
    public class MyQueue<T>
    {
        private T[] _items;
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        private int _head = 0;
        private int _tail = 0;

        public MyQueue() : this(4)
        {
        }

        public MyQueue(int capacity)
        {
            if (capacity > 0)
            {
                Capacity = capacity;
                _items = new T[Capacity];
            }
            else
            throw new ArgumentOutOfRangeException();
        }

        public MyQueue(IEnumerable<T> list)
        {
            if (list != null)
            {
                Capacity = list.Count();
                _items = new T[Capacity];
                foreach (var item in list)
                {
                    Enqueue(item);
                }
            }
            else
                throw new ArgumentNullException();
        }

        public void Enqueue(T item)
        {
            IncreaseCapacity();
            _items[_tail] = item;
            _tail++;
            _tail %= Capacity;
            Count++;
        }

        public T Dequeue()
        {
            if (Count > 0)
            {
                var item = _items[_head];
                _items[_head] = default(T);
                _head++;
                _head %= Capacity;
                Count--;
                return item;
            }
            else
                throw new InvalidOperationException();
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return _items[_head];
            
                
        }

        public bool Contains(T item)
        {
            foreach (var thing in _items)
            {
                if (item.Equals(thing))
                    return true;
            }
            return false;
        }

        private void IncreaseCapacity()
        {
            if (Count == Capacity)
            {
                Capacity *= 2;
                var temp = new T[Capacity];
                Array.Copy(_items, _head, temp, 0, Count - _head);
                Array.Copy(_items, 0, temp, Count - _head, _tail);
                _head = 0;
                _tail = Count;
                _items = temp;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (_head < _tail)
                for (int i = _head; i < _tail; i++)
                    stringBuilder.Append(_items[i] + " ");
            else
            {
                for (int i = _head; i < Capacity; i++)
                    stringBuilder.Append(_items[i] + " ");
                for (int i = 0; i < _tail; i++)
                    stringBuilder.Append(_items[i] + " ");
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Capacity = " + Capacity.ToString());
            stringBuilder.AppendLine("Head = " + _head.ToString());
            stringBuilder.AppendLine("Tail = " + _tail.ToString());
            return stringBuilder.ToString();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }
    }
}