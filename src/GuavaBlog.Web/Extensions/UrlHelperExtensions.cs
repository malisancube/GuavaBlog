using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuavaBlog.Web.Controllers;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
	
	public static class PostExtensions
	{
		public static string GetSlug(string title)
		{
			if(string.IsNullOrWhiteSpace(title))
				return string.Empty;

			var replacements = @" ""'?*$.,+&:;\/#".ToCharArray();

			var splits = title.Split(replacements, StringSplitOptions.RemoveEmptyEntries);
			var sb = new StringBuilder();
			foreach (var s in splits)
			{
				sb.Append(s);
				sb.Append("-");
			}
			return sb.ToString(0, sb.Length - 1).ToLower();
		}
	}
}
