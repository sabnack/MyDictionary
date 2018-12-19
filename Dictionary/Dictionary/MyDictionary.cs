using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class MyDictionary<TKey, TValue>
    {
        private Node<TKey, TValue>[] _nodes;
        private int _currentSize;
        public int Count;

        public MyDictionary(int size = 10)
        {
            _nodes = new Node<TKey, TValue>[size];
            _currentSize = size;
            Count = 0;
        }

        private int GetPosition(TKey key)
        {
            return Math.Abs(key.GetHashCode() % _currentSize);
        }

        public void Clear()
        {
            _nodes = new Node<TKey, TValue>[_currentSize];
            Count = 0;
        }

        public bool ContainsValue(TValue data)
        {
            foreach (var item in _nodes)
            {
                if (item == null)
                {
                    continue;
                }

                if (item.Data.Equals(data))
                {
                    return true;
                }

                if (item.Next != null)
                {
                    if (ContainsValue(data, item.Next))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ContainsValue(TValue data, Node<TKey, TValue> node)
        {
            var current = node;
            if (current.Data.Equals(data))
            {
                return true;
            }

            while (current.Next != null)
            {
                if (current.Key.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var item in _nodes)
            {
                if (item == null)
                {
                    continue;
                }

                if (item.Key.Equals(key))
                {
                    return true;
                }

                if (item.Next != null)
                {
                    if (ContainsKey(key, item.Next))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ContainsKey(TKey key, Node<TKey, TValue> node)
        {
            var current = node;
            if (current.Key.Equals(key))
            {
                return true;
            }

            while (current.Next != null)
            {
                if (current.Key.Equals(key))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Add(TKey key, TValue data)
        {
            if (ContainsKey(key))
            {
                throw new Exception("This key is not unique");
            }

            if (_nodes[GetPosition(key)] == null)
            {
                _nodes[GetPosition(key)] = new Node<TKey, TValue>(key, data);
                Count++;
            }
            else
            {
                Add(key, data, _nodes[GetPosition(key)]);
            }
        }

        private void Add(TKey key, TValue data, Node<TKey, TValue> node)
        {
            var current = node;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<TKey, TValue>(key, data);
            Count++;
        }
    }
}
