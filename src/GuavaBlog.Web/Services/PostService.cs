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

        public string GetPost(int postId)
        {
            return "";
        }

        public void SavePost(PostViewModel post)
        {
            
        }

        public PostViewModel GetPostBySlug(string slug)
        {
            return new PostViewModel
            {
                Id = 22,
                PublishedDate = DateTime.Today.AddDays(-5),
                Title = "Avoid getting hacked - watch out for trojans",
                Tags = "computer-security;trojans;hacking",
                Content = @"

	<p>I have been following the <a href=""http://dot.net"">.NET Core</a> development and release for a while and excited to see the direction where it is going. I think this should have been the focus some time back, however its still good time with many lessons learned over the years. </p>

<p>Involving the community and opening up the source and accepting contributions was one of the key factors in making .Net Core a great product. Making a .NET Standard was another one, providing an api surface area in various platforms much like the C++ Standard Library. Beautiful. Supporting multi-platforms (Windows, *nix, OSX). Awesome.</p>

<p>Since I have not been living under a rock, I have kept a keen interest in these developments. Over the past year I've also become comfortable with python. Mostly using Django framework to develop web applications and AngularJS and <a href=""http://hackerrank.com/"">HackerRank</a>. For Python I use <a href=""https://www.jetbrains.com/pycharm/"" title=""PyCharm"">PyCharm</a> and <a href=""https://code.visualstudio.com/docs"" title=""Visual Studio Code"">Visual Studio Code</a></p>

<p>I am still interested in scalability and the direction where the Actor model has been going. Concurrency and parallelism both on the client side and server side are my passion, but I have been meddling with the following for a while and hope to create content relating to all of the above.  </p>

<p>It is important to also mention that the following are all opensource frameworks with a lot of community involvement.</p>

<h2 id=""roslyncompiler"">Roslyn Compiler</h2>

<p>During this period I have seen very interesting developments happening in the Rosyln (The C# 7 compiler). My favorite feature being the following:</p>

<p><strong>1) Tuples</strong></p>

<p>Looking at the Tuples one sees the syntactic sugar enabling a resemblance to python than the previous implementation.</p>

<p>C#</p>

<pre><code class=""hljs cs"">(<span class=""hljs-keyword"">string</span> alpha, <span class=""hljs-keyword"">string</span> beta) letters = (<span class=""hljs-string"">""a""</span>, <span class=""hljs-string"">""b""</span>);
<span class=""hljs-keyword"">var</span> moreLetters = (alpha: <span class=""hljs-string"">""a""</span>, beta: <span class=""hljs-string"">""b""</span>);
WriteLine(moreLetters.alpha);
</code></pre>

<p>Python</p>

<pre><code class=""hljs bash"">(ten, twenty) = (<span class=""hljs-number"">10</span>, <span class=""hljs-number"">20</span>)
<span class=""hljs-built_in"">print</span> ten
</code></pre>

<p>In the previous versions, you needed to create a new instance of a <code>Tuple</code> data structure and access the items using property names which were not named nicely. i.e. <code>Item1, Item2...</code> Notice that, you are able to access <code>moreLetters.alpha</code> in the example above. You may also have noticed that I did not write <code>Console.WriteLine(...)</code>, this is because you are now able to add a using clause which imports the static methods from a class. e.g. </p>

<pre><code class=""hljs cpp""><span class=""hljs-keyword"">using</span> System;
<span class=""hljs-keyword"">using</span> System.Collections.Generic;
<span class=""hljs-keyword"">using</span> <span class=""hljs-keyword"">static</span> System.Console;
</code></pre>

<p>The underlying implementation of the C#7 Tuple is a <code>System.ValueTuple</code> struct which is different from the <code>System.Tuple</code> class we used before. Thus, the new Tuple is a value type rather than reference type as the previous one. As you know there is an internal difference in the way value types and reference types are managed by the compiler.</p>

<p><strong>2) Pattern Matching</strong></p>

<p>If you look at the following C# segment, </p>

<pre><code class=""hljs cs"">        <span class=""hljs-comment"">// Use 'case' with pattern expressions</span>
        <span class=""hljs-keyword"">switch</span> (shape)
        {
            <span class=""hljs-keyword"">case</span> Circle c:
                WriteLine($<span class=""hljs-string"">""circle with radius {c.Radius}""</span>);
                <span class=""hljs-keyword"">break</span>;
            <span class=""hljs-function""><span class=""hljs-keyword"">case</span> Rectangle s <span class=""hljs-title"">when</span> <span class=""hljs-params"">(s.Length == s.Height)</span>:
                <span class=""hljs-title"">WriteLine</span><span class=""hljs-params"">($<span class=""hljs-string"">""{s.Length} x {s.Height} square""</span>)</span></span>;
                <span class=""hljs-keyword"">break</span>;
            <span class=""hljs-keyword"">case</span> Rectangle r:
                WriteLine($<span class=""hljs-string"">""{r.Length} x {r.Height} rectangle""</span>);
                <span class=""hljs-keyword"">break</span>;
            <span class=""hljs-keyword"">case</span> <span class=""hljs-keyword"">null</span>:
                <span class=""hljs-keyword"">throw</span> <span class=""hljs-keyword"">new</span> ArgumentNullException(nameof(shape));
            <span class=""hljs-keyword"">default</span>:
                WriteLine(<span class=""hljs-string"">""&lt;unknown shape&gt;""</span>);
                <span class=""hljs-keyword"">break</span>;
        }
</code></pre>

<p>Now check this one in Scala. There are some similarities here in that types are are matched sequentially. The great advantage you have in C# 7 is that you are able to declare and use that matched case. You are also able to apply further constraints using <code>when</code> clause after matching, which I think is awesome. </p>

<pre><code class=""hljs python"">object MatchTest2 extends App {
  <span class=""hljs-function""><span class=""hljs-keyword"">def</span> <span class=""hljs-title"">matchTest</span><span class=""hljs-params"">(x: Any)</span>:</span> Any = x match {
    case <span class=""hljs-number"">1</span> =&gt; <span class=""hljs-string"">""one""</span>
    case <span class=""hljs-string"">""two""</span> =&gt; <span class=""hljs-number"">2</span>
    case y: Int =&gt; <span class=""hljs-string"">""scala.Int""</span>
      }
      println(matchTest(<span class=""hljs-string"">""two""</span>))
}
</code></pre>

<p>I have only given one example using a <code>switch</code> statement, but pattern matching also support <code>is</code> operator and it gives you a neat ability to declare a variable where the value will be assigned if the type is matched.</p>

<p><strong>3) Local Functions</strong></p>

