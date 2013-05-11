using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator
{
    internal enum Bandwidth
    {
        _20MHz,
        _40Mhz,
    };

    /**
 * 0 = anything
 * 1 = TDLSSetup Request Sended
 * 2 = TDLSSetup Request Received
 * 3 = TDLSSetup Response Sened
 * 4 = TDLSSetup Response Received
 * 5 = TDLSSetup Confirm Sended
 * 6 = TDLSSetup Confirm Received
 */

    internal enum TDLSSetupStatus
    {
        TDLSSetupDisabled = 0,
        TDLSSetupRequestSended,
        TDLSSetupRequestReceived,
        TDLSSetupResponseSened,
        TDLSSetupResponseReceived,
        TDLSSetupConfirmSended,
        TDLSSetupConfirmReceived
    };

}
