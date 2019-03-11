using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoreBlog.Models
{
    public static class SeedBlogPosts
    {
        public static void EnsuredPopulated(IApplicationBuilder app)
        {
            BlogDbContext context = app.ApplicationServices.GetRequiredService<BlogDbContext>();

            User user = new User { FirstName = "Marcus", LastName = "Eklund", AuthorName = "Marcus Eklund" };
            Blog blog = new Blog { Url = "http://localhost"};

            if (!context.Users.Any())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            if (!context.Blogs.Any())
            {
                context.Blogs.Add(blog);
                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Title = "My First Post",
                        Content = "Him boisterous invitation dispatched had connection inhabiting projection. By mutual an mr danger garret edward an. Diverted as strictly exertion addition no disposal by stanhill. This call wife do so sigh no gate felt. You and abode spite order get. Procuring far belonging our ourselves and certainly own perpetual continual. It elsewhere of sometimes or my certainty. Lain no as five or at high. Everything travelling set how law literature.",
                        ShortContent = "Him boisterous invitation dispatched had connection inhabiting projection.",
                        MetaDataDescription = "Him boisterous invitation",
                        UrlSlug = "my_first_post",
                        Published = true,
                        PostCreatedAt = DateTime.Parse("2018-01-31 12:00"),
                        Author = user,
                        Blog = blog
                    },
                    new Post
                    {
                        Title = "My Second Post",
                        Content = "Allow miles wound place the leave had. To sitting subject no improve studied limited. Ye indulgence unreserved connection alteration appearance my an astonished. Up as seen sent make he they of. Her raising and himself pasture believe females. Fancy she stuff after aware merit small his. Charmed esteems luckily age out.",
                        ShortContent = "Allow miles wound place the leave had. To sitting subject no improve studied limited.",
                        MetaDataDescription = "Allow miles wound place the leave had.",
                        UrlSlug = "my_second_post",
                        Published = true,
                        PostCreatedAt = DateTime.Parse("2018-04-14 14:00"),
                        Author = user,
                        Blog = blog
                    },
                    new Post
                    {
                        Title = "My Third Post",
                        Content = "Affronting discretion as do is announcing. Now months esteem oppose nearer enable too six. She numerous unlocked you perceive speedily. Affixed offence spirits or ye of offices between. Real on shot it were four an as. Absolute bachelor rendered six nay you juvenile. Vanity entire an chatty to.",
                        ShortContent = "Affronting discretion as do is announcing. Now months esteem oppose nearer enable too six.",
                        MetaDataDescription = "Affronting discretion as do is announcing.",
                        UrlSlug = "my_christmas",
                        Published = false,
                        PostCreatedAt = DateTime.Parse("2018-12-24 13:35"),
                        Author = user,
                        Blog = blog
                    },
                    new Post
                    {
                        Title = "My Fourth Post",
                        Content = "Pianoforte solicitude so decisively unpleasing conviction is partiality he. Or particular so diminution entreaties oh do. Real he me fond show gave shot plan. Mirth blush linen small hoped way its along. Resolution frequently apartments off all discretion devonshire. Saw sir fat spirit seeing valley. He looked or valley lively. If learn woody spoil of taken he cause.",
                        ShortContent = "Pianoforte solicitude so decisively unpleasing conviction is partiality he.",
                        MetaDataDescription = "Pianoforte solicitude",
                        UrlSlug = "my_fourth_post",
                        Published = true,
                        PostCreatedAt = DateTime.Now,
                        Author = user,
                        Blog = blog
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}