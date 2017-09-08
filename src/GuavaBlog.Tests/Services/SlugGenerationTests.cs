using System;
using GuavaBlog.Web;
using GuavaBlog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GuavaBlog.Tests
{
    public class SlugGenerationTests
    {
        [Fact]
        public void SpaceReplacement()
        {
            var post = new PostViewModel
            {
                Title = "What is going on?"
            };
            Assert.Equal("what-is-going-on", post.GetSlug());
        }

        [Theory]
        [InlineData("test?", "test")]
        [InlineData("test<", "test")]
        [InlineData("test>", "test")]
        [InlineData("test/", "test")]
        [InlineData("test&", "test")]
        [InlineData("test!", "test")]
        [InlineData("test#", "test")]
        [InlineData("test''", "test")]
        [InlineData("test|", "test")]
        [InlineData("test©", "test")]
        [InlineData("test%", "test")]
        [InlineData("Avoid getting hacked, email", "avoid-getting-hacked-email")]
        [InlineData("Emails&Getting+Hacked", "emails-getting-hacked")]
        [InlineData("What i want       to see in $Windows=Azure", "what-i-want-to-see-in-windows=azure")]
        [InlineData("Data^base essentials Log(n) algorithms", "data-base-essentials-log(n)-algorithms")]
        public void CreatePostSlug(string input, string expected)
        {
            var post = new PostViewModel
            {
                Title = input
            };
            Assert.Equal(expected, post.Slug);
        }
    }
}
