using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using MyBetApp.Web.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Repositories.Implementations
{
    public class OddValuesRepository : IOddValue
    {
        public OddValue AddNewOdd(OddValueViewModel Gvm)
        {
            throw new NotImplementedException();
        }

        public bool DisableGame(int OddID)
        {
            throw new NotImplementedException();
        }

        public OddValue EditOdd(OddValueViewModel Gvm, int Id)
        {
            throw new NotImplementedException();
        }

        public OddValue GetOddByID(int GameID)
        {
            throw new NotImplementedException();
        }

        public List<OddValue> GetOddValues()
        {
            throw new NotImplementedException();
        }
    }
}
