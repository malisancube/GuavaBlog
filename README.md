# GuavaBlog

A blog site in ASP.NET Core 2.0. It should power http://www.malisancube.com

## Stack

- ASP.NET Core 2.0
- SQLite

## Roadmap

These are features I intend to add in no particular order

- Enable multi-user blogging
- Build a DevOps pipeline
- Support plugin themes
- Support plugins that can even determine the kind of post you can add. e.g. Events, Feed from 3rd Party
- Import from other blogsites, starting with Ghost
- Docker deployment scripts
- Change the application to a Single Page Application (SPA) using Angular frontend
- Add setup wizard
- Add relevant feed outputs. RSS, iCal etc
- Image manipulation - Resize
- Prevent robots sending comments
- Implement and abstract way of adding comments. e.g. Disqus or save them in db based on user option. Moderation of comments
- Have an abstract way of managing email. e.g. If the user chooses to use SendGrid they should be able to place the credentials and it just works 
- Add caching on posts
- Enable code injection for Google Analytics and other types
- Application Insights - find ways to make it more effective