using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NewsWebApp.Models;

namespace NewsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()

        {
            var UserId = User.Identity.GetUserId();

            if (UserId == null)
            {
                var list1 = db.PostTypes.ToList();

                return View(list1);
            }
            
            
            //var role = user.UserType;
            
            else
            {
                var user = db.Users.Where(a => a.Id == UserId).SingleOrDefault();
                switch (user.UserType)
                {
                    case ("Admin"):
                        return RedirectToAction("Index", "Admin");

                    case ("Editor"):
                        return RedirectToAction("IndexEditor", "Home");

                }
            }
            var list = db.PostTypes.ToList();

            return View(list);
        }
        public ActionResult IndexEditor()
        {
            var list = db.PostTypes.ToList();

            return View(list);
        }

        [Authorize]
        public ActionResult Details(int postId)
        {
            var post = db.Posts.Find(postId);
            if (post == null)
            {
                return HttpNotFound();
            }
            Session["postId"] = postId;

            return View(post);
        }
        [Authorize]
        public ActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ask(string message)
        {
            var UserId = User.Identity.GetUserId();
            var PostId = (int)Session["postId"];

            var post = new AskForPost();
            post.UserId = UserId;
            post.PostId = PostId;
            post.Message = message;
            db.AskForPosts.Add(post);
            db.SaveChanges();
            ViewBag.Result = "Successfully ..";


            return View();
        }
        [Authorize]
        public ActionResult GetAskByUser()
        {
            var UserId = User.Identity.GetUserId();
            var post = db.AskForPosts.Where(a => a.UserId == UserId);


            return View(post.ToList());
        }
        //error here
        [Authorize]
        public ActionResult DetailsOfPost(int Id)
        {
            var post = db.Posts.Find(Id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        [Authorize]
        public ActionResult GetAskByEditor()
        {
            var UserId = User.Identity.GetUserId();
            var Posts = from app in db.AskForPosts
                        join post in db.Posts
                        on app.PostId equals post.PostId
                        where post.UserId == UserId
                        select app;

            var grouped = from j in Posts
                          group j by j.post.ArticleTitle
                          into gr
                          select new PostViewMoedl
                          {
                              ArticleTitle = gr.Key,
                              Items = gr

                          };
            return View(grouped.ToList());
        }
        [Authorize]
        public ActionResult Search()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Search(string SearchName)
        {
            var result = db.Posts.Where(a => a.ArticleTitle.Contains(SearchName)||
            a.PostType.ArticleType.Contains(SearchName)||a.User.UserName.Contains(SearchName)).ToList();
            return View(result);
        }
        [Authorize]
        public ActionResult SaveAction()
        {
            var UserId = User.Identity.GetUserId();
            var PostId =(int)Session["postId"];

            var post = new SavePost();
            post.UserId = UserId;
            post.PostId = PostId;
            
            db.SavePosts.Add(post);
            db.SaveChanges();
            ViewBag.Result = " Saved Successfully ..";


            return View();

        }
        [Authorize]
        public ActionResult Saved()
        {
            var UserId = User.Identity.GetUserId();
            var Posts = from app in db.Posts
                        join post in db.SavePosts
                        on app.PostId equals post.PostId
                        where post.UserId == UserId
                        select app;

            return View(Posts.ToList());
        }

        
    }
}