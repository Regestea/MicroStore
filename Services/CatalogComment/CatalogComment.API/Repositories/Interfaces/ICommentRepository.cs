using CatalogComment.API.Entities;
using CatalogComment.API.Models;

namespace CatalogComment.API.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetProductCommentsAsync(string productId, int currentPage, int itemInPage);

        Task<string> CreateCommentAsync(CreateCommentModel commentModel);

        Task<Comment> GetCommentAsync(string id);

        Task DeleteCommentAsync(string id);

        Task<string> UpdateCommentAsync(string id, UpdateCommentModel commentModel);
    }
}
