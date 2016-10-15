using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.Text;
using System.Web.Configuration;

namespace ZeusWeb.Code.Helpers
{
    public static class Helper
    {
        /// <summary>
        /// Método que filtra os erros lançados por validação de campos do 
        /// Entity Framework
        /// </summary>
        /// <param name="ex">Exceção do Entity</param>
        /// <returns>String contendo a lista de erros detalhada</returns>
        internal static string ViewEntityException(System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            var sb = new StringBuilder();
            foreach (var failure in ex.EntityValidationErrors)
            {
                sb.AppendFormat("{0} falha na validação\n", failure.Entry.Entity.GetType());
                foreach (var error in failure.ValidationErrors)
                {
                    sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Classe que contém os métodos úteis pertinentes a utilização do AppSettings do Web.Config
        /// </summary>
        internal static class WebConfigurations
        {
            /// <summary>
            /// Retorna o valor de um campo no appSettings
            /// </summary>
            /// <param name="SettingName">Nome do campo</param>
            /// <returns>String</returns>
            public static string GetValue(string SettingName)
            {
                return ConfigurationManager.AppSettings[SettingName] ?? string.Empty;
            }

            /// <summary>
            /// Remove o valor de um campo no appSettings
            /// </summary>
            /// <param name="SettingName">Nome do campo</param>
            public static void RemoveValue(string SettingName)
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings.Remove(SettingName);
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }

            /// <summary>
            /// Adiciona o valor de um campo no appSettings
            /// </summary>
            /// <param name="SettingName">Nome do campo</param>
            /// <param name="value">Valor do campo</param>
            public static void AddValue(string SettingName, string value)
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings.Add(SettingName, value);
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }

            /// <summary>
            /// Altera o valor de um campo no appSettings
            /// </summary>
            /// <param name="SettingName">Nome do campo</param>
            /// <param name="value">Valor do campo</param>
            public static void SetValue(string SettingName, string value)
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                if (config.AppSettings.Settings[SettingName] == null)
                    AddValue(SettingName, value);
                else
                {
                    config.AppSettings.Settings[SettingName].Value = value;
                    config.Save();
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }

        internal static DateTime? verificaData(this DateTime date)
        {
            return (date >= (DateTime)SqlDateTime.MinValue) ? date : (DateTime?)null;
        }

        /// <summary>
        /// Método que retorna um alerta html no padrão do bootstrap
        /// conforme parametros de entrada. ATENÇÃO: Para utilização deste recurso
        /// é necessário os arquivos que compõe o contexto do bootstrap (bootstrap.css e bootstrap.js)
        /// devidamente referênciados na página que utilizará o recurso
        /// </summary>
        /// <param name="tipo">Defe o tipo do alerta - 1:Sucesso, 2:Informativo, 3:Atenção e 4:Error</param>
        /// <param name="titulo">Título do alerta</param>
        /// <param name="text">Conteúdo do alerta</param>
        /// <param name="exception">Conteúdo da Exeção caso exista</param>
        /// <returns>Retorna uma string contendo o html do alerta</returns>
        internal static string GetAlertaBootstrapHtml(int tipo, string titulo, string text, string exception)
        {
            StringBuilder sb = new StringBuilder();
            var icone = string.Empty;
            var classe = string.Empty;
            switch (tipo)
            {
                case 1:
                    {
                        classe = "alert-success";
                    }
                    break;
                case 2:
                    {
                        classe = "alert-info";
                    }
                    break;
                case 3:
                    {
                        classe = "alert-warning";
                    }
                    break;
                case 4:
                    {
                        classe = "alert-danger";
                    }
                    break;
                default:
                    {
                        classe = "alert-success";
                    }
                    break;
            }
            sb.Append("<div class='alert " + classe + " alert-dismissible' role='alert'>");
            sb.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            sb.Append(icone + "&nbsp;<strong>" + titulo + "</strong>&nbsp;&nbsp;" + text);
            if (!string.IsNullOrEmpty(exception))
            {
                sb.Append("<br /><br />");
                sb.Append("<div class='panel-group warning' role='tablist' aria-multiselectable='true'>");
                sb.Append("<div class='panel panel-default'>");
                sb.Append("<div class='panel-heading' role='tab' id='headingOneInfo'>");
                sb.Append("<h4 class='panel-title'>");
                sb.Append("<a data-toggle='collapse' data-parent='#accordion' href='#collapseOneInfo' aria-expanded='true' aria-controls='collapseOneInfo' style='font-size:12px'><i class='fa fa-edit'></i>&nbsp;Detalhes");
                sb.Append("</a>");
                sb.Append("</h4>");
                sb.Append("</div>");
                sb.Append("<div id='collapseOneInfo' class='panel-collapse collapse' role='tabpanel' aria-labelledby='headingOneInfo' style='height: 0px;'>");
                sb.Append("<div class='panel-body'>");
                sb.Append(exception);
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
            }
            sb.Append("</div>");
            return sb.ToString();
        }
    }
}