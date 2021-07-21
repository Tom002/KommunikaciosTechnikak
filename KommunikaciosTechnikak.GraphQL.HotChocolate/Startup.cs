using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Dataloader;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Subscriptions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<ProductSubscriptions>()
                .AddInMemorySubscriptions()
                .AddAuthorization()
                .AddFiltering()
                .AddSorting()
                .AddProjections();


            services.AddPooledDbContextFactory<AdventureWorks2019Context>(
                opt => opt.UseSqlServer("Data Source=localhost;Initial Catalog=AdventureWorks2019;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", x => x.UseNetTopologySuite())
                          .EnableSensitiveDataLogging());

            //services.AddDbContext<AdventureWorks2019Context>();

            services.AddAutoMapper(typeof(MappingProfile));

            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token.TokenSecret));
            services
               .AddAuthentication(opt =>
               {
                   opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                   opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(opt =>
               {
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = key,
                       ValidateAudience = false,
                       ValidateIssuer = false
                   };
               });

            services.AddAuthorization();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
                builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44322"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Subscription használata esetén kell
            app.UseWebSockets();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
