# ASP.NET Core之迁移(Migration)

## Code First数据库迁移

### 1、迁移命令

    Add-Migration -Name xxx -Context XXXDbContext -OutPut xxx

### 2、更新命令

    Update-Database -Context XXXDbContext

## Database First（从现有数据库创建模型）

    Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Force -OutputDir Models
