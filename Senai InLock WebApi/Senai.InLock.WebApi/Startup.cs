using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Senai.InLock.WebApi {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_0);

            services.AddAuthentication(
                item =>{
                    item.DefaultAuthenticateScheme = "JwtBearer";
                    item.DefaultChallengeScheme = "JwtBearer";
                }
            ).AddJwtBearer(
               x =>{
                   x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters(){
                       ValidateIssuer = true,
                       ValidIssuer = "InLockApi",

                       ValidateAudience = true,
                       ValidAudience = "InLockAPI",

                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.FromMinutes(30),

                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-Autenticacao-InLock"))
                   };
               }    
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            /* utilizando swagger
            app.UseSwagger();

            //gera pagina swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SVIGUFO");
            });
            */

            app.UseMvc();

            app.UseAuthentication();
        }
    }
}
