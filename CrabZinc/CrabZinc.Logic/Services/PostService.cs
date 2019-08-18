using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CrabZinc.Common.Entities;
using CrabZinc.Common.ViewModels;
using CrabZinc.Data;
using OwlTin.Common;
using OwlTin.Common.Exceptions;

namespace CrabZinc.Logic.Services
{
    public class PostService
    {

        private readonly CrabZincDbContext _db;

        public PostService(CrabZincDbContext db)
        {
            this._db = db;
        }

        public Post Get(long id)
        {
            return _db.Posts.Active().FirstOrDefault(p => p.PostId == id);
        }

        public Post GetBySlug(string slug)
        {
            return _db.Posts.Active().FirstOrDefault(p => p.Slug == slug);
        }

        public IEnumerable<Post> GetAll()
        {
            return _db.Posts.Active();
        }

        /// <summary>
        /// Get the <paramref name="amount" /> newest posts sorted with the newest posts appearing first
        /// </summary>
        /// <param name="amount">The number of posts to take, defaults to 10</param>
        /// <returns><paramref name="amount" /> newest posts</returns>
        public IEnumerable<Post> GetNewest(int amount=10)
        {
            //TODO: This should really be published date, but publish functionality isn't implemented yet, so
            //    we are going to go with Created date
            return _db.Posts.Active().OrderByDescending(p => p.CreateDate).Take(amount);
        }

        public Post Create(PostViewModel toCreate)
        {
            var post = new Post()
            {
                PostUuid = Guid.NewGuid(),
                Slug = ConvertTitleToSlug(toCreate.Title),
                Title = toCreate.Title,
                Description = toCreate.Description,
                Content = ProcessContent(toCreate.Content),
                Active = true
            };

            _db.Posts.Add(post);
            _db.SaveChanges();

            return post;
        }

        public Post Update(PostViewModel toUpdate)
        {
            var post = GetOrException(toUpdate.PostId);

            if (!string.Equals(post.Title, toUpdate.Title, StringComparison.OrdinalIgnoreCase))
            {
                post.Title = toUpdate.Title;
                post.Slug = ConvertTitleToSlug(toUpdate.Title);
            }

            post.Description = toUpdate.Description;
            post.Content = ProcessContent(toUpdate.Content);

            _db.SaveChanges();

            return post;
        }

        public Post Delete(long id)
        {
            var post = GetOrException(id);

            _db.Posts.Remove(post);
            _db.SaveChanges();

            return post;
        }

        protected Post GetOrException(long id, string exceptionText = "Post does not exist!")
        {
            var post = Get(id);

            if (null == post)
            {
                throw new EntityValidationException(exceptionText);
            }

            return post;
        }

        protected string ConvertTitleToSlug(string title)
        {
            title = title.ToLower();
            //Remove any invalid characters
            title = Regex.Replace(title, @"[^a-z0-9\s-]", "");
            //Convert multiple spaces into one
            title = Regex.Replace(title, @"\s+", " ");
            title = title.Substring(0, title.Length <= 250 ? title.Length : 250).Trim();
            return Regex.Replace(title, @"\s", "-");
        }

        protected string ProcessContent(string content)
        {
            return TabsToSpaces(content);
        }

        protected string TabsToSpaces(string content)
        {
            //Replace all tabs with 4 spaces
            return Regex.Replace(content, @"\t", "    ");
        }

    }
}
