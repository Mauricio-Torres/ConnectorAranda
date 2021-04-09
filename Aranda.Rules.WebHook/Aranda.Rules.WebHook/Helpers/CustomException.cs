using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aranda.Rules.WebHook.Helpers
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