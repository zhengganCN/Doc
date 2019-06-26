# mvc中的登录

## 在Web.config添加配置

    <system.web>
        <authentication mode="Forms">
            <forms loginUrl="~/Account/Login" timeout="2880" />
        </authentication>
        <httpCookies httpOnlyCookies="true" />
    </system.web>

## 需要登录才能访问的控制器

    [Authorize]
    public class HomeController:System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }

## 登录例子

    [HttpPost]
    public ActionResult Login(LoginModel login)
    {
        if (ModelState.IsValid)
        {
            AccountService accountService = new AccountService();
            TbUser loginUser = new TbUser
            {
                UserName = login.UserName,
                Password = login.Password
            };
            var user = accountService.Login(loginUser);
            if (user!=null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    user.UserName, true, 30);//票据，需要加密的信息
                var ticketEncrypt= FormsAuthentication.Encrypt(ticket);//票据加密
                HttpCookie ticketCookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketEncrypt);
                Response.Cookies.Add(ticketCookie);//添加进Cookies
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Info = "登陆失败，账户或密码错误，请重试";
            return View();
        }
        return View();
    }
