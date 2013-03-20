using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExperimentalCMS.Web.BackEnd.Extensions
{
    public static class ErrorMessageExtension
    {
        public static string DebugModeMessageIs(this string liveModeErrorMessage, string debugModeErrorMessage)
        {
#if DEBUG
            return string.Format("DEBUG MODE ERROR: {0}", debugModeErrorMessage);
#else
            return liveModeErrorMessage;
#endif
        }

        public static List<string> DebugModeMessageAre(this string liveModeErrorMessage, List<string> debugModeErrorMessages)
        {

#if DEBUG
            debugModeErrorMessages.Insert(0, "DEBUG MODE ERRORS: ");
            return debugModeErrorMessages;
#else
            return new List<string> { liveModeErrorMessage };
#endif
        }
    }
}