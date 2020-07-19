using Auth.DBModel;
using Auth.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository
{
    public class UserRepository : BaseRepository<TbUser>,IUserRepository
    {
        private readonly AuthDBContext _context;
        public UserRepository(AuthDBContext DataCotent) : base(DataCotent)
        {
            _context = DataCotent;
        }
        

        public TbUser FindByUserName(string userName)
        {
            return _context.TbUsers.SingleOrDefault(user => user.UserName==userName);
        }
    }
}
