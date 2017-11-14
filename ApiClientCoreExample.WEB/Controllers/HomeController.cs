using ApiClientCoreExample.BLL.DTO;
using ApiClientCoreExample.BLL.Infrastructure;
using ApiClientCoreExample.BLL.Interfaces;
using ApiClientCoreExample.WEB.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiClientCoreExample.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IMinerService minerService;
        IUserService userService;

        public HomeController(IMinerService minerServ, IUserService userService)
        {
            this.minerService = minerServ;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CurrentStatsAsync()
        {
            var userName = HttpContext.User.Identity.Name;
            var userMiner = await userService.GetUsersMiner(userName);

            DateTime now = DateTime.Now;
            DataDTO dataDTO;


            ViewBag.userMiner = userMiner;
            ViewBag.currentTime =  now;

            CurrentStatsViewModel stats = null;
            try
            {
                dataDTO = await minerService.GetCurrentStats(userMiner);
            }
            catch (BusinessLogicException ex)
            {
                return RedirectToAction("Error", new {message = ex.Message});
            }

            stats = Mapper.Map<DataDTO, CurrentStatsViewModel>(dataDTO);

            return PartialView(stats);
        }

        public string Error(string message)
        {
            return $"<h3 class='text-danger'>api.ethermine.org error: {message}</h3>";
        }
    }
}
