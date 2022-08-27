using Band.Data.EF;
using Band.ViewModels.Common;
using Bank.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Bank.Api.BankServices
{
    public class BankService : IBankService
    {
        private readonly BandDbContext _context;

        public BankService(BandDbContext context)
        {
            _context = context;
        }
        public int GetBalance(GetBalanceRequest request)
        {
            var acc = _context.BankDbo.Find(request.BankAccount);
            if (acc == null) return (int)BankErrorCode.LOGIN_FAILED;
            if (acc.SoDu < request.Payment) return (int)BankErrorCode.BALANCE_NOT_ENOUGH;
            else return 1;
        }

        public async Task<int> CreateTransaction(PayingRequest request)
        {
            var srcAcc = await _context.BankDbo.FindAsync(request.SrcAccount);
            if (srcAcc == null) return (int)BankErrorCode.LOGIN_FAILED;


            var desAcc = await _context.BankDbo.FindAsync(request.DesAccount);

            if (desAcc == null) return (int)BankErrorCode.INCORRECT_DES_ACC; //Sai tài khoản bên nhận
            else
            {
                if (srcAcc.SoDu < request.Payment) return (int)BankErrorCode.BALANCE_NOT_ENOUGH;
                else
                {
                    srcAcc.SoDu -= request.Payment;
                    desAcc.SoDu += request.Payment;
                    return await _context.SaveChangesAsync();
                }
            }

        }
        public string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
