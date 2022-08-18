using CatalogComment.API.Data.Interfaces;
using CatalogComment.API.Entities;
using CatalogComment.API.Extensions;
using CatalogComment.API.GrpcServices;
using CatalogComment.API.Models;
using CatalogComment.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace CatalogComment.API.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private ICatalogCommentContext _catalogCommentContext;
        private ProductGrpcService _productGrpcService;

        public CommentRepository(ICatalogCommentContext catalogCommentContext, ProductGrpcService productGrpcService)
        {
            _catalogCommentContext =
                catalogCommentContext ?? throw new ArgumentNullException(nameof(catalogCommentContext));
            _productGrpcService = productGrpcService;
        }


        public async Task<IEnumerable<Comment>> GetProductCommentsAsync(string productId, int currentPage, int itemInPage)
        {
            var filter = Builders<Comment>.Filter.Eq(p => p.ProductId, productId);

            var productComments = await _catalogCommentContext.Comments.Find(filter).Paginate(currentPage, itemInPage).ToListAsync();

            return productComments;
        }

        public async Task<string> CreateCommentAsync(CreateCommentModel commentModel)
        {
            //TODO : cheack userId exsist by grpc request

            var existProduct = await _productGrpcService.ExistProductAsync(commentModel.ProductId);

            if (existProduct == false)
            {
                return new Exception("productId doesn't found").ToString();
            }

            Comment comment = new Comment()
            {
                ProductId = commentModel.ProductId,
                UserComment = commentModel.UserComment,
                UserId = commentModel.UserId
            };
            await _catalogCommentContext.Comments.InsertOneAsync(comment);

            return comment.Id;
        }

        public async Task<Comment> GetCommentAsync(string id)
        {
            FilterDefinition<Comment> filter = Builders<Comment>.Filter.Eq(p => p.Id, id);

            var comment = await _catalogCommentContext.Comments.Find(filter).SingleOrDefaultAsync();

            return comment;
        }

        public async Task DeleteCommentAsync(string id)
        {
            FilterDefinition<Comment> filter = Builders<Comment>.Filter.Eq(p => p.Id, id);

            await _catalogCommentContext.Comments.DeleteOneAsync(filter);
        }

        public async Task<string> UpdateCommentAsync(string id, UpdateCommentModel commentModel)
        {
            FilterDefinition<Comment> filter = Builders<Comment>.Filter.Eq(p => p.Id, id);

            var comment = await _catalogCommentContext.Comments.Find(filter).SingleOrDefaultAsync();

            if (comment != null)
            {
                comment.UserComment = commentModel.UserComment;
                await _catalogCommentContext.Comments.ReplaceOneAsync(filter, comment);
            }

            return id;
        }
    }
}