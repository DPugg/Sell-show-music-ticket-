namespace Band.ViewModels.Common
{
    public class PayingRequest
    {
        public string SrcAccount { get; set; }
        public string DesAccount { get; set; }
        public string Password { get; set; }
        public decimal Payment { get; set; }


    }
}