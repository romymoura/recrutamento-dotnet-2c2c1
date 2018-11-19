using System.Collections.Generic;
using _7COMm.Recrutamento.CrossCuting.Enuns;

namespace _7COMm.Recrutamento.CrossCuting.Response
{
    public class ResultDTO
    {
        public long? IdLogEntry { get; set; }

        public ReturnExecution ReturnExecution { get; set; }

        public List<ErrorResultDTO> Errors { get; set; }

    }
}
