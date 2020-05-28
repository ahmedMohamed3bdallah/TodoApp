using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string name, object key, string message) : base(
            $"Delete of entity \"{name} \"({key}) failed. {message}")
        {

        }
    }
}
