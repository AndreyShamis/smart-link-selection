using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator
{
    [Serializable()]
    class RFpeer
    {
        public string   MAC { set; get; }
        public short    RetransmitionCounter { set; get; }
        public double   RSSI { set; get; }
        public double   Distance { set; get; }
        public short    Channel { set; get; }
        public string   Band { set; get; }
        public string   BSSID { set; get; }



    }
}
