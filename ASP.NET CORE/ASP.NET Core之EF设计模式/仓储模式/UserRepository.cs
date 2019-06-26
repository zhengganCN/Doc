using LikeLook.DBModels;
using LikeLook.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LikeLook.Repository
{
    public class VideoRepository : BaseRepository<LikeLookDBContext,Tbuser>,IVideoRepository
    {
        private readonly LikeLookDBContext _context;
        public VideoRepository(LikeLookDBContext context):base(context)
        {
            _context = context;
        }
    }
}
