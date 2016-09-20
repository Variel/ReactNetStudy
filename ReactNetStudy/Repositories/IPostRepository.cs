using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReactNetStudy.Models;

namespace ReactNetStudy.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Remove(int id);
        void Remove(Post post);

        Post Find(int id);
        IEnumerable<Post> GetAll();

        Post Create();
    }
}