using System;
using System.Security.Cryptography;
using System.Text;

namespace FaxiApiNetCore.Helpers
{
    public class StringHelper
    {
        /// <summary>
        /// Obtiene el mensaje de error completo de una expeción
        /// </summary>
        /// <param name="ex">Excepcion que contiene los errores generados</param>
        /// <returns>Cadena con los mensajes de error concatenados</returns>
        public static string GetStringessageException(Exception ex)
        {
            if (ex == null) return string.Empty;

            var fullMessage = ex.Message;
            if (ex.InnerException != null)
                fullMessage += $"{Environment.NewLine}{GetStringessageException(ex.InnerException)}";

            return fullMessage;
        }
        public static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1.Create();
            var textOriginal = Encoding.Default.GetBytes(texto);
            var hash = sha1.ComputeHash(textOriginal);
            var cadena = new StringBuilder();
            foreach (var i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
        public static string Capitalize(string fieldName)
        {
            var result = string.Empty;
            foreach (var itemString in fieldName.Split('_'))
            {
                var capitalizedItem = itemString.ToLower();
                result += capitalizedItem[0].ToString().ToUpper() + capitalizedItem.Substring(1);
            }
            return result;
        }

        public static string TypeToString(Type type)
        {
            var typeProperty = type.ToString().ToLower().Replace("system.", string.Empty);
            switch (typeProperty)
            {
                case "int32":
                    typeProperty = "int";
                    break;
                case "int64":
                    typeProperty = "long";
                    break;
                case "datetime":
                    typeProperty = "DateTime";
                    break;
            }

            return typeProperty;
        }
    }
}
