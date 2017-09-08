using System;
using System.Text;
using GuavaBlog.Web.Models;

namespace GuavaBlog.Web
{
    public static class PostExtensions
	{
		public static string GetSlug(this PostViewModel post)
		{
			if(string.IsNullOrWhiteSpace(post.Title))
				return string.Empty;

			var replacements = @" ""'?*$.,+&:;\/#!%<>|©^S".ToCharArray();

			var splits = post.Title.Split(replacements, StringSplitOptions.RemoveEmptyEntries);
			var sb = new StringBuilder();
			foreach (var s in splits)
			{
				sb.Append(s);
				sb.Append("-");
			}
			return sb.ToString(0, sb.Length - 1).ToLower();
		}

	    public static string GetExcerpt(this PostViewModel post, int length)
	    {
	        string excerpt;
	        if (post.Content.Length > length)
	        {
	            excerpt = post.Content.Substring(0, length) + "...";
	        }
	        else
	        {
	            excerpt = post.Content;
	        }
	        return excerpt;
	    }
    }

}
