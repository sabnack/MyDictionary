using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Node<TKey, TValue>
    {
        public TKey Key;
        public TValue Data;
        public Node<TKey, TValue> Next;

        public Node(TKey key, TValue data)
        {
            Key = key;
            Data = data;
            Next = null;
        }
    }
}
