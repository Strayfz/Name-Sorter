using System;
using System.Linq;

namespace NameSorter
{
    // The Person class is created to simplify sorting operations.

    public class Person : IComparable<Person>
    {
        private string FullName;
        private string LastName;
        private string GivenNames;

        public Person(string fullName)
        {
            this.FullName = fullName;
            this.LastName = fullName.Split(' ').Last();
            this.GivenNames = fullName.Substring(0, fullName.Length - LastName.Length);
        }

        // This method allows each person object to be sorted by last name and given names.
        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            // If last names are the same, given names are checked.
            if (this.LastName.CompareTo(other.LastName) == 0)
            {

                if (this.GivenNames.CompareTo(other.GivenNames) == 1)
                {
                    return 1;
                }
                return -1;
            }
            if (this.LastName.CompareTo(other.LastName) == 1)
            {
                return 1;
            }
            return -1;
        }
        public override string ToString()
        {
            return this.FullName;
        }

    }
}
