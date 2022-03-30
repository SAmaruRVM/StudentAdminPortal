using System;

using Bogus;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using StudentAdminPortal.RestfulAPI.Context;
using StudentAdminPortal.RestfulAPI.Models;
namespace StudentAdminPortal.RestfulAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var hostBuilder = CreateHostBuilder(args).Build();

            using (var scope = hostBuilder.Services.CreateScope())
            {
                using (var studentAdminPortalContext = scope.ServiceProvider.GetRequiredService<StudentAdminPortalContext>())
                {
                    studentAdminPortalContext.Database.EnsureDeleted();
                    studentAdminPortalContext.Database.EnsureCreated();

                    #region Generate Fake Data using Bogus 

                    const string bogusLocale = "pt_PT";
                    var genders = new[]
                    {
                          new Gender
                        {
                            Id = Guid.NewGuid(),
                            Name = "Male"
                        }, new Gender
                        {
                            Id = Guid.NewGuid(),
                            Name = "Female"
                        }, new Gender
                        {
                            Id = Guid.NewGuid(),
                            Name = "Other"
                        },
                    };

                    studentAdminPortalContext.AddRange(genders);
                    studentAdminPortalContext.SaveChanges();

                    var studentGenerator = new Faker<Student>(bogusLocale)
                                    .RuleFor(s => s.Id, f => f.Random.Guid())
                                    .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                                    .RuleFor(s => s.LastName, f => f.Name.LastName())
                                    .RuleFor(s => s.Mobile, f => f.Phone.PhoneNumber())
                                    .RuleFor(s => s.Email, (f, s) => f.Internet.Email(s.FirstName, s.LastName, provider: null, uniqueSuffix: f.Random.Hexadecimal(length: 7).ToString()))
                                    .RuleFor(s => s.DateOfBirth, f => f.Date.Past(yearsToGoBack: 20))
                                    .RuleFor(a => a.Gender, f => f.PickRandom(genders))
                                    .RuleFor(a => a.AvatarURL, (f, u) => $"https://avatars.dicebear.com/api/open-peeps/{u.Id}.svg");


                    var students = studentGenerator.Generate(25);
                    studentAdminPortalContext.AddRange(students);
                    studentAdminPortalContext.SaveChanges();

                    var addressGenerator = new Faker<Address>(bogusLocale)
                                    .RuleFor(a => a.Id, f => f.Random.Guid())
                                    .RuleFor(a => a.PhysicalAddress, f => f.Address.StreetAddress())
                                    .RuleFor(a => a.PostalAddress, f => f.Address.SecondaryAddress())
                                    .RuleFor(a => a.Student, f => f.PickRandom(students));


                    #endregion

                    studentAdminPortalContext.AddRange(addressGenerator.Generate(30));
                    studentAdminPortalContext.SaveChanges();

                }

            }


            hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
