using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;

namespace Program
{
    class PQueue<T>
    {
        /// <summary>
        /// Список из очередей. Индексы, по которым находятся очереди, 
        /// определяют приоритет, лежащих в ней элементов.
        /// </summary>
        List<Sort.Queue<T>> pqueue;
        /// <summary>
        /// Величина очереди и по совместительству величина наивысшего приоритета.
        /// </summary>
        int Length;
        /// <summary>
        /// Кол-во элементов в очереди.
        /// </summary>
        int CountOfPriority;

        /// <summary>
        /// Конструктор задает величину очереди приоритетов равную 50 
        /// и размер очереди для данного приоретета равную 50. 
        /// </summary>
        public PQueue()
        {
            pqueue = new List<Sort.Queue<T>>();
            Length = 50;
            CountOfPriority = 50;
        }
        /// <summary>
        /// Конструктор задает величину очереди приоритетов равную length 
        /// и размер очереди для данного приоретета равную countOfPriority. 
        /// </summary>
        public PQueue(int countOfPriority, int length)
        {
            pqueue = new List<Sort.Queue<T>>();
            Length = length;
            CountOfPriority = countOfPriority;
        }

        /// <summary>
        /// Количество элементов в очереди приоритетов.
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;

                foreach (var item in pqueue)
                {
                    if (!(item is null || item.Count == 0))
                        count += item.Count;
                }

                return count;
            }
        }

        /// <summary>
        /// Вернуть самый приоритетный элемент без удаления.
        /// </summary>
        public T PPeek()
        {
            if (pqueue.Count == 0) throw new Exception("Очередь приоритетов пуста");

            return pqueue[pqueue.Count - 1].Peek();
        }

        /// <summary>
        /// Вернуть самый приоритетный элемент с удалением.
        /// </summary>
        public T PDequeue()
        {
            if (pqueue.Count == 0) throw new Exception("Очередь приоритетов пуста");

            T item = pqueue[pqueue.Count - 1].Dequeue();

            while(pqueue[pqueue.Count - 1].IsEmpty)
            {
                pqueue.RemoveAt(pqueue.Count - 1);
                if (pqueue.Count == 0) return item;
            }
            return item;
        }

        /// <summary>
        /// Добавить элемент item, с приоритетом priority.
        /// </summary>
        public void PEnqueue(int priority, T item)
        {
            if (priority >= Length) throw new Exception("Большой приоритет, увеличте объем очереди.");
            while (priority + 1 > pqueue.Count)
            {
                try
                {
                    pqueue.Add(new Sort.Queue<T>(CountOfPriority));
                }
                catch
                {
                    throw new Exception("Очередь данного приоритета переполнена.");
                }
            }
            pqueue[priority].Enqueue(item);
        }

        /// <summary>
        /// Проверить элемент на наличие в очереди приоритетов. 
        /// </summary>
        public bool Contains(T item)
        {
            foreach (var value in pqueue)
            {
                if (value.Contains(item)) return true;
            }
            return false;
        }

        /// <summary>
        /// Очистить очередь приоритетов. 
        /// </summary>
        public void Clear()
        {
            foreach (var item in pqueue)
            {
                item.Clear();
            }
            pqueue.Clear();
        }

        /// <summary>
        /// Проверить пуста ли очередь приоритетов.
        /// </summary>
        public bool IsEmpty => (pqueue.Count == 0);

        /// <summary>
        /// Проверить плона ли очередь приоритетов.
        /// </summary>
        public bool IsFull => (pqueue.Count == Length);
    }
}
