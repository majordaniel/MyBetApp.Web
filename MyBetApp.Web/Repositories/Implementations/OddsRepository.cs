using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using MyBetApp.Web.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBetApp.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MyBetApp.Web.Repositories.Implementations
{
    public class OddsRepository : IOdds
    {
        MyBetAppContext db;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public OddsRepository(IHttpContextAccessor httpContextAccessor, MyBetAppContext _db)
        {
            _httpContextAccessor = httpContextAccessor;
            db = _db;
        }
        // string d = User.GetUserId()
        public TbOdds AddNewOdd(OddViewModel Oddvm)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            TbOdds odds = new TbOdds
            {
                GameName = Oddvm.GameName,

                AwayValue = Oddvm.AwayValue,
                DrawValue = Oddvm.DrawValue,
                EndTime = Oddvm.EndTime,
                GameDate = Oddvm.GameDate.Date,
                 HomeValue = Oddvm.HomeValue,
                  OddCreator =userId,
                   StakeAmount = Oddvm.StakeAmount,
                    StartTime =Oddvm.StartTime,
                Status = true
            };
            
            db.TbOdds.Add(odds);

            db.SaveChanges();
            return odds;
        }

        public bool DisableOdd(int OddID)
        {
            bool Response = false;
            var qt = db.TbOdds.Where(temp => temp.OddId == OddID).FirstOrDefault();
            if (qt != null)
            {
                qt.Status = false;

                db.SaveChanges();
            }
            return Response;
        }

        public TbOdds EditOdd(OddViewModel Oddvm, int Id)
        {
            var reqOdd = GetOddByID(Id);
            if (reqOdd == null)
            {
                return null;
            }
            reqOdd.StakeAmount = Oddvm.StakeAmount;
            reqOdd.StartTime = Oddvm.StartTime;
            reqOdd.EndTime = Oddvm.EndTime;
            reqOdd.DrawValue = Oddvm.DrawValue;
            reqOdd.AwayValue = Oddvm.AwayValue;
            reqOdd.HomeValue = Oddvm.HomeValue;
            reqOdd.GameName = Oddvm.GameName;
            reqOdd.GameDate = Oddvm.GameDate;
            

            var updateOp = db.Update(reqOdd);
            if (db.SaveChanges() > 0)
            {
                var game = new TbOdds
                {
                     OddId = reqOdd.OddId,
                    GameName = reqOdd.GameName,
                    GameDate = reqOdd.GameDate,
                     AwayValue = reqOdd.AwayValue,
                      HomeValue= reqOdd.HomeValue,
                       DrawValue= reqOdd.DrawValue,
                        EndTime= reqOdd.EndTime,
                         StartTime= reqOdd.StartTime,
                          OddCreator= reqOdd.OddCreator,
                           StakeAmount= reqOdd.StakeAmount,
                            Status= reqOdd.Status
                };
                return game;
            }
            return null;
        }

        public TbOdds GetOddByID(int OddID)
        {
            TbOdds qt = db.TbOdds.Where(temp => temp.OddId == OddID).FirstOrDefault();
            return qt;
        }

        public List<TbOdds> GetOdds()
        {
            var game = new List<TbOdds>();
            var cgame = db.TbOdds;
            if (cgame != null)
            {
                foreach (var gm in cgame)
                {
                    game.Add(gm);
                }
            }
            return game;
        }
    }
}
