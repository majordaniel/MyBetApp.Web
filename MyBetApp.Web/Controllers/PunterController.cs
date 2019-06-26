using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using MyBetApp.Web.Repositories.Implementations;
using MyBetApp.Web.Services.Helpers;
using MyBetApp.Web.ViewModels;

namespace MyBetApp.Web.Controllers
{
    [Authorize(Roles = "punter")]
    public class PunterController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
      private readonly IHttpContextAccessor _httpContextAccessor;

        StakesRepository Sr;
        OddsRepository Or;
        MyBetAppContext db = new MyBetAppContext();
        public PunterController( )
        {
            //IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager,OddsRepository oddsRepository
            //_httpContextAccessor = httpContextAccessor;
            //Or = oddsRepository;
            //_userManager = userManager;

        }
        public IActionResult Index()
        {
            //List<OddViewModel> OddsLIst = db.TbOdds.Select(x => new OddViewModel
            //{
            //    AwayValue = x.AwayValue,
            //    DrawValue = x.DrawValue,
            //    EndTime = x.EndTime,
            //    GameDate = x.GameDate,
            //    GameName = x.GameName,
            //    HomeValue = x.HomeValue,
            //    OddCreator = x.OddCreator,
            //    OddId = x.OddId,
            //    StakeAmount = x.StakeAmount,
            //    StartTime = x.StartTime,
            //    Status = x.Status
            //}).ToList();
            //ViewBag.OddLists = OddsLIst;
            return View();
        }

        //public IActionResult GetOddsList()
        //{

        //    return View();
        //}
        public JsonResult GetOddsList()
        { 
            //List<OddViewModel> OddsLIst = Or.GetOdds().Select(x => new OddViewModel
            List<OddViewModel> OddsLIst =db.TbOdds.Select(x => new OddViewModel
            {
                AwayValue = x.AwayValue,
                DrawValue = x.DrawValue,
                EndTime = x.EndTime,
                GameDate = x.GameDate,
                GameName = x.GameName,
                HomeValue = x.HomeValue,
                OddCreator = x.OddCreator,
                OddId = x.OddId,
                StakeAmount = x.StakeAmount,
                StartTime = x.StartTime,
                Status = x.Status
            }).ToList();
            //ViewBag.OddLists = OddsLIst;
             return new JsonResult(OddsLIst);
           
        }

        [HttpPost]
        public  JsonResult SaveNewStakeAsync(StakesViewModel IncStakeData)
        {
           // object userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = await _userManager.GetUserAsync(User);
            bool Resp = false;
            // var email = user.Email;
            Helpers hlp;
       
            using (MyBetAppContext db = new MyBetAppContext())
            {
                TbStakes sT = new TbStakes
                {
                   // UserID = hlp.CurrentUser(),
                    TotalStakeAmount = IncStakeData.Stakes.TotalStakeAmount
                };
                db.TbStakes.Add(sT);
                db.SaveChanges();
                foreach (var item in IncStakeData.StakesDetails)
                {
                    item.StakeID = sT.StakeID;
                    db.TbStakeDetails.Add(item);
                };
                db.SaveChanges();
                Resp = true;
            }


            return Json(new {Result = Resp });
        }
    }
}