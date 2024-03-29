﻿using CatalogComment.API.Data.Interfaces;
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
        private UserGrpcService _userGrpcService;

        public CommentRepository(ICatalogCommentContext catalogCommentContext, ProductGrpcService productGrpcService, UserGrpcService userGrpcService)
        {
            _catalogCommentContext =
                catalogCommentContext ?? throw new ArgumentNullException(nameof(catalogCommentContext));
            _productGrpcService = productGrpcService;
            _userGrpcService = userGrpcService;
        }


        public async Task<IEnumerable<Comment>> GetProductCommentsAsync(string productId, int currentPage, int itemInPage)
        {
            var filter = Builders<Comment>.Filter.Eq(p => p.ProductId, productId);

            var productComments = await _catalogCommentContext.Comments.Find(filter).Paginate(currentPage, itemInPage).ToListAsync();

            return productComments;
        }

        public async Task<string> CreateCommentAsync(CreateCommentModel commentModel)
        {
            var existUser = await _userGrpcService.ExistUserAsync(commentModel.UserId);

            if (existUser == false)
            {
                return new Exception("user doesn't found").ToString();
            }


            var existProduct = await _productGrpcService.ExistProductAsync(commentModel.ProductId);

            if (existProduct == false)
            {
                return new Exception("product doesn't found").ToString();
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