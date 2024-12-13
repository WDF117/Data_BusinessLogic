using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data_BusinessLogic.Services
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllCommentsAsync();
        Task<Comments> GetCommentByIDAsync(int commentID);
        Task<Comments> AddCommentAsync(Comments comment);
        Task<Comments> UpdateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int commentID);
    }

    public class CommentRepository : ICommentRepository
    {
        private readonly RepairDBEntities _dbcon = RepairDBEntities._context;

        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            return await _dbcon.Comments.ToListAsync();
        }

        public async Task<Comments> GetCommentByIDAsync(int commentID)
        {
            return await _dbcon.Comments.FirstOrDefaultAsync(x => x.ID == commentID);
        }

        public async Task<Comments> AddCommentAsync(Comments comment)
        {
            _dbcon.Comments.Add(comment);
            await _dbcon.SaveChangesAsync();
            return comment;
        }

        public async Task<Comments> UpdateCommentAsync(Comments comment)
        {
            if (!_dbcon.Comments.Local.Any(x => x.ID == comment.ID))
            {
                _dbcon.Comments.Attach(comment);
            }
            _dbcon.Entry(comment).State = EntityState.Modified;
            await _dbcon.SaveChangesAsync();
            return comment;
        }

        public async Task DeleteCommentAsync(int commentID)
        {
            var comment = await _dbcon.Comments.FirstOrDefaultAsync(x => x.ID == commentID);
            if (comment != null)
            {
                _dbcon.Comments.Remove(comment);
                await _dbcon.SaveChangesAsync();
            }
        }
    }
}
