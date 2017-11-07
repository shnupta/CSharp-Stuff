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
            this.key = k;
            this.val = v;
            deleted = false;
        }
    }
}