<p>These are basically functions withing functions. You could technically do this before though Action&lt;&gt; or Func&lt;&gt; delegates. I remember when I made a recursive tree traversal algorithm using that approach a few years ago. </p>

<p>I check quite frequently the <a href=""https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md"" title=""Roslyn Status"">https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md</a> link to see the status of the new features. :) </p>

<h2 id=""netcore"">.NET Core</h2>

<p>This is the unified, fast, multi-platform, opensource framework that is quickly seeing a lot of participation and adoption by many individuals and companies. There is already a lot of content around this and Scott has written a nice article around this on <a href=""https://www.hanselman.com/blog/WhatNETDevelopersOughtToKnowToStartIn2017.aspx"">What .NET developers ought To know to start in 2017</a></p>

<p>There is a channel on <a href=""https://www.youtube.com/channel/UCvtT19MZW8dq5Wwfu6B0oxw"" title=""ON .NET"">YouTube</a> in which <a href=""https://twitter.com/bleroy"">Bertrand Le Roy</a> invites guests to talk about .NET and any other projects related. This is a very nice channel to subscribe to. Some of my favorites episode are the one with <a href=""https://twitter.com/ayende"">Ayende Rahien</a>, <a href=""https://twitter.com/terrajobst"">Immo Landwerth</a> on NET Standard and <a href=""https://twitter.com/jbevain"">JB Evain</a> on Cecil. I never miss an episode.</p>

<p>For more information check <a href=""http://dot.net"">http://dot.net</a> or <a href=""https://www.microsoft.com/net/core/platform"">https://www.microsoft.com/net/core/platform</a></p>

<h2 id=""aspnetcore"">ASP.NET Core</h2>

<p>You have to love this.</p>

