using DevTeams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRepository
{
    public class DevTeamRepo
    {
        // make a fake database...
        private readonly List<DevTeam> _devTeamDatabase = new  List<DevTeam>();
       // private readonly Queue<DevTeam>
       // private readonly Dictionary<int,string>


        private int _Count = 0;

        //create
        public bool AddTeamToDatabase(DevTeam devTeam)
        {
            _Count++;
            devTeam.ID = _Count;
            _devTeamDatabase.Add(devTeam);
            return true;
        }

        //read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeamDatabase;
        }
    }
}
