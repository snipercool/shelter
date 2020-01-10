using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelter.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;

namespace Shelter.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddScoped<IShelterDataAccess, ShelterDataAccess>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Shelter API",
                    Version = "v1",
                    Description = "ASP.NET Core Web API for our shelter"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("https://dev-4t6ikzdl.auth0.com/oauth/token", UriKind.Absolute),
                            AuthorizationUrl = new Uri("https://dev-4t6ikzdl.auth0.com/authorize", UriKind.Absolute),
                            Scopes = new Dictionary<string, string>
                            {
                                { "read:animals", "" },
                                { "read:shelters", "" },
                                { "delete:animal", "" },
                                { "edit:animal", "" },
                                { "create:animal", "" },
                            }
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] {"read:animals", "read:shelters", "delete:animal", "edit:animal", "create:animal"}
                    }
                });


            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:shelters", policy => policy.Requirements.Add(new HasScopeRequirement("read:shelters", domain)));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:animals", policy => policy.Requirements.Add(new HasScopeRequirement("read:animals", domain)));
            });

            // register the scope authorization handler
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddControllersWithViews();
            services.AddDbContext<ShelterContext>(options => options.UseSqlite(Configuration.GetConnectionString("ShelterContext")));
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            services.AddMvc(option => option.EnableEndpointRouting = false);

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseInitializer databaseInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("JzclweYI3P54FBUV4f8siUuPYibtilRB");
                c.OAuthClientSecret("b3CxcLiuNO2lEJc8gMbNdHQPzf4Vz0cZQue6JvN5VNR3L8ZjXhwuOYI5QfnHX8QH");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shelter API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
            });
            databaseInitializer.Initialize();
        }
    }
}
