using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelf.Models
{
    public interface IVaild
    {
        void IsVaild();
        IEnumerable<VaildMessage> GetErrorMessages();
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
