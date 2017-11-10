using System;
namespace KCTable
{
    public class KCTable<K, V>
    {
        KeyValue<K, V>[] data;
        private int capacity;
        private int size;
        private float loadFactor;

        public KCTable()
        {
            data = new KeyValue<K, V>[31];
            capacity = 31;
            size = 0;
            loadFactor = size / capacity;
            initializeTable();
        }

        public int Capacity()
        {
            return capacity;
        }

        public int Size()
        {
            return size;
        }

        public float LoadFactor()
        {
            return loadFactor;
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
            if (c == 2) return true; // n only has two factors so is prime
            return false;
        }

        private int primeUp(int n)
        {
            while (!isPrime(n)) n++;

            return n;
        }

        private int hash(K k)
        {
            return (int)k.GetHashCode() % capacity;
        }

        public void Add(K k, V v)
        {
            // first check if resize is needed
            if (loadFactor >= 0.7) resize(primeUp(capacity * 2));

            int index = hash(k);
            while(data[index] != null)
            {
                index++;
            }

            // here we have found an empty space to insert
            data[index] = new KeyValue<K, V>(k, v);
            size++;
            updateLoadFactor();
        }

        private void updateLoadFactor()
        {
            loadFactor = (float)size / capacity;
        }

        private void resize(int newSize)
        {
            // new size is already prime, so just set up a new array and rehash
            int oldCap = capacity;
            capacity = newSize;
            size = 0;
            updateLoadFactor();
            KeyValue<K, V>[] old = data;
            data = new KeyValue<K, V>[capacity];
            
            initializeTable(); // data is now an empty array

            for (int i = 0; i < oldCap; i++)
            {
                if(old[i] != null && !old[i].deleted)
                {
                    this.Add(old[i].key, old[i].val);
                }
            }

            updateLoadFactor();
        }

        public bool Exists(K k)
        {
            int index = hash(k);

            while(data[index] != null)
            {
                if (data[index].key.Equals(k) && !data[index].deleted) return true;
                index++;
            }

            return false;
        }

        public V Get(K k)
        {
            int index = hash(k);

            while(data[index] != null)
            {
                if (data[index].key.Equals(k) && !data[index].deleted) return data[index].val;
                index++;
            }

            throw new KeyNotFoundException();
        }

        public void Remove(K k)
        {
            int index = hash(k);

            while(data[index] != null)
            {
                if(data[index].key.Equals(k) && !data[index].deleted)
                {
                    data[index].deleted = true;
                    break;
                }
                index++;
            }

            size--;

            updateLoadFactor();
        }
    }
}
