using DevTeams.Data.ENUMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.Data
{
    public class DevTeam
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public List<Developer> Developers { get; set; } = new List<Developer>();

        public TeamDepartments TeamDepartment { get; set; }

        public DevTeam()
        {

        }

        public DevTeam(string teamName,TeamDepartments teamDepartment,List<Developer> developers)
        {
            TeamName = teamName;
            TeamDepartment = teamDepartment;
            Developers = developers;
        }
    }
}
