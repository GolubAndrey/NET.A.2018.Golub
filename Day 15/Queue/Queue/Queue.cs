using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueRealisation<T> : IEnumerable<T>
    {
        private const int sizeCoefficientMultiplier = 2;

        private T[] elements;
        private int front;
        private int rear;
        private int size;
        private int count;
        private int index;
        public int version { get; private set; }

        /// <summary>
        /// Create queue
        /// </summary>
        /// <exception cref="ArgumentException">Arise when input parameter = 0</exception>
        /// <param name="startSize">Start queue size</param>
        public QueueRealisation(byte startSize)
        {
            if (startSize == 0)
            {
                throw new ArgumentException($"{nameof(startSize)} can't be 0");
            }
            front = 0;
            rear = -1;
            size = startSize;
            count = 0;
            version = 0;
            index = 0;
            elements = new T[startSize];
        }

        /// <summary>
        /// Create queue from the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when input parameter is null</exception>
        /// <param name="list">Collection for the queue</param>
        public QueueRealisation(IEnumerable<T> list)
        {
            if (ReferenceEquals(list,null))
            {
                throw new ArgumentNullException($"{nameof(list)} can't be null");
            }

            T[] tempArray = list.ToArray();

            if (tempArray.Length==0)
            {
                size = 1;
                elements = new T[size];
                count = 0;
                rear = -1;
            }
            else
            {
                size = tempArray.Length;
                elements = new T[size];
                tempArray.CopyTo(elements, 0);
                rear = size - 1;
                count = size;
            }
            front = 0;
            version = 0;
            index = 0;


        }

        /// <summary>
        /// Adding element in the queue
        /// </summary>
        /// <param name="element">Element for the queue</param>
        public void Insert(T element)
        {
            if (count == size)
            {
                elements=Resize();
            }
            rear = (rear + 1) % size;
            elements[rear] = element;
            version++;
            count++;
        }
        

        /// <summary>
        /// Leaving item from queue
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when number of elements in queue equals 0</exception>
        /// <returns>The item that left the queue </returns>
        public T Delete()
        {
            if (count == 0)
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

        /// <summary>
        /// Take the first element in the queue
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the queue is empty</exception>
        /// <returns>First element</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException($"Queue can't be empty");
            }
            return elements[front];
        }

        /// <summary>
        /// Check for empty queue
        /// </summary>
        /// <returns>true when queue is empty and false when queue has 1 or more element</returns>
        public bool IsEmpty()
        {
            return count == 0 ? true : false;
        }

        /// <summary>
        /// Check for full queue
        /// </summary>
        /// <returns>true when queue is full and false when queue has 1 or more free place</returns>
        public bool isFull()
        {
            return count == size ? true : false;
        }

        /// <summary>
        /// Get number of elements in the queue
        /// </summary>
        /// <returns>Number of elements in the queue</returns>
        public int Count() => count;

        /// <summary>
        /// Get iterator for the queue
        /// </summary>
        /// <returns>Object of IEnumerator</returns>
        public IEnumerator<T> GetEnumerator() => new QueueIterator(this);

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        internal T GetElement(int index)
        {
            return elements[(front + index) % count];
        }

        private T[] Resize()
        {
            T[] newArray = new T[size * sizeCoefficientMultiplier];
            Array.Copy(elements, front, newArray, 0, size - front);
            Array.Copy(elements, 0, newArray, size - front + 1, rear);
            size *= sizeCoefficientMultiplier;
            front = 0;
            rear = count - 1;
            return newArray;
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
