
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using StudentAdminPortal.RestfulAPI.Context;
using StudentAdminPortal.RestfulAPI.Profiles;
using StudentAdminPortal.RestfulAPI.Repositories;

namespace StudentAdminPortal.RestfulAPI
{
    public class Startup // Bind<T>()
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(op =>
            {
                op.SuppressAsyncSuffixInActionNames = true;
            });
            services.AddDbContext<StudentAdminPortalContext>();

            services.AddCors(c => c.AddDefaultPolicy(p => p.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            services.AddRouting(o => { });


            services.AddAutoMapper(typeof(GeneralProfile).Assembly);

            services.AddScoped<IStudentRepository, SqlStudentRepository>();
            services.AddScoped<IGenderRepository, SqlGenderRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
