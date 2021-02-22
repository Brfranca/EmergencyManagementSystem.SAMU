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
                options.UseLazyLoadingProxies();
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
            services.AddScoped<IServiceHistoryBLL, ServiceHistoryBLL>();
            services.AddScoped<IServiceHistoryDAL, ServiceHistoryDAL>();
            services.AddScoped<ServiceHistoryValidation>();
            services.AddScoped<IVehiclePositionHistoryBLL, VehiclePositionHistoryBLL>();
            services.AddScoped<IVehiclePositionHistoryDAL, VehiclePositionHistoryDAL>();
            services.AddScoped<VehiclePositionHistoryValidation>();
            services.AddScoped<IEmergencyHistoryBLL, EmergencyHistoryBLL>();
            services.AddScoped<IEmergencyHistoryDAL, EmergencyHistoryDAL>();
            services.AddScoped<EmergencyHistoryValidation>();
            services.AddScoped<IPatientBLL, PatientBLL>();
            services.AddScoped<IPatientDAL, PatientDAL>();
            services.AddScoped<PatientValidation>();
            services.AddScoped<IMedicalEvaluationBLL, MedicalEvaluationBLL>();
            services.AddScoped<IMedicalEvaluationDAL, MedicalEvaluationDAL>();
            services.AddScoped<MedicalEvaluationValidation>();
            services.AddScoped<IMemberBLL, MemberBLL>();
            services.AddScoped<IMemberDAL, MemberDAL>();
            services.AddScoped<MemberValidation>();
            services.AddScoped<MedicalDecisionHistoryValidation>();
            services.AddScoped<IMedicalDecisionHistoryBLL, MedicalDecisionHistoryBLL>();
            services.AddScoped<IMedicalDecisionHistoryDAL, MedicalDecisionHistoryDAL>();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<Address, AddressModel>();

                cfg.CreateMap<EmergencyModel, Emergency>()
                .ForMember(a => a.Address, b => b.MapFrom(c => c.AddressModel))
                .ForMember(a => a.EmergencyRequiredVehicles, d => d.MapFrom(d => d.EmergencyRequiredVehicleModels))
                .ForMember(a => a.EmergencyHistories, d => d.MapFrom(d => d.EmergencyHistoryModels))
                .ForMember(a => a.Patients, d => d.MapFrom(d => d.PatientModels))
                .ForMember(a => a.MedicalEvaluations, d => d.MapFrom(d => d.MedicalEvaluationModels))
                .ForMember(a => a.ServiceHistories, d => d.MapFrom(d => d.ServiceHistoryModels))
                .ForMember(a => a.MedicalDecisionHistories, d => d.MapFrom(d => d.MedicalDecisionHistoryModels));

                cfg.CreateMap<Emergency, EmergencyModel>()
                .ForMember(a => a.AddressModel, b => b.MapFrom(c => c.Address))
                .ForMember(d => d.EmergencyRequiredVehicleModels, d => d.MapFrom(d => d.EmergencyRequiredVehicles))
                .ForMember(a => a.EmergencyHistoryModels, d => d.MapFrom(d => d.EmergencyHistories))
                .ForMember(a => a.PatientModels, d => d.MapFrom(d => d.Patients))
                .ForMember(a => a.MedicalEvaluationModels, d => d.MapFrom(d => d.MedicalEvaluations))
                .ForMember(a => a.ServiceHistoryModels, d => d.MapFrom(d => d.ServiceHistories))
                .ForMember(a => a.MedicalDecisionHistoryModels, d => d.MapFrom(d => d.MedicalDecisionHistories));

                cfg.CreateMap<EmergencyRequiredVehicleModel, EmergencyRequiredVehicle>();
                cfg.CreateMap<EmergencyRequiredVehicle, EmergencyRequiredVehicleModel>();
                cfg.CreateMap<TeamMemberModel, TeamMember>();
                cfg.CreateMap<TeamMember, TeamMemberModel>();
                cfg.CreateMap<Vehicle, VehicleModel>();
                cfg.CreateMap<VehicleModel, Vehicle>();

                cfg.CreateMap<ServiceHistory, ServiceHistoryModel>()
                .ForMember( a => a.VehiclePositionHistoryModels, d => d.MapFrom(d => d.VehiclePositionHistories))
                .ForMember(a => a.VehicleModel, d => d.MapFrom(d => d.Vehicle));

                cfg.CreateMap<ServiceHistoryModel, ServiceHistory>()
                .ForMember(a => a.VehiclePositionHistories, d => d.MapFrom(d => d.VehiclePositionHistoryModels))
                .ForMember(a => a.Vehicle, d => d.MapFrom(d => d.VehicleModel));

                cfg.CreateMap<VehiclePositionHistory, VehiclePositionHistoryModel>();
                cfg.CreateMap<VehiclePositionHistoryModel, VehiclePositionHistory>();
                cfg.CreateMap<EmergencyHistoryModel, EmergencyHistory>();
                cfg.CreateMap<EmergencyHistory, EmergencyHistoryModel>();
                cfg.CreateMap<PatientModel, Patient>();
                cfg.CreateMap<Patient, PatientModel>();
                cfg.CreateMap<MedicalEvaluationModel, MedicalEvaluation>().ForMember(d => d.Patient, d => d.MapFrom(d => d.PatientModel));
                cfg.CreateMap<MedicalEvaluation, MedicalEvaluationModel>().ForMember(d => d.PatientModel, d => d.MapFrom(d => d.Patient));
                cfg.CreateMap<Member, MemberModel>();
                cfg.CreateMap<MemberModel, Member>();
                cfg.CreateMap<MedicalDecisionHistory, MedicalDecisionHistoryModel>();
                cfg.CreateMap<MedicalDecisionHistoryModel, MedicalDecisionHistory>();


            }).CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)
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

            context.Database.Migrate();
        }
    }
}
