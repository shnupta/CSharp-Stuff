using System;
namespace KCTable
{
    public class KeyValue<K, V>
    {
        public K key;
        public V val;
        public bool deleted;

        public KeyValue(K k, V v)
        {
            key = k;
            val = v;
            deleted = false; // by default is not deleted
        }
    }
}
