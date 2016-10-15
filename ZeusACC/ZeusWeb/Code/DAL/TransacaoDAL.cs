using System;
using ZeusWeb.Code.DataModel;

namespace ZeusWeb.Code.DAL
{
    public class TransacaoDAL
    {
        /// <summary>
        /// Método que inicia uma Transacao
        /// </summary>
        /// <param name="rec">Requisição a ser alterada</param>
        internal static ZeusDataSource GetTransaction()
        {
            var ctx = new ZeusDataSource();
            var transaction = ctx.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            return ctx;
        }

        /// <summary>
        /// Método que commita a transacao
        /// </summary>
        /// <param name="rec">Requisição a ser alterada</param>
        internal static void CommitTransaction(ref ZeusDataSource ctx)
        {
            try
            {
                if (ctx != null)
                {
                    ctx.SaveChanges();
                    ctx.Database.CurrentTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                ctx.Database.CurrentTransaction.Rollback();
                throw ex;
            }
            finally
            {
                try
                {
                    ctx.Dispose();
                }
                catch { }
                finally
                {
                    ctx = null;
                }
            }

        }
        /// <summary>
        /// Método que Aplica o rollback na transacao
        /// </summary>
        /// <param name="rec">Requisição a ser alterada</param>
        internal static void RollBackTransaction(ref ZeusDataSource ctx)
        {
            try
            {
                if (ctx != null)
                {
                    ctx.Database.CurrentTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    ctx.Dispose();
                }
                catch { }
                finally
                {
                    ctx = null;
                }
            }

        }


    }
}