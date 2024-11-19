using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimFinancial.Api.UnitTest.Fixtures;

    public class TransactionFixture
    {
        public static string GetTransactionByAccount()
        {

            var acct =  new Account
            {
                AccountNumber = 1115654848
            };
            return acct.AccountNumber.ToString();
        }

        public static TransactionReqDto CreateTransaction()
        {
            return new TransactionReqDto
            {
                SourceAcctNumber = "115566984588",
                DestinationAccountNumber = "155288974569",
                TransactionAmount = 100,
                Description = "Test Description"
            };
        }
    }

