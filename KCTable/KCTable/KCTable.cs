using System;
namespace KCTable
{
    public class KCTable<K, V>
    {
        KeyValue<K, V>[] data;
        int capacity;
        int size;
        float loadFactor;

        public KCTable()
        {
            data = new KeyValue<K, V>[31];
            capacity = 31;
            size = 0;
            loadFactor = size / capacity;
            initializeTable();
        }

        private void initializeTable()
        {
            for (int i = 0; i < capacity; i++)
            {
                data[i] = null;
            }
        }

        private bool isPrime(int n)
        {
            int c = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) c++;
            }
            if (c == 2) return true;
            return false;
        }

        private int hash(K k)
        {
            return Math.Abs(k.GetHashCode() % capacity);
        }

        public void Add(K k, V v)
        {
            int index = hash(k);

            if(data[index] == null)
            {
                data[index] = new KeyValue<K, V>(k, v);
            }
        }

        private void resize()
        {
            
        }

        public bool Exists(K k)
        {
            return false;
        }

        public V Get(K k)
        {
            int index = hash(k);

            if(data[index] != null)
            {
                if (data[index].key.Equals(k)) return data[index].val;
            }

            return data[0].val;
        }

        public void Remove(K k)
        {
            
        }
    }
}
