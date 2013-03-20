using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.Domain.Utility
{
    public class DomainResponse<T> where T : class
    {
        public bool Success { get; set; }
        public int ResponseCode { get; set; }
        public List<string> Messages { get; set; }
        public T Result { get; set; }

        public DomainResponse()
        {
            Messages = new List<string>();
        }

        public DomainResponse<T> ReturnSuccessResponse(T detail, IEnumerable<string> debugModeMessage, string liveModeMessage)
        {
            debugModeMessage = debugModeMessage ?? new string[] { };
            liveModeMessage = liveModeMessage ?? string.Empty;

            Success = true;
            Result = detail;
            ResponseCode = 0;

#if DEBUG
            Messages.AddRange(debugModeMessage);
#else
            Messages.Add(liveModeMessage);
#endif
            return this;
        }

        public DomainResponse<T> ReturnFailResponse(IEnumerable<string> debugModeMessage, string liveModeMessage, T detail = null)
        {
            Success = false;
            Result = null;
            ResponseCode = 0;
#if DEBUG
            Messages.AddRange(debugModeMessage);
#else
            Messages.Add(liveModeMessage);
#endif
            return this;
        }
    }
}
