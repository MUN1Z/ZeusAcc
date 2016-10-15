using System.Text;

namespace ZeusWeb.Code.Helpers
{
    public class Helper
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

    }
}