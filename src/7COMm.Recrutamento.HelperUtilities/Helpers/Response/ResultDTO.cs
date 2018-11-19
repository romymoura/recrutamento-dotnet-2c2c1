using System.Collections.Generic;
using _7COMm.Recrutamento.HelperUtilities.Enuns;

namespace _7COMm.Recrutamento.HelperUtilities.Response
{
    public class ResultDTO
    {
        public long? IdLogEntry { get; set; }

        public ReturnExecution ReturnExecution { get; set; }

        public List<ErrorResultDTO> Errors { get; set; }

    }
}
