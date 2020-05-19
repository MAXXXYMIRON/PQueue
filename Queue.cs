using System;
using System.Collections.Generic;

namespace Sort
{
    class Queue<T>
    {
        List<T> queue = new List<T>();

        /// <summary>
        /// Величина очереди. 
        /// </summary>
        public readonly int Length;
        /// <summary>
        /// Конструктор, задает величину очереди равную 50. 
        /// </summary>
        public Queue()
        {
            Length = 50;
        }
        /// <summary>
        /// Конструктор с заданием величины очереди. 
        /// </summary>
        public Queue(int count)
        {
            Length = count;
        }

        /// <summary>
        /// Вернет первый элемент очереди без удаления.
        /// </summary>
        public T Peek()
        {
            if (queue.Count == 0) throw new Exception("Очередь пуста!");
            return queue[0];
        }

        /// <summary>
        /// Получить первый элемент из очереди. 
        /// </summary>
        public T Dequeue()
        {
            if (queue.Count == 0) throw new Exception("Очередь пуста!");
            T item = queue[0];
            queue.RemoveAt(0);
            return item;
        }

        /// <summary>
        /// Добавить элемент в очередь. 
        /// </summary>
        public void Enqueue(T item)
        {
            if (queue.Count == Length) throw new Exception("Очередь полна!");
            queue.Add(item);
        }

        /// <summary>
        /// Проверить элемент на наличие в очереди. 
        /// </summary>
        public bool Contains(T item) => queue.Contains(item);

        /// <summary>
        /// Очистить очередь. 
        /// </summary>
        public void Clear() => queue.Clear();

        /// <summary>
        /// Кол-во элементов в очереди. 
        /// </summary>
        public int Count => queue.Count;


        /// <summary>
        /// Проверить пуста ли очереди. 
        /// </summary>
        public bool IsEmpty => (queue.Count == 0);

        /// <summary>
        /// Проверить полна ли очереди. 
        /// </summary>
        public bool IsFull => (queue.Count == Length);
    }
}
