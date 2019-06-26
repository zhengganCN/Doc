# ASP.NET Core之为IdentityUser添加新字段

## 1、创建用户实体，继承IdentityUser，添加新增属性

    public class Account:IdentityUser
    {
        /// <summary>
        /// 移动电话号码
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 固定电话号码
        /// </summary>
        public string FixedPhone { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        public string QQ { get; set; }
    }

## 2、创建DbContext上下文类，泛型参数为继承了IdentityUser的自定义实体

    public class MyDbContext:IdentityDbContext<Account>
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
    }
