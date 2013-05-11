using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator
{
    [Serializable()]
    class RFpeer : ISerializable
    {

        #region Summary
        /// <summary>
        /// Mac address
        /// </summary>
        public string   MAC { set; get; }

        /// <summary>
        /// Counter of retransmitions
        /// </summary>
        public short    RetransmitionCounter { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public long TransmitCounter { set; get; }

        /// <summary>
        /// RSSI of this device
        /// </summary>
        public short   RSSI { set; get; }

        /// <summary>
        /// Distance to this device
        /// </summary>
        public double   Distance { set; get; }

        /// <summary>
        /// Operating channel
        /// </summary>
        public short    Channel { set; get; }
        
        /// <summary>
        /// Band of device Example: A or N
        /// </summary>
        public Frequency Freq { set; get; }

        /// <summary>
        /// 802.11 standart used by peer device
        /// </summary>
        public Standart80211 Stand80211 { set; get; }

        /// <summary>
        /// Bandwidth of the peer device
        /// </summary>
        public Bandwidth BandWidth { set; get; }
        
        /// <summary>
        /// BSSID
        /// </summary>
        public string   BSSID { set; get; }

        /// <summary>
        /// Show if device active or passive now
        /// </summary>
        public bool isPassive { set; get; }
        #endregion


    }
}
