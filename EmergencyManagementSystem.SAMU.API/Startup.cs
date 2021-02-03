using AutoMapper;
using EmergencyManagementSystem.SAMU.BLL.BLL;
using EmergencyManagementSystem.SAMU.BLL.Validations;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.DAL;
using EmergencyManagementSystem.SAMU.DAL.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmergencyManagementSystem.SAMU.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmergencyManagementSystem.SAMU.API", Version = "v1" });
            });

            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(
                Configuration.GetConnectionString("Default"));
            }, ServiceLifetime.Scoped);


            services.AddScoped<IAddressBLL, AddressBLL>();
            services.AddScoped<IAddressDAL, AddressDAL>();
            services.AddScoped<AddressValidation>();
            services.AddScoped<IEmergencyRequiredVehicleDAL, EmergencyRequiredVehicleDAL>();
            services.AddScoped<IEmergencyRequiredVehicleBLL, EmergencyRequiredVehicleBLL>();
            services.AddScoped<EmergencyRequiredVehicleValidation>();
            services.AddScoped<IEmergencyBLL, EmergencyBLL>();
            services.AddScoped<IEmergencyDAL, EmergencyDAL>();
            services.AddScoped<EmergencyValidation>();
            services.AddScoped<ITeamMemberBLL, TeamMemberBLL>();
            services.AddScoped<ITeamMemberDAL, TeamMemberDAL>();
            services.AddScoped<TeamMemberValidation>();
            services.AddScoped<IVehicleBLL, VehicleBLL>();
            services.AddScoped<IVehicleDAL, VehicleDAL>();
            services.AddScoped<VehicleValidation>();
            services.AddScoped<IVehicleTeamBLL, VehicleTeamBLL>();
            services.AddScoped<IVehicleTeamDAL, VehicleTeamDAL>();
            services.AddScoped<VehicleTeamValidation>();
            services.AddScoped<IVehiclePositionHistoryBLL, VehiclePositionHistoryBLL>();
            services.AddScoped<IVehiclePositionHistoryDAL, VehiclePositionHistoryDAL>();
            services.AddScoped<VehiclePositionHistoryValidation>();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<EmergencyModel, Emergency>();
                cfg.CreateMap<Emergency, EmergencyModel>();
                cfg.CreateMap<EmergencyRequiredVehicleModel, EmergencyRequiredVehicle>();
                cfg.CreateMap<EmergencyRequiredVehicle, EmergencyRequiredVehicleModel>();
                cfg.CreateMap<TeamMemberModel, TeamMember>();
                cfg.CreateMap<TeamMember, TeamMemberModel>();
                cfg.CreateMap<Vehicle, VehicleModel>();
                cfg.CreateMap<VehicleModel, Vehicle>();
                cfg.CreateMap<VehicleTeam, VehicleTeamModel>();
                cfg.CreateMap<VehicleTeamModel, VehicleTeam>();
                cfg.CreateMap<VehiclePositionHistory, VehiclePositionHistoryModel>();
                cfg.CreateMap<VehiclePositionHistoryModel, VehiclePositionHistory>();


            }).CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmergencyManagementSystem.SAMU.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
