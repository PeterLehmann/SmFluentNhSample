using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BookShelf.Models
{
    public interface IVaild
    {
        void IsVaild();
        IEnumerable<VaildMessage> GetErrorMessages();
    }

    [Serializable]
    public class VaildException : Exception
    {
        public VaildException() {}
        public VaildException(string message) : base(message) {}
        public VaildException(string message, Exception inner) : base(message, inner) {}

        protected VaildException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {}
    }

    public class VaildMessage
    {
        public VaildMessage(string property, string errorMessage)
        {
            if (property == null) throw new ArgumentNullException("property");
            if (errorMessage == null) throw new ArgumentNullException("errorMessage");
            Property = property;
            ErrorMessage = errorMessage;
        }

        public string Property
        {
            get; private set;
        }

        public string ErrorMessage { get; private set; }
    }
}
