using System;
using System.Collections.Generic;
using System.Globalization;
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
        public int      CoordinateX     { set; get; }
        public int      CoordinateY     { set; get; }
        public string   BSS_BandWith    { set; get; }
        public string   BSS_Standart    { set; get; }
        public string   TDLS_BandWith   { set; get; }
        public string   TDLS_Standart   { set; get; }

        public Statistic()
        {
                
        }

        public float getPercentInTdls()
        {
            return (PacketsInTdls*100)/Packets;
        }

        public static float ConvertBytesToKilobytes(long bytes)
        {
            return (bytes / 1024f);
        }

        public static float ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static float ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        public string getSpeedInHumanRead()
        {
            string ret;
            double m_speed = this.Speed;

            if(m_speed <1000)
            {
                ret = m_speed + " bs";
            }
            else if(m_speed < 1000000)
            {
                ret = ConvertBytesToKilobytes((long)m_speed).ToString(CultureInfo.InvariantCulture) + " Kbs";
            }
            else
            {
                ret = ConvertBytesToMegabytes((long)m_speed).ToString(CultureInfo.InvariantCulture) + " Mbs";
            }

            return ret;
        }
    }
}
