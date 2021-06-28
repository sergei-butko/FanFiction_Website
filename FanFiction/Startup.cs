using FanFiction.Data;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FanFiction
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews(mvcOptions=>
            {
                mvcOptions.EnableEndpointRouting = false;
            });
            services.AddRazorPages();
            services.AddTransient<IAllUsers, UserRepository>();
            services.AddTransient<IAllStories, StoryRepository>();
            services.AddTransient<IAllChapters, ChapterRepository>();
            services.AddTransient<IAllTags, TagRepository>();
            services.AddTransient<IAllTagsForStories, TagForStoryRepository>();
            services.AddTransient<IAllComments, CommentRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbObjects.Initial(context);
            }
        }
    }
}