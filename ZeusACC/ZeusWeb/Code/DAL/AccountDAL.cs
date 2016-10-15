using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZeusWeb.Code.DataModel;
using ZeusWeb.Code.Models;

namespace ZeusWeb.Code.DAL
{
    public class AccountDAL
    {
        internal static List<Account> getAllAccounts()
        {
            using (var ctx = new ZeusDataSource())
            {
                return ctx.accounts
                    .Select(conta => new Account
                {
                    BLOKED = conta.BLOKED,
                    EMAIL = conta.EMAIL,
                    GROUPID = conta.GROUPID,
                    ID = conta.ID,
                    KEY = conta.KEY,
                    LASTDAY = conta.LASTDAY,
                    NAME = conta.NAME,
                    PASSWORD = conta.PASSWORD,
                    PREMDAYS = conta.PREMDAYS,
                    WARNINGS = conta.WARNINGS
                }).ToList();
            }
        }

        internal static Account getAccountByID(int contaID)
        {
            using (var ctx = new ZeusDataSource())
            {
                return ctx.accounts
                    .Where(conta => conta.ID.Equals(contaID))
                    .Select(conta => new Account
                    {
                        BLOKED = conta.BLOKED,
                        EMAIL = conta.EMAIL,
                        GROUPID = conta.GROUPID,
                        ID = conta.ID,
                        KEY = conta.KEY,
                        LASTDAY = conta.LASTDAY,
                        NAME = conta.NAME,
                        PASSWORD = conta.PASSWORD,
                        PREMDAYS = conta.PREMDAYS,
                        WARNINGS = conta.WARNINGS
                    }).FirstOrDefault();
            }
        }

        internal static void persistAccount(Account conta, EntityState entityState, ZeusDataSource _transaction)
        {

            accounts obj = new accounts
            {
                BLOKED = conta.BLOKED,
                EMAIL = conta.EMAIL,
                GROUPID = conta.GROUPID,
                ID = conta.ID,
                KEY = conta.KEY,
                LASTDAY = conta.LASTDAY,
                NAME = conta.NAME,
                PASSWORD = conta.PASSWORD,
                PREMDAYS = conta.PREMDAYS,
                WARNINGS = conta.WARNINGS
            };

            _transaction.Entry<accounts>(obj).State = entityState;

        }
    }
}