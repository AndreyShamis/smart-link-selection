using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Visualisator
{
    [Serializable()]
    class ArrayListCounted : ArrayList
    {

        [Serializable()]
        class CountedKey
        {
            private String _MAC;
            public CountedKey(String MAC)
            {
                _MAC = MAC;
            }
        }
        const int MAX_KEEP_ALIVE_COUNTER = 4;
        Hashtable _counters = new Hashtable(new ByteArrayComparer());

        public void Increase(object _obj)
        {
            if(this.Contains(_obj))
            {
                CountedKey k = new CountedKey((String)_obj);

                if (_counters.Contains(k))
                {
                    _counters[k] = MAX_KEEP_ALIVE_COUNTER;

                }
                else
                {
                    _counters.Add(k, MAX_KEEP_ALIVE_COUNTER);
                }
            }
            
        }

        public void Decrease(object _obj)
        {
            int temp = 0;
            if (this.Contains(_obj))
            {
                CountedKey k = new CountedKey((String)_obj);

                if (_counters.Contains(k))
                {

                    temp = (int)_counters[k];
                    temp--;
                    _counters[k] = temp;
                }
                else
                {
                    _counters.Add(k, 0);
                }

                if (temp < 0)
                {
                    _counters.Remove(k);
                    this.Remove((String)_obj);
                }
            }
        }

        public void DecreaseAll()
        {
            try
            {
                if (this.Count > 0)
                {
                    foreach (String st in this)
                    {
                        this.Decrease(st);
                    }
                }
            }
            catch (Exception) { }
        }

        
    }
}
