# 实现权限验证

    /// <summary>
    /// 权限筛选器，用于判断登录用户是否具有权限访问控制器或方法
    /// </summary>
    public class AuthValidation: ActionFilterAttribute
    {
        private readonly AuthType _authType;
        public AuthValidation(AuthType authType)
        {
            _authType = authType;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //获取票据并解密，获取保存于票据中的UserId
            var encrypetTicket = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            var ticket = FormsAuthentication.Decrypt(encrypetTicket);
            var userId = ticket.Name;
            //判断session中是否存在该UserId的User
            var userAuths = HttpContext.Current.Session[userId] as List<VwUserAuth>;
            if (userAuths == null)
            {
                AccountService accountService = new AccountService();
                userAuths = accountService.GetUserAuthsByUserId(userId);
                HttpContext.Current.Session.Add(userId, userAuths);
            }
            //验证权限
            foreach (var auth in userAuths)
            {
                if (auth.AuthName==_authType.ToString())
                {
                    return;
                }
            }
            var controller = filterContext.Controller;
            if (!String.IsNullOrEmpty(filterContext.HttpContext.Request.UrlReferrer.AbsoluteUri))
            {
                var url = filterContext.HttpContext.Request.UrlReferrer.LocalPath;
                filterContext.HttpContext.Response.Redirect(url + "?info=权限不足");
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/Home/Index?info=权限不足");
            }
            return;
        }
        
    }

    public enum AuthType
    {
        查看用户,
        修改用户,
        查看角色,
        修改角色,
        创建角色
    } 