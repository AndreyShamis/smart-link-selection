using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace Visualisator
{
     [Serializable()]
    class ByteArrayComparer: IEqualityComparer {
          public int GetHashCode(object obj) {
              byte[] arr = ObjectToByteArray(obj);// as byte[];
            int hash = 0;
            foreach (byte b in arr) hash ^= b;
            return hash;
          }
          public new bool Equals(object x, object y) {
            byte[] arr1 =ObjectToByteArray(x);// as byte[];
            byte[] arr2 = ObjectToByteArray(y);// as byte[];
            if (arr1.Length != arr2.Length) return false;
            for (int ix = 0; ix < arr1.Length; ++ix)
              if (arr1[ix] != arr2[ix]) return false;
            return true;
          }

          private byte[] ObjectToByteArray(Object obj)
          {
              if (obj == null)
                  return null;
              BinaryFormatter bf = new BinaryFormatter();
              MemoryStream ms = new MemoryStream();
              bf.Serialize(ms, obj);
              return ms.ToArray();
          }
    
    }
}
