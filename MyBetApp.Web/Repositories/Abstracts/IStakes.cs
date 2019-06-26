using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBetApp.Web.ViewModels;

namespace MyBetApp.Web.Repositories.Abstracts
{
   public interface IStakes
    {
      List<Stakes> GetStakes();
        Stakes GetStakeByID(int OddID);

        Stakes AddNewStake(StakesViewModel Svm);

        Stakes EditOdd(StakesViewModel Svm, int Id);

        bool DisableOdd(int StakeID);
    }
}
