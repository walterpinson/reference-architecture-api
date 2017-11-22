namespace CompanyName.Notebook.NoteTaking.Core.Application.Exceptions
{
    using System;

    public class NoteTakerException : Exception
    {
        public NoteTakerException(string message, Exception innerException=null)
            :base(message, innerException) { }
    }
}