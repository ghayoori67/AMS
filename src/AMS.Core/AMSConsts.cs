using AMS.Debugging;

namespace AMS
{
    public class AMSConsts
    {
        public const string LocalizationSourceName = "AMS";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        public const string MellatGateay = "";
        public const string VirtualGateway = "/MyVirtualGateway";

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "2928e03ecb894586b59597a8dbcfe297";
    }
}
