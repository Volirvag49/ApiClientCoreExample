using ApiClientCoreExample.BLL.DTO;
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

        public async Task<PartialViewResult> CurrentStatsAsync()
        {
            var userName = HttpContext.User.Identity.Name;
            var userMiner = await userService.GetUsersMiner(userName);

            DateTime now = DateTime.Now;


            ViewBag.userMiner = userMiner;
            ViewBag.currentTime =  now;

            CurrentStatsViewModel stats = null;
            var statsDTO = await minerService.GetCurrentStats(userMiner);

            stats = Mapper.Map<DataDTO, CurrentStatsViewModel>(statsDTO);

            return PartialView(stats);
        }    
    }
}
