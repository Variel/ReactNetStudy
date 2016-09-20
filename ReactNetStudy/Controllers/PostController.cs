using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReactNetStudy.Repositories;

namespace ReactNetStudy.Controllers
{
    [RoutePrefix("Posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet, Route]
        public ActionResult Index()
        {
            return Json(_postRepository.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route]
        public ActionResult Create(string title = "untitled", string content = "")
        {
            var post = _postRepository.Create();
            post.Title = title;
            post.Content = content;

            _postRepository.Add(post);

            return Json(post, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("{id}")]
        public ActionResult Get(int id)
        {
            var post = _postRepository.Find(id);

            if (post == null)
                return HttpNotFound();

            return Json(post, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete, Route("{id}")]
        public ActionResult Delete(int id)
        {
            var post = _postRepository.Find(id);

            if (post == null)
                return HttpNotFound();

            _postRepository.Remove(post);

            return null;
        }

        [HttpPut, Route("{id}")]
        public ActionResult Update(int id, string title, string content)
        {
            var post = _postRepository.Find(id);

            if (post == null)
                return HttpNotFound();

            if (!String.IsNullOrWhiteSpace(title))
                post.Title = title;

            if (!String.IsNullOrWhiteSpace(content))
                post.Content = content;

            return Json(post, JsonRequestBehavior.AllowGet);
        }
    }
}