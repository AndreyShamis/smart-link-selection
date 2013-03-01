using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator
{
    [Serializable()]
    class MAC:ISerializable
    {
        private String _MAC;
        private static Random rand = new Random(123);
        public  MAC()
        {
            
            Int32 _mac1 = rand.Next(0, 255);
            Int32 _mac2 = rand.Next(0, 255);
            Int32 _mac3 = rand.Next(0, 255);
            Int32 _mac4 = rand.Next(0, 255);
            Int32 _mac5 = rand.Next(0, 255);
            Int32 _mac6 = rand.Next(0, 255);

            _MAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", _mac1, _mac2, _mac3, _mac4, _mac5, _mac6);
            
        }
        public MAC(String SavedMAC)
        {

            _MAC = SavedMAC;

        }
        public String getMAC()
        {
            return _MAC;
        }

    }
}