<p>A lot has been talked about it in various blogs and on the Community Standup - A cool show where Scott, Damien, and sometimes another quest talk about the new developments that have happened, what is happening and what is expected to happen with the ASP.NET Core. There is a section in which the community shoutouts mare made and questions are taken from the community through <a href=""https://twitter.com/aspnet"" title=""https://twitter.com/aspnet"">https://twitter.com/aspnet</a> or <a href=""https://gitter.im/aspnet/Home"">https://gitter.im/aspnet/Home</a> It can be accessed here <a href=""https://live.asp.net/"" title=""https://live.asp.net/"">https://live.asp.net/</a> or better yet, Scott's youtube channel <a href=""https://www.youtube.com/user/shanselman/videos"">https://www.youtube.com/user/shanselman/videos</a>  </p>

<p>So you are interested in developing web applications and you code in C# (maybe F#) and you care about performance, multi-platform, extensibility, testability, simplicity and most of all really cool? Sounds like a commercial, right? No, No, but I'm serious this is fast and there is numbers to prove it.</p>

<p>It offers a unified way of creating MVC, API and WebPages and give you control over the the middleware pipeline. There are many projects centered around it and a lot of community contributions and involvement in this. You will also notice that with the new ecosystem you will be able to use the web tools like (gulp, grunt, npm, bower and others) effectively, from their package repositories. This enables Nuget to focus on your server-side packages and streamline the packages for a specific purpose, but we are also seeing some tooling coming from Nuget as well for CLI.</p>

<p>I have already started a project using this on Visual Studio Code. A multi-tenant SPA application.</p>

<p>I'd recommend that you visit <a href=""https://docs.microsoft.com/en-us/aspnet/core/"" title=""docs.asp.net"">docs.asp.net</a> to get started. I also recommend the <a href=""https://mva.microsoft.com/training-topics/web-development#!jobf=Developer&amp;lang=1033"">Microsoft Virtual Academy</a> as a place to start learning, for free.</p>

<h2 id=""conclusion"">Conclusion</h2>

<p>I think the direction and the future of this ecosystem is the right one. I cannot wait for the tooling to reach completion and for .NET Standard 2.0, there is already lot of success in this area with templating engine, which will make it simple to create tools for scaffolding applications on CLI and within Visual Studio. It will be interesting to see code shared from all the different web/cloud, mobile, ARM, Desktop on Xamarin, .NET Core, Full .NET. </p>

<p>Its a good time to be a .NET developer. </p>

<h2 id=""somelinksioftenvisit"">Some links I often visit</h2>

<ul>
<li><a href=""https://github.com/dotnet/core.git"" title="".NET Core"">https://github.com/dotnet/core.git</a> The core framework</li>
<li><a href=""https://github.com/dotnet/coreclr.git"" title="".NET Runtime"">https://github.com/dotnet/coreclr.git</a> The runtime framework</li>
<li><a href=""https://github.com/dotnet/corefxlab.git"" title="".NET Core Lab"">https://github.com/dotnet/corefxlab.git</a> Has experiments, some of which may become part of the .NET Core. Very interesting stuff some of which may require mental gymnastics</li>
<li><a href=""https://github.com/dotnet/corefx.git"">https://github.com/dotnet/corefx.git</a> The runtime framework </li>
<li><a href=""https://github.com/aspnet/home"">https://github.com/aspnet/home</a> ASP.NET Home, with repository links to EntityFramework, MVC, Razor, SignalR and others. Because I like ORMs I'm always pulling EF from <a href=""https://github.com/aspnet/EntityFramework"">https://github.com/aspnet/EntityFramework</a> to see changes happening there</li>
<li><a href=""https://github.com/aspnet/Entropy"">https://github.com/aspnet/Entropy</a> - An experimental repository for features that may be added to MVC or other middleware. Its awesome.</li>

",
                Excerpt =
                    "Earlier today, I received a message on Skype on my PC from a friend.   Malisa Ncube video: http://24onlineskyvideo.in.ua/video/?n=Malisa%20Ncube :) The message came through a contact on Skype, who I suspect has infected his PC. On clicking the link, one would see a screen like this below.  It quite deceptive in that, it pretends to be buffering the video and the play button in the center glows like any common video you can play.",
                Featured = false,
                Url = "avoid-getting-hacked-watch-out-for-trojans"
            };
        }

        public List<PostViewModel> GetPostsByTag(string tag)
        {
            return new List<PostViewModel>()
            {
                new PostViewModel { }
            };
        }
    }
}
