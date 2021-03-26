using DevTeams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRepository
{
    public class DeveloperRepo
    {
        //we want to create our fake database
        private readonly List<Developer> _devDatabase = new List<Developer>();

        //we need a _count to hold our autoImplemented ID values
        private int _count = 0;

        //C.R.U.D
        
        //Create
        public bool AddDeveloperToDatabase(Developer developer)
        {
            _count++;
            developer.ID = _count;
            _devDatabase.Add(developer);
            return true;
        }

        //Read -> Get All
        public List<Developer> GetDevelopers()
        {
            return _devDatabase;
        }
        //Read -> Get by id is the helper method!!!
        public Developer GetDeveloperById(int ID)
        {
            foreach (var dev in _devDatabase)
            {
                if (dev.ID==ID)
                {
                    return dev;
                }
            }
            return null;
        }

        //update
        public bool UpdateDev(int oldDevId, Developer newDevInfo)
        {
            //we need to the the oldDev stuff...
            //use helper method...
            Developer oldDev = GetDeveloperById(oldDevId);
            if (oldDev == null)
            {
                return false;
            }
            else
            {
                oldDev.FirstName = newDevInfo.FirstName;
                oldDev.LastName = newDevInfo.LastName;
                oldDev.HasPluralsight = newDevInfo.HasPluralsight;

                return true;
            }
        }

        //delete
        public bool DeleteDev(int id)
        {
            foreach (var dev in _devDatabase)
            {
                if (dev.ID ==id)
                {
                    _devDatabase.Remove(dev);
                    return true;
                }
            }
            return false;
        }

        public List<Developer> GetDevsWithPluralsight()
        {
            List<Developer> devsWithPs = new List<Developer>();

            foreach (var dev in _devDatabase)
            {
                if (dev.HasPluralsight)
                {
                    devsWithPs.Add(dev);
                }
            }

            return devsWithPs;
        }

    }   
}
