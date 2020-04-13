namespace ISSCFG.Models
{
    public class ErrorViewModel
    {        
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string UserMessage { get; set; }

        public string StackTrace { get; set; }
    }
}
