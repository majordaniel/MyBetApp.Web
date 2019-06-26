using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using MyBetApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Repositories.Abstracts
{
    public interface IOdds
    {

        List<TbOdds> GetOdds();
        TbOdds GetOddByID(int OddID);

        TbOdds AddNewOdd(OddViewModel Oddvm);

        TbOdds EditOdd(OddViewModel Oddvm, int Id);

        bool DisableOdd(int OddID);
    }
}
