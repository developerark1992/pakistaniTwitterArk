using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PakistaniTwitter.Models;

namespace PakistaniTwitter
{
    public class TweetBL
    {
        public List<Tweets_PakistaniTwitter> GetTweets(string userId)
        {
            List<Tweets_PakistaniTwitter> tweets = new List<Tweets_PakistaniTwitter>();
            List<Tweets_PakistaniTwitter> FollowingTweets = new List<Tweets_PakistaniTwitter>();
            List< Followers_PakistaniTwitter > followings = new List<Followers_PakistaniTwitter>();
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                tweets = (from t in db.Tweets_PakistaniTwitter
                          where t.UserId == userId
                          select t
                          ).OrderBy(x => x.CreatedDate).ToList();
                followings = (from f in db.Followers_PakistaniTwitter
                              where f.UserId == userId
                              select f
                          ).ToList();

                foreach (var item in followings)
                {
                    FollowingTweets = (from t in db.Tweets_PakistaniTwitter
                                       where t.UserId == item.FollowingId
                              select t
                         ).OrderBy(x => x.CreatedDate).ToList();

                    foreach (var tweet in FollowingTweets)
                    {
                        tweets.Add(tweet);
                    }
                }
            }
            return tweets;
        }

        public int GetUserTweetCount(string userId)
        {
            int result = 0;
            List<Tweets_PakistaniTwitter> tweets = new List<Tweets_PakistaniTwitter>();           
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                tweets = (from t in db.Tweets_PakistaniTwitter
                          where t.UserId == userId
                          select t
                          ).OrderBy(x => x.CreatedDate).ToList();

                if (tweets != null && tweets.Count > 0)
                    result = tweets.Count;
              
            }
            return result;
            
        }

        public int GetUserFollowingCount(string userId)
        {
            int result = 0;        
            List<Followers_PakistaniTwitter> followings = new List<Followers_PakistaniTwitter>();
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                followings = (from f in db.Followers_PakistaniTwitter
                              where f.UserId == userId
                              select f
                          ).ToList();

                if (followings != null && followings.Count > 0)
                    result = followings.Count;

            }
            return result;

        }

        public int GetUserFollowersCount(string userId)
        {
            int result = 0;
            List<Followers_PakistaniTwitter> followings = new List<Followers_PakistaniTwitter>();
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                followings = (from f in db.Followers_PakistaniTwitter
                              where f.FollowingId == userId
                              select f
                          ).ToList();

                if (followings != null && followings.Count > 0)
                    result = followings.Count;

            }
            return result;

        }



        public void SaveTweet(Tweets_PakistaniTwitter tweet)
        {
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                if (tweet.TweetId == 0)
                {
                    db.Tweets_PakistaniTwitter.Add(tweet);
                }
                else
                {
                    Tweets_PakistaniTwitter t;
                    t = GetTweetById(tweet.TweetId);
                    t.Message = tweet.Message;
                    db.Tweets_PakistaniTwitter.Attach(t);
                    db.Entry(t).State = (System.Data.Entity.EntityState)EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void DeleteTweet(int tweetId)
        {
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                Tweets_PakistaniTwitter t;
                t = GetTweetById(tweetId);
                //db.Tweets.Remove(t);
                db.Entry(t).State = (System.Data.Entity.EntityState)EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Tweets_PakistaniTwitter GetTweetById(int tweetId)
        {
            Tweets_PakistaniTwitter tweet = new Tweets_PakistaniTwitter();
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                tweet = (from t in db.Tweets_PakistaniTwitter
                         where t.TweetId == tweetId
                          select t).SingleOrDefault();

            }
            return tweet;
        }
    }
}
