using Auth.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository.IRepository
{
    //实体类的私有仓储接口方法
    interface IUserRepository
    {
        TbUser FindByUserName(string userName);
    }
}
