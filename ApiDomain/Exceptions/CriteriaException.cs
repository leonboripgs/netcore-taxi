using System;

namespace ApiDomain.Exceptions
{
    public class CriteriaException : Exception
    {
        public override string Message => "Ocurrio un error en la especificación del criterio de búsqueda.";

        public CriteriaException() { }
        public CriteriaException(string message) : base(message) { }
        public CriteriaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
