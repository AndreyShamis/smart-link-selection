using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator.RF
{
    public class RateTable
    {

        public short RSSI { set; get; }
        public short Freq { set; get; }

        /// <summary>
        /// Constructor for Rates
        /// </summary>
        /// <param name="rssi">Rssi</param>
        /// <param name="freq"></param>
        public RateTable(short rssi,short freq)
        {
            short tempRssi = rssi;

            if (freq == 5)
                tempRssi = get5_2RSSIrange(tempRssi);
            else if (freq == 2)
                tempRssi = get2_4RSSIrange(tempRssi);
            else
                tempRssi = get2_4RSSIrange(tempRssi);

            this.RSSI = tempRssi;
            this.Freq = freq;
        }

        /// <summary>
        /// Convert RSSI to normalized RSSI on 2.4GHz
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short get2_4RSSIrange(short RSSI)
        {
            short retVal = -64;

            if (RSSI >= -64)
                retVal = -64;
            else if (RSSI == -65)
                retVal = RSSI;
            else if (RSSI == -66)
                retVal = RSSI;
            else if (RSSI < -66 && RSSI >= -70)
                retVal = -70;
            else if (RSSI < -70 && RSSI >= -74)
                retVal = -74;
            else if (RSSI < -74 && RSSI >= -77)
                retVal = -77;
            else if (RSSI < -77 && RSSI >= -79)
                retVal = -79;
            else if (RSSI < -79)// && RSSI >= -82)
                retVal = -82;

            return retVal;

        }

        /// <summary>
        /// Convert RSSI to normalized RSSI on 5GHz
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short get5_2RSSIrange(short RSSI)
        {
            short retVal = -61;

            if (RSSI >= -61)
                retVal = -61;
            else if (RSSI == -62)
                retVal = RSSI;
            else if (RSSI == -63)
                retVal = RSSI;
            else if (RSSI < -63 && RSSI >= -67)
                retVal = -67;
            else if (RSSI < -67 && RSSI >= -71)
                retVal = -71;
            else if (RSSI < -71 && RSSI >= -74)
                retVal = -74;
            else if (RSSI < -74 && RSSI >= -76)
                retVal = -76;
            else if (RSSI < -76)// && RSSI >= -79)
                retVal = -79;

            return retVal;

        }
    }
}
