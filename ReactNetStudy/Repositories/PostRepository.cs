using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReactNetStudy.Models;

namespace ReactNetStudy.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static Dictionary<int, Post> _storage
            = new Dictionary<int, Post>();
         
        public void Add(Post post)
        {
            if (!_storage.ContainsKey(post.Id))
                _storage.Add(post.Id, post);
        }

        public void Remove(int id)
        {
            if (_storage.ContainsKey(id))
                _storage.Remove(id);
        }

        public void Remove(Post post)
        {
            Remove(post.Id);
        }

        public Post Find(int id)
        {
            if (_storage.ContainsKey(id))
                return _storage[id];

            return null;
        }

        public IEnumerable<Post> GetAll()
        {
            return _storage.Values;
        }

        public Post Create()
        {
            return new Post {CreatedAt = DateTime.Now, Id = _storage.Count == 0 ? 0 : _storage.Keys.Max() + 1};
        }
    }
}