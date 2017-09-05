﻿using System.Collections.Generic;

namespace GuavaBlog.Web
{
    public class BlogViewModel
    {

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Bio { get; set; }

        public string Logo { get; set; }

        public string Cover { get; set; }

        public int PostsPerPage { get; set; }

        public string Permalinks { get; set; }

        public string TwitterHandle { get; set; }

        public string FacebookLink { get; set; }

        public string Theme { get; set; }

        public List<MenuOption> MenuOptions { get; set; }
    }
}
