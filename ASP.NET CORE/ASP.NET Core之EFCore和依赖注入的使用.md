# ASP.NET Core之EFCore和依赖注入的使用

## 在Startup.cs文件中添加服务,注入XXXDbContext

    services.AddDbContext<XXXDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

## 在XXXDbContext.cs文件中重写方法OnConfiguring()

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LearningProgrammingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

## 在数据操作层使用

    using(var context=new XXXDbContext())
    {
        courses  =context.Course.ToList();
    }
