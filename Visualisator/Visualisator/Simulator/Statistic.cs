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
        public long     PacketsSum      { set; get; }
        public Statistic()
        {
                
        }

        public float getPercentInTdls()
        {
            return (PacketsInTdls*100)/Packets;
        }

        public static double ConvertBytesToKilobytes(long bytes)
        {
            return  Math.Round((bytes / 1024f),1);
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return  Math.Round(((bytes / 1024f) / 1024f),1);
        }

        public static float ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        public string getSpeedInHumanRead()
        {
            string ret;

            if (Speed < 1024f)
            {
                ret = Speed + " bs";
            }
            else if (Speed < 1048567f)
            {
                ret = ConvertBytesToKilobytes((long)Speed).ToString(CultureInfo.InvariantCulture) + " Kbs";
            }
            else
            {
                ret = ConvertBytesToMegabytes((long)Speed).ToString(CultureInfo.InvariantCulture) + " Mbs";
            }

            return ret;
        }
    }
}
