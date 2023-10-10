using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Wab.Areas.UserPanel.Controllers
{
      [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {
        private IUserService _userService;
        public WalletController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
            ViewBag.ListWallet = _userService.GetWalletUser(User.Identity.Name);
            return View();
        }

        [Route("UserPanel/Wallet")]
        [HttpPost]
        public ActionResult Index(ChargeWalletViewModel charge)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ListWallet = _userService.GetWalletUser(User.Identity.Name);
                return View(charge);

            }

            _userService.ChargeWallet(User.Identity.Name,charge.Amount,"SharzheHEsab");
            //TODO oNLINE pAYMENT
            return null;
        }
    }
}
