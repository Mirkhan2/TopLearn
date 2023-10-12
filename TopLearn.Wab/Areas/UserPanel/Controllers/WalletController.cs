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

          int walletId =  _userService.ChargeWallet(User.Identity.Name,charge.Amount,"SharzheHEsab");
            //TODO oNLINE pAYMENT


            #region Online Payement

            var payment = new ZarinPalSandbox.Payement(charge.Amount);

            var res = payment.PayementRequest("sharzhe KifePul", "https://localhost:44348/OnlinePayment/" + walletId , "Info@topLearn.Com" , "09146788445" );

            if (res.Result.Status = 100)
            {
                Response.Redirect("http://sandbox.zarinpal.com/pg/SartPay/ "+res.Result.Authority);
            }

            #endregion
            return null;
        }
    }
}
