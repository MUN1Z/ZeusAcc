using System;

namespace ZeusWeb.Code.Exceptions
{
    /// <summary>
    /// Classe utilizada para filtro das exceções geradas para o contexto de operações
    /// </summary>
    public class OperacaoException : Exception
    {
        public OperacaoException() { }
        public OperacaoException(string message) : base(message) { }
        public OperacaoException(string message, Exception inner) : base(message, inner) { }
    }

    public class OperacaoDetCampanhaException : Exception
    {
        public OperacaoDetCampanhaException() { }
        public OperacaoDetCampanhaException(string message) : base(message) { }
        public OperacaoDetCampanhaException(string message, Exception inner) : base(message, inner) { }
    }
}