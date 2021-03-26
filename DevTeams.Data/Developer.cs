using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.Data //POCOs go in .Data 
{
    
    public class Developer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public bool HasPluralsight { get; set; }

        public Developer()
        {

        }

        public Developer(string firstName, string lastName, bool hasPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
        }

    }
}
