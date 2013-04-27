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
        /// RSSI of this device
        /// </summary>
        public double   RSSI { set; get; }

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
        public string   Band { set; get; }
        
        /// <summary>
        /// BSSID
        /// </summary>
        public string   BSSID { set; get; }
        #endregion


    }
}
