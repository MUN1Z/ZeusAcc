using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ZeusWeb.Code.Controllers;
using ZeusWeb.Code.Helpers;
using ZeusWeb.Code.Models;

namespace ZeusWeb
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {

        private JavaScriptSerializer serializador = new JavaScriptSerializer();

        public void ProcessRequest(HttpContext context)
        {
            var method = context.Request.Params["method"].ToString();
            switch (method)
            {

                case "PersistConta":
                    PersistAccount(context);
                    break;

                case "GetAllAccounts":
                    GetAllAccounts(context);
                    break;

            }
        }

        /// <summary>
        /// Método que busca todas as contas cadastradas no banco de dados
        /// </summary>
        /// <param name="context">Contexto da requisição</param>
        private void GetAllAccounts(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            serializador.MaxJsonLength = Convert.ToInt32(Helper.WebConfigurations.GetValue("maxJsonLength"));
            //context.Response.Write(serializador.Serialize(OperacaoFinanceiraController.GetInstance().GetAllOperadoraDeCartaoByDominio(dominio.DOMINIO_COD)));
        }

        /// <summary>
        /// Método que cadastra uma conta no banco de dados
        /// </summary>
        /// <param name="context">Contexto da requisição</param>
        private void PersistAccount(HttpContext context)
        {
            try
            {
                var account = context.Request.QueryString["account"];
                
                Account conta = serializador.Deserialize<Account>(account);

                AccountController.GetInstance().PersistAccount(conta);
               
                context.Response.ContentType = "text/json";
                //serializador.MaxJsonLength = Convert.ToInt32(Helper.WebConfigurations.GetValue("maxJsonLength"));
                context.Response.Write(serializador.Serialize(Helper.GetAlertaBootstrapHtml(1, "", "Conta cadastrada com sucesso!", null)));

            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/json";
                //serializador.MaxJsonLength = Convert.ToInt32(Helper.WebConfigurations.GetValue("maxJsonLength"));
                context.Response.Write(serializador.Serialize(Helper.GetAlertaBootstrapHtml(4, "", "Erro ao cadastrar conta!", ex.Message)));

            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}