using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Repositories.Abstracts
{
    public interface IOddValue
    {
        List<OddValue> GetOddValues();
        OddValue GetOddByID(int GameID);

        OddValue AddNewOdd(OddValueViewModel Gvm);

        OddValue EditOdd(OddValueViewModel Gvm, int Id);

        bool DisableGame(int OddID);
    }
}
