using System;
using System.Dynamic;
using System.Runtime;

namespace DataStructures.Queue
{
    public class PriorityQueue<T>
    {
        private PQNode<T>[] _heap;
        private int _size;

        public PriorityQueue()
        {
            _heap = new PQNode<T>[16];
            _size = 0;
        }

        public void Insert(T data, int priority)
        {
            if (_size == _heap.Length - 1)
                Resize();

            _size++;
            var newNode = new PQNode<T>(data, priority);
            
            int index = PercolateUp(_size, newNode);
            _heap[index] = newNode;
        }

        public T DeleteMin()
        {
            if (_size == 0)
                throw new ArgumentOutOfRangeException("The priority queue is empty");

            var min = _heap[1];
            var hole = PercolateDown(1, _heap[_size]);

            _heap[hole] = _heap[_size];
            _size--;
            return min.Data;
        }

        public void DecreaseKey(T val, int newPriority)
        {
            var index = GetIndex(val);
            
            DecreaseKey(index, newPriority);
        }
        
        public void DecreaseKey(int index, int newPriority)
        {
            if (index > _size || index < 1)
                throw new ArgumentException("Index is out of range");

            _heap[index].Priority = newPriority;

            var placeholder = _heap[index];
            var hole = PercolateUp(index, _heap[index]);
            _heap[hole] = placeholder;
        }

        public void IncreaseKey(T val, int newPriority)
        {
            var index = GetIndex(val);

            IncreaseKey(index, newPriority);
        }
        
        public void IncreaseKey(int index, int newPriority)
        {
            if (index > _size || index < 1)
                throw new ArgumentException("Index is out of range");

            _heap[index].Priority = newPriority;

            var placeholder = _heap[index];
            var hole = PercolateDown(index, _heap[index]);
            _heap[hole] = placeholder;
        }

        private int GetIndex(T val)
        {
            for (var i = 1; i <= _size; i++)
            {
                if (_heap[i].Data.Equals(val))
                {
                    return i;
                }
            }

            throw new ArgumentException("value of: " + val.ToString() + " is not in the queue`");
        }

        private int PercolateUp(int hole, PQNode<T> data)
        {
            while (hole > 1 && data.Priority < _heap[hole / 2].Priority)
            {
                _heap[hole] = _heap[hole / 2];
                hole /= 2;
            }

            return hole;
        }

        private int PercolateDown(int hole, PQNode<T> data)
        {
            while (2 * hole <= _size)
            {
                var left = 2 * hole;
                var right = left + 1;

                var target = left;
                if (right > _size || _heap[left].Priority < _heap[right].Priority)
                    target = left;
                else
                    target = right;

                if (_heap[target].Priority >= data.Priority)
                    break;
                
                _heap[hole] = _heap[target];
                hole = target;
            }

            return hole;
        }

        private void Resize()
        {
            var newHeap = new PQNode<T>[_heap.Length * 2];
            for (var i = 0; i < _heap.Length; i++)
            {
                newHeap[i] = _heap[i];
            }

            _heap = newHeap;
        }
        
        

        private class PQNode<T>
        {
            public int Priority { get; set; }
            public T Data { get; set; }

            public PQNode(T data, int priority)
            {
                this.Data = data;
                this.Priority = priority;
            }
        }
    }
}