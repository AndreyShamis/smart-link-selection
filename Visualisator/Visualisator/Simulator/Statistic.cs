using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator.Simulator
{
    [Serializable]
    class Statistic:ISerializable
    {
        public string   FileName        { set; get; }
        public string   SourceMAC       { set; get; }
        public string   DesctinationMAC { set; get; }
        public long     FileSize        { set; get; }
        public double   Time            { set; get; }
        public bool     TdlsUse         { set; get; }
        public long     PacketsInTdls   { set; get; }
        public double   Speed           { set; get; }
        public long     Packets         { set; get; }

        public Statistic()
        {
                
        }

        public float getPercentInTdls()
        {
            return (PacketsInTdls*100)/Packets;

        }
    }
}
