using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueRealisation<T>:IEnumerable<T>
    {
        private const int sizeCoefficientMultiplier= 2;

        private T[] elements;
        private int front;
        private int rear;
        private int size;
        private int count;
        private int index;
        public int version { get; private set;}

        public QueueRealisation(byte startSize)
        {
            front = 0;
            rear = -1;
            size = startSize;
            count = 0;
            version = 0;
            index = 0;
        }

        public void Insert(T element)
        {
            if (count==size)
            {
                Resize();
            }
            rear = (rear + 1) % size;
            elements[rear] = element;
            version++;
            count++;
        }

        public T Delete()
        {
            if (count==0)
            {
                throw new InvalidOperationException("Unable to remove item from empty queue");
            }
            T tempStorage = elements[front];
            front = (front + 1) % size;
            count--;
            version++;
            index = front;
            return tempStorage;
        }

        public int Count() => count;

        public IEnumerator<T> GetEnumerator() => new QueueIterator(this);

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        

        internal T GetElement(int index)
        {
            return elements[(front + index) % count];
        }
        
        private void Resize()
        {
            T[] newArray = new T[size * sizeCoefficientMultiplier];
            Array.Copy(elements, front, newArray, 0, size - front);
            Array.Copy(elements, 0, newArray, size - front + 1, rear);
            size *= sizeCoefficientMultiplier;
            front = 0;
            rear = count - 1;
        }

        private struct QueueIterator:IEnumerator<T>
        {
            private QueueRealisation<T> queue;
            private int index;
            private int version;
            private T currentElement;
            bool currentFlag;

            internal QueueIterator(QueueRealisation<T> queue)
            {
                this.queue = queue;
                version = queue.version;
                index = 0;
                currentElement = default(T);
                currentFlag = true;
                if (queue.count==0)
                {
                    index = -1;
                }
            }

            public bool MoveNext()
            {
                currentFlag = true;
                if (version!=queue.version)
                {
                    throw new InvalidOperationException($"{nameof(queue)} version has been changed");
                }

                if (index<0)
                {
                    currentFlag = false;
                    return false;
                }
                currentElement = queue.GetElement(index);
                index++;

                if (index==queue.count)
                {
                    index = -1;
                }
                return true;

            }

            public T Current
            {
                get
                {
                    if (!currentFlag)
                    {
                        if (index==0)
                        {
                            throw new InvalidOperationException();
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    return currentElement;
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Reset()
            {
                if (version!=queue.version)
                {
                    throw new InvalidOperationException();
                }
                if (queue.count==0)
                {
                    index = -1;
                }
                else
                {
                    index = 0;
                }
                currentFlag = false;
            }

            void IDisposable.Dispose() { }
        }


    }
}
