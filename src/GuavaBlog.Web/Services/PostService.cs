using System;
using System.Collections.Generic;

namespace GuavaBlog.Web.Services
{
    public class PostService : IPostService
    {
        public List<PostViewModel> GetPosts(int pageSize = 10, int page = 1, string filter = null)
        {
            return new List<PostViewModel>()
            {
                new PostViewModel { }
            };
        }

        public List<PostViewModel> GetExcerpts(int pageSize = 10, int page = 1, string filter = null)
        {
            return new List<PostViewModel>()
            {
                new PostViewModel
                {
                    Id = 21,
                    PublishedDate = DateTime.Today,
                    Title = ".NET Core Ecosystem - My thoughts",
                    Tags = "NETCORE;ROSLYN;ASPNET;.NET",
                    Excerpt = "I have been following the .NET Core development and release for a while and excited to see the direction where it is going. I think this should have been the focus some time back, however its still good time with many lessons learned over the years. Involving the community and opening up the source and accepting contributions was one of the key factors in making .Net Core a great product. Making a .NET Standard was another one, providing an api",
                    Featured = true,
                    Url = "net-core-ecosystem-my-thoughts"
                },
                new PostViewModel
                {
                    Id = 22,
                    PublishedDate = DateTime.Today.AddDays(-5),
                    Title = "Avoid getting hacked - watch out for trojans",
                    Tags = "computer-security;trojans;hacking",
                    Excerpt = "Earlier today, I received a message on Skype on my PC from a friend.   Malisa Ncube video: http://24onlineskyvideo.in.ua/video/?n=Malisa%20Ncube :) The message came through a contact on Skype, who I suspect has infected his PC. On clicking the link, one would see a screen like this below.  It quite deceptive in that, it pretends to be buffering the video and the play button in the center glows like any common video you can play.",
                    Featured = false,
                    Url = "avoid-getting-hacked-watch-out-for-trojans"
                }
            };
        }

        public string GetExcerpt(int postId)
        {
            return "I have been following the .NET Core development and release for a while and excited to see the direction where it is going. I think this should have been the focus some time back, however its still good time with many lessons learned over the years. Involving the community and opening up the source and accepting contributions was one of the key factors in making .Net Core a great product. Making a .NET Standard was another one, providing an api";
        }

        public string GetStory(int postId)
        {
            return "";
        }

        public void SavePost(PostViewModel post)
        {
            
        }

    }
}
