// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System;

namespace Aranda.Connector.Api.Helpers
{
    public class CustomException : Exception
    {
        public CustomException(string message)
            : base(message) { }

        public CustomException(string message, Exception inner)
            : base(message, inner) { }

        public string ErrorMessage { get; }
    }
}