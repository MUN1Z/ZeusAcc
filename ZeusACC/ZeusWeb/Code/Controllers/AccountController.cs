using System;
using System.Collections.Generic;
using System.Data.Entity;
using ZeusWeb.Code.DAL;
using ZeusWeb.Code.DataModel;
using ZeusWeb.Code.Exceptions;
using ZeusWeb.Code.Helpers;
using ZeusWeb.Code.Models;

namespace ZeusWeb.Code.Controllers
{
    public class AccountController
    {
        private static AccountController _instancia = null;

        private ZeusDataSource _transaction = null;
        private void CommitTransaction()
        {
            TransacaoDAL.CommitTransaction(ref _transaction);
        }
        private void RollBackTransaction()
        {
            TransacaoDAL.RollBackTransaction(ref _transaction);
        }

        /// <summary>
        /// Construtor privado
        /// </summary>
        private AccountController() { }

        /// <summary>
        /// Método que busca a instância ativa da classe
        /// </summary>
        /// <returns>Retorna uma instância da classe</returns>
        internal static AccountController GetInstance()
        {
            if (_instancia == null)
                _instancia = new AccountController();
            return _instancia;
        }

        internal List<Account> GetAllAccounts()
        {
            return AccountDAL.getAllAccounts();
        }

        internal Account getAccountByID(int contaID)
        {
            return AccountDAL.getAccountByID(contaID);
        }

        internal bool PersistAccount(Account conta)
        {
            try
            {
                _transaction = TransacaoDAL.GetTransaction();

                EntityState entityState = EntityState.Modified;

                Account contaDB = AccountDAL.getAccountByID(conta.ID);

                if (contaDB == null)
                    entityState = EntityState.Added;

                AccountDAL.persistAccount(conta, entityState, _transaction);

                CommitTransaction();

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                RollBackTransaction();
                throw new OperacaoException(Helper.ViewEntityException(ex));
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw ex;
            }

        }

        internal bool DeleteAccount(Account conta)
        {
            try
            {
                _transaction = TransacaoDAL.GetTransaction();

                EntityState entityState = EntityState.Deleted;

                AccountDAL.persistAccount(conta, entityState, _transaction);

                CommitTransaction();

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                RollBackTransaction();
                throw new OperacaoException(Helper.ViewEntityException(ex));
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw ex;
            }
        }

    }
}