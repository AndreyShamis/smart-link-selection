using System;
namespace Visualisator
{
    [Serializable()]
    class MAC:ISerializable
    {
        private string _MAC;
        private static Random rand = new Random(123);
        public  MAC()
        {
            
            int _mac1 = rand.Next(0, 255);
            int _mac2 = rand.Next(0, 255);
            int _mac3 = rand.Next(0, 255);
            int _mac4 = rand.Next(0, 255);
            int _mac5 = rand.Next(0, 255);
            int _mac6 = rand.Next(0, 255);

            _MAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", _mac1, _mac2, _mac3, _mac4, _mac5, _mac6);
            
        }
        public MAC(string SavedMAC)
        {
            _MAC = SavedMAC;
        }
        public string getMAC()
        {
            return _MAC;  
        }

    }
}
