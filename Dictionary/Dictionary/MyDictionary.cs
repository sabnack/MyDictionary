using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class MyDictionary<TKey, TValue> : IEnumerable
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

        public void Remove(TKey key)
        {
            if (!ContainsKey(key))
            {
                throw new Exception("This key dose not exist");
            }

            var position = GetPosition(key);

            if (_nodes[position].Key.Equals(key))
            {
                if (_nodes[position].Next == null)
                {
                    _nodes[position] = null;
                }
                else
                {
                    _nodes[position] = _nodes[position].Next;
                }
            }
            else
            {
                if (_nodes[position].Next != null)
                {
                    Remove(key, _nodes[position].Next, _nodes[position]);
                }
            }

        }

        private void Remove(TKey key, Node<TKey, TValue> node, Node<TKey, TValue> prev)
        {
            var current = node;

            while (current != null)
            {
                if (current.Key.Equals(key) && current.Next == null)
                {
                    prev.Next = null;
                    break;
                }

                if (current.Key.Equals(key) && current.Next != null)
                {
                    prev.Next = current.Next;
                    break;
                }
                prev = current;
                current = current.Next;
            }
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
            var position = GetPosition(key);

            var tmp = _nodes[position];

            while (tmp != null)
            {
                if (tmp.Key.Equals(key))
                {
                    return true;
                }
                tmp = tmp.Next;
            }

            return false;
        }

        public void Add(TKey key, TValue data)
        {
            var position = GetPosition(key);
            if (ContainsKey(key))
            {
                throw new Exception("This key is not unique");
            }

            if (_nodes[position] == null)
            {
                _nodes[position] = new Node<TKey, TValue>(key, data);
                Count++;
            }
            else
            {
                Add(key, data, _nodes[position]);
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

        public IEnumerator<KeyValuePair<TKey, TValue>> Enumerator()
        {
            foreach (var item in _nodes)
            {
                yield return new KeyValuePair<TKey, TValue>(item.Key, item.Data);
                if (item.Next != null)
                {
                    var current = item;
                    while (current.Next != null)
                    {
                        current = current.Next;
                        yield return new KeyValuePair<TKey, TValue>(current.Key, current.Data);
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
