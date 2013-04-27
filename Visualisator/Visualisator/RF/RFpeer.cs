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

        #region Noise
        /// <summary>
        /// Noise Level
        /// </summary>
        public double   NoiseLevel { set; get; }

        /// <summary>
        /// Effect of distance between us and the device that we working with it currently
        /// </summary>
        public double NoiseRSSI { set; get; }
        /// <summary>
        /// Effect of noise of devices working on the same channel as our channel but in other BSSS
        /// </summary>
        public double NoiseOnSameChannel { set; get; }

        /// <summary>
        /// Effect of noise of device working on the nearest channels. Example: if we on channel 6 so the nearest channel is 5,7
        /// </summary>
        public double NoiseNearestChannels { set; get; }

        /// <summary>
        /// Effect of noise of device working on the near channels. Example: if we on channel 6 so the nearest channel is 4,8
        /// </summary>
        public double NoiseNeartChannels { set; get; }
        #endregion
    }
}
