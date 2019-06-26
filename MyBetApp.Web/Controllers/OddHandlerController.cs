using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBetApp.Web.Models;
using MyBetApp.Web.Models.Entities;
using MyBetApp.Web.Repositories.Implementations;
using MyBetApp.Web.Services.Helpers;
using MyBetApp.Web.ViewModels;

namespace MyBetApp.Web.Controllers
{
    [Authorize(Roles = "oddhandler")]
    public class OddHandlerController : Controller
    {
        
        private readonly MyBetAppContext _context;
        public OddHandlerController(MyBetAppContext context)
        {
            _context = context;
        }
        StakesRepository Sr;
        Helpers Hlp;
        //private UserManager<ApplicationUser> _userManager;

        ////class constructor
        //public OddHandlerController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        //public async Task<string> CurrentUser()
        //{
        //    var user = await _userManager.GetUserAsync(User);

        //    //var email = user.Email;

        //    return user.UserName;
        //}
        public JsonResult AllStakes()
        {
            var Username = Hlp.CurrentUser();
            List<Stakes> St = Sr.GetStakes().ToList();

            return Json(St);
        }
      //  public IActionResult Index()
      //  {
            
      //      return View();
      //  }

      //  [HttpPost]
      //  public IActionResult CreateOdd(OddViewModel Ovm)
      //  {

      //      return View();
      //  }
      //[HttpPost]
      //  public IActionResult EditOdd(int Id, OddViewModel Ovm)
      //  {

      //      return View();
      //  }

      //  [HttpPost]
      //  public IActionResult DisableOdd( int Id)
      //  {

      //      return View();
      //  }


        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbOdds.ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new TbOdds());
            else
                return View(_context.TbOdds.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("OddId, GameName,HomeValue,DrawValue,AwayValue,GameDate,StakeAmount,StartTime,EndTime,Status,OddCreator")] TbOdds odds)
        {
            if (ModelState.IsValid)
            {
                if (odds.OddId == 0)
                    _context.Add(odds);
                else
                    _context.Update(odds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odds);
        }
        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var odd = await _context.TbOdds.FindAsync(id);
            _context.TbOdds.Remove(odd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}