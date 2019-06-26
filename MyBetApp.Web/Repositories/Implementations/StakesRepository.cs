using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using MyBetApp.Web.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBetApp.Web.ViewModels;

namespace MyBetApp.Web.Repositories.Implementations
{

    
    public class StakesRepository : IStakes
    {
        MyBetAppContext db;

        public StakesRepository(MyBetAppContext _db)
        {
            db = _db;
        }

        public Stakes AddNewStake(StakesViewModel Svm)
        {
            throw new NotImplementedException();
        }

        public bool DisableOdd(int StakeID)
        {
            throw new NotImplementedException();
        }

        public Stakes EditOdd(StakesViewModel Svm, int Id)
        {
            throw new NotImplementedException();
        }

        public Stakes GetStakeByID(int OddID)
        {
            throw new NotImplementedException();
        }

        public List<Stakes> GetStakes()
        {
            throw new NotImplementedException();
        }

        //MyBetAppContext db = new MyBetAppContext();

    }
}
