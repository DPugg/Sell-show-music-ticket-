namespace Bank.Api.Services
{
    public class GetBalanceRequest
    {
        public string BankAccount { get; set; }
        public decimal Payment { get; set; }
    }
}