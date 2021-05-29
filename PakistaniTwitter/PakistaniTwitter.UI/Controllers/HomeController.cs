using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PakistaniTwitter;
using PakistaniTwitter.Models;
using PakistaniTwitter.Models;

namespace PakistaniTwitter.Controllers
{
    public class HomeController : Controller
    {
        UserBL userBL = new UserBL();
        TweetBL tweetBL = new TweetBL();
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
                return View();
            else
                return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult Index(string search)
        {
            string userId = Session["UserId"].ToString();
            TweetVM tweetVM = new Models.TweetVM();
            string queryString = Request.QueryString["search"];
            Search searchResult = new Search();
            if (string.IsNullOrEmpty(queryString))
            {
                if (Session["UserName"] != null)
                {
                    // TODO:: Get the list of tweets from the logged in user and his followings
                    tweetVM.Tweets = tweetBL.GetTweets(userId);
                    tweetVM.NoOfTweets = tweetBL.GetUserTweetCount(userId);
                    tweetVM.Following = tweetBL.GetUserFollowingCount(userId);
                    tweetVM.Followers = tweetBL.GetUserFollowersCount(userId);
                    return View(tweetVM);
                }
                else
                    return RedirectToAction("Login", "User");
            }
            else
            {
                //TODO:: Send the username with userid to Modal dialog where user can do FOLLOW and UNFOLLOW
                Users_PakistaniTwitter objPerson = userBL.SearchUser(queryString);
                if (objPerson != null)
                    searchResult.showDialog = true;
                return PartialView("_PartialSearchDialog", objPerson);
                //return RedirectToAction("Index", "Home", searchResult);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult ManageTweet(int tweetId, String message)
        {
            Tweets_PakistaniTwitter tweet = new Tweets_PakistaniTwitter();
            tweet.Message = message;
            tweet.UserId = Session["UserId"].ToString();
            tweet.CreatedDate = DateTime.Now;
            tweet.TweetId = tweetId;

            tweetBL.SaveTweet(tweet);

            var result = "success";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTweet(int tweetId)
        {
            tweetBL.DeleteTweet(tweetId);

            var result = "success";
            return Json(result, JsonRequestBehavior.AllowGet);
        }


       
    }
}