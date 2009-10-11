using System;
using System.Runtime.Serialization;

namespace BookShelf.Models
{
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
}