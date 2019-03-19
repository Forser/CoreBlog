using CoreBlog.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(Configuration["CoreBlog:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["CoreBlogIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMemoryCache();
            services.AddSession();
            services.AddTransient<IPostRepository, PostRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=List}/{id?}");
                routes.MapRoute(name: "ViewPost", template: "{action}/{id?}", defaults: new { controller = "Home", action = "ViewPostBySlug", postsPage = 1 });
                routes.MapRoute(name: "Category", template: "{action}/{id?}", defaults: new { controller = "Home", action = "ViewPostsByCategory", postsPage = 1 });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            SeedBlogPosts.EnsuredPopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}