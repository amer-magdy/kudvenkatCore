using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyTutorial1.Models;
using MyTutorial1.Security;

namespace MyTutorial1
{
    public class Startup
    {
        private readonly IConfiguration _Config;

        public Startup(IConfiguration  _config)
        {
            _Config = _config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(//we.use.EmployeeDBConnection.by.rightClickOnTheProject.and.choose.manage.secrets.it.use.like.appsettings.json
                options => options.UseSqlServer(_Config.GetConnectionString("EmployeeDBConnection")));
            // services.AddMvc();//server=(localdb)\\MSSQLLocalDB;database=EmployeeDB;Trusted_Connection=true

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                //make.login.just.with.only.email.confirmed
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequiredUniqueChars = 3;
            //});

            //services.AddMvc().AddXmlSerializerFormatters();
            //to make [Authorize] global for all folders
            services.AddMvc(options=> {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();
            //Create.Connection.with.google.api
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "459484286386-h2ihbt8885259moiptranaetaebuogbj.apps.googleusercontent.com";
                    options.ClientSecret = "gYIMqM91yETsd3mwicKZuYKM";
                    //options.CallbackPath = "";to.change.redirect.in.api.default
                })
                .AddFacebook(options=>{
                    options.AppId = "1842205699248361";
                    options.AppSecret = "f540f1d7f73dfd75d751e661bc644fc8";
                });
            //End.of.creating
            //Create.Custom.route.for.AccessDenied.path
            //default.route.is./account/accessDenied
            services.ConfigureApplicationCookie(options=> 
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });
            //end.of.creating
            //Create.Claims
            services.AddAuthorization(options=> {
                //the.name.of.policy.DeleteRolePolicy.we.use.in.the.administration.controller.in.delete.role.function
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));//if.we.need.to.add.another.one.the.user.should.have.both.of.them
                                                                  //.RequireClaim("Create Role"));
                //we.use.this.policy.on.administration.controller.in.edit.role.and.Show.the.button.if.you.got.this.policy.in.ListRoles.cshtml
                //options.AddPolicy("EditRolePolicy",
                //    policy => policy.RequireClaim("Edit Role","true"));//true.must.be.the.same.in.DB
                //Edit  Role  is.the.claim.type.in.the.database.coulmn.Insensitivy
                //the.second.argument.could.be.more.than.one.element.because.it.hold.array.of.string.so.we.can.put.list
                //we.can.use.also.in.the.policy.requireRole.but.we.need.to.satisify.all.of.thus.conditions
                    //Create.CustomAuthorizationPolicy.with.using.func
                    //options.AddPolicy("EditRolePolicy",
                    //policy => policy.RequireClaim("Edit Role","true")//this.means.&&
                    //                .RequireRole("admin")//this.means.&&
                    //                .RequireRole("super admin"));
                    //options.AddPolicy("EditRolePolicy",
                    //policy => policy.RequireAssertion(context=>
                    //       context.User.IsInRole("admin")&&
                    //       context.User.HasClaim(claim=>claim.Type== "Edit Role"&&claim.Value=="true")  ||
                    //       context.User.IsInRole("super admin")
                    //));
                    //we.don't.need.that.we.need.to.be.admin.and.got.a.claim.with.Edit.Role.OR||OR.to.be.super.admin.only
                    //End.of.CustomAuthorizationPolicy
                        //Create.Custom.AuthorizationRequirement.and.handler.
                        options.AddPolicy("EditRolePolicy",
                    policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()  ));//must.add.singleton.method.to.do.this
                        //End.of.create.custom.authorizationRequirement
                //make.claim.with.type.role
                options.AddPolicy("adminRolePolicy",
                    policy => policy.RequireRole("admin"));//if.we.need.to.add.another.one.the.user.should.have.both.of.them                                    

            });
            //end.of.create.claims

            //to register with dependency injection container
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            //to distinguish between implementation of mock or sql repositories here the connection cycle
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            //To.Create,CustomAuthorizationRequirement.and.handler
            services.AddSingleton<IAuthorizationHandler,CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                //{
                //    SourceCodeLineCount=2
                //};developerExceptionPageOptions
                app.UseDeveloperExceptionPage();
            }
            else
            {   //to.Change.to.this.section.should.replace.Development.environment
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}"); //dont change the http request
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");//to handle 404 error URL Route
            }
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseDefaultFiles(defaultFilesOptions);
            //app.UseStaticFiles();
            //app.UseFileServer(fileServerOptions);
            //app.UseFileServer();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvc();

            //app.Run(async (context) =>
            //{
                //throw new Exception("some error proccing the request ");
              //  await context.Response.WriteAsync("Hello World!");
                
            //});
        }
    }
}
