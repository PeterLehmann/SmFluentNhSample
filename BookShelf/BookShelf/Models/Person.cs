using System;

namespace BookShelf.Models
{
    public class Person
    {
        private Person()
        {
        }

        public Person(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentNullException("firstName");
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentNullException("lastName");
            PersonId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid PersonId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
