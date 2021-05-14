using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TabelaFIPE.Application.Exceptions
{
    public class VeiculoException : Exception
    {
        public VeiculoException()
        {
        }

        public VeiculoException(string message) : base(message)
        {
        }

        public VeiculoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VeiculoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
