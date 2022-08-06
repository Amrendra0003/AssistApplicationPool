using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using FoolProof.Core;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services;
using HealthWare.ActiveASSIST.Services.Mapper;
using HealthWare.ActiveASSIST.Web.Authentication.JwtBearer;
using HealthWare.ActiveASSIST.Web.Common.Email;
using HealthWare.ActiveASSIST.Web.Common.HttpClient;
using HealthWare.ActiveASSIST.WebAPI.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;
using Healthware.Core.Base;
using Healthware.Core.Common.Session;
using Healthware.Core.Common.Session.Mapper;
using Healthware.Core.Configurations;
using Healthware.Core.Constants;
using Healthware.Core.Containers;
using Healthware.Core.EmailService;
using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using Healthware.Core.Initialization;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.MultiTenancy.Services;
using Healthware.Core.MultiTenancy.Services.Extensions;
using Healthware.Core.MultiTenancy.Services.Interfaces;
using Healthware.Core.Repository;
using Healthware.Core.Security;
using Healthware.Core.Web.Web.Authorization;
using Healthware.Core.Web.Web.Common.HttpClient;
using Healthware.Core.Web.Web.Common.SMS;
using Healthware.Core.Web.Web.Configuration;
using HealthWare.ActiveASSIST.Web.Seed;
using Microsoft.AspNetCore.Authorization;

namespace HealthWare.ActiveASSIST.WebAPI.AppStart
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";

        private const string ApiVersion = "v1";

        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
            ApplicationSetting.setPropertyValues(_appConfiguration, env.EnvironmentName);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Configure CORS for angular8 UI
            services.AddCors(
                options => options.AddPolicy(
                    DefaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Version = ApiVersion,
                    Title = "HealthWare API",
                    Description = "HealthWare",
                    // uncomment if needed TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "ActiveASSIST",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/aspboilerplate"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://github.com/aspnetboilerplate/aspnetboilerplate/blob/dev/LICENSE"),
                    }
                });
                options.DocInclusionPredicate((docName, description) => true);
                options.OperationFilter<SwaggerCustomHeaderParameter>();

                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            var container = Ioc.WireupApi(Start.TheApplication());
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            services.AddDbContext<PatientDbContext>(options =>
                options.UseSqlServer(
                    _appConfiguration.GetConnectionString(Portal.ConnectionStringName)), ServiceLifetime.Transient);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddTransient<IUnitOfWork<PatientDbContext>, UnitOfWork<PatientDbContext>>();
            services.AddIdentity<User, Role>();


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<IVerificationService, VerificationService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAssessmentService, AssessmentService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IDropDownService, DropDownService>();
            services.AddTransient<ISessionService<PatientDbContext>, SessionService<PatientDbContext>>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IQuickAssessmentService, QuickAssessmentService>();
            services.AddSingleton<System.Net.Http.HttpClient>();
            services.AddHttpClient<HealthWareSharedService>();
            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddSingleton<IHealthWareSharedService, HealthWareSharedService>();
            services.AddTransient<ISMSService, SMSService>();
            services.AddTransient<ISubDomainService, SubDomainService>();
            services.AddTransient<IVerificationService, VerificationService>();
            services.AddTransient<IUserVerificationService, UserVerificationService>();
            services.AddTransient<IPasswordPolicyService, PasswordPolicyService>();

            services.AddTransient<IBasicInfoMapper, BasicInfoMapper>();
            services.AddTransient<IUserAccountMapper, UserAccountMapper>();
            services.AddTransient<IAssessmentMapper, AssessmentMapper>();
            services.AddTransient<IContactDetailsMapper, ContactDetailsMapper>();
            services.AddTransient<IAssessmentMapper, AssessmentMapper>();
            services.AddTransient<IGuarantorMapper, GuarantorMapper>();
            services.AddTransient<IDashboardMapper, DashboardMapper>();
            services.AddTransient<ISessionMapper, SessionMapper>();
            services.AddTransient<IFileUploadMapper, DocumentMapper>();
            services.AddTransient<IAnswerMapper, AnswerMapper>();
            services.AddTransient<IPatientProgramMappingMapper, PatientProgramMappingMapper>();
            services.AddTransient<IAssessmentVerificationMapper, AssessmentVerificationMapper>();
            services.AddTransient<IContactPreferenceMapper, ContactPreferenceMapper>();
            services.AddTransient<IUserMapper, UserMapper>();
            services.AddTransient<IHouseHoldMapper, HouseHoldMapper>();
            services.AddTransient<IDocumentLocationMapper, DocumentLocationMapper>();
            services.AddTransient<IReviewNotesMapper, ReviewNotesMapper>();
            services.AddTransient<ITabStatusMapper, TabStatusMapper>();
            services.AddTransient<IDynamicScreensMapper, DynamicScreensMapper>();
            services.AddTransient<IProgramMapper, ProgramMapper>();
            services.AddTransient<IProgramDocumentMapper, ProgramDocumentMapper>();


            services.AddTransient<IBasicInfoRepository, BasicInfoRepository>();
            services.AddTransient<IHouseHoldMemberRepository, HouseHoldMemberRepository>();
            services.AddTransient<IContactDetailsRepository<PatientDbContext>, ContactDetailsRepository<PatientDbContext>>();
            services.AddTransient<IGuarantorRepository, GuarantorRepository>();
            services.AddTransient<IHouseHoldIncomeRepository, HouseHoldIncomeRepository>();
            services.AddTransient<IHouseHoldResourceRepository, HouseHoldResourceRepository>();
            services.AddTransient<IAssessmentRepository, AssessmentRepository>();
            services.AddTransient<IProgramRepository, ProgramRepository>();
            services.AddTransient<ISessionActivityRepository<PatientDbContext>, SessionActivityRepository<PatientDbContext>>();
            services.AddTransient<IAssessmentVerificationRepository, AssessmentVerificationRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IProgramDocumentRepository, ProgramDocumentRepository>();
            services.AddTransient<IPatientProgramMappingRepository, PatientProgramMappingRepository>();
            services.AddTransient<IContactPreferenceRepository, ContactPreferenceRepository>();
            services.AddTransient<IUserHasRolesRepository, UserHasRolesRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IReviewNotesRepository, ReviewNotesRepository>();
            services.AddTransient<IDocumentCategoryMasterRepository, DocumentCategoryMasterRepository>();
            services.AddTransient<IDocumentTypeMasterRepository, DocumentTypeMasterRepository>();
            services.AddTransient<IDocumentCategoryDocumentTypeMappingRepository, DocumentCategoryDocumentTypeMappingRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IHouseholdMemberDocumentMappingRepository, HouseholdMemberDocumentMappingRepository>();
            services.AddTransient<IDocumentProgramMappingRepository, DocumentProgramMappingRepository>();
            services.AddTransient<ITabStatusRepository, TabStatusRepository>();
            services.AddTransient<IVerificationDocumentRepository, VerificationDocumentRepository>();
            services.AddTransient<ISubDomainRepository, SubDomainRepository>();
            services.AddTransient<IPasswordPolicyRepository, PasswordPolicyRepository>();

            var fileUploadConfig = _appConfiguration
                .GetSection(nameof(DocumentConfiguration))
                .Get<DocumentConfiguration>();
            services.AddSingleton(fileUploadConfig);
            services.AddScoped<IFileUploadServiceHelper, DocumentServiceHelper>();

            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<ICurrentHttpContext, CurrentHttpContext>();
            services.AddRazorPages();
            services.AddTransient<IUserStore<User>, UserRepository>();
            services.AddTransient<IRoleStore<Role>, RoleRepository>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<Role>>();
            //FoolProof Package
            services.AddFoolProof();
            var emailConfig = _appConfiguration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IEmailSender, EmailSender>();

            //MultiTenancy

            services.Configure<TenantSettings>(_appConfiguration.GetSection(nameof(TenantSettings)));
            services.AddAndMigrateTenantDatabases<PatientDbContext>(_appConfiguration);

            container.Register(Component.For<TokenAuthConfiguration>().LifestyleSingleton());
            var tokenAuthConfig = Resolve.AnImplementationOf<TokenAuthConfiguration>();
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.SecurityKey =
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));

            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials =
                new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
            services.AddSingleton<TokenAuthConfiguration>(tokenAuthConfig);
            container.Register(Component.For<IUserClaimsPrincipalFactory<User>>()
                .ImplementedBy<CoreUserClaimsPrincipalFactory<User, Role>>()
                .LifestyleScoped());

            services.AddControllers().AddControllersAsServices();
            services.AddSingleton(new ClientCredentialsTokenRequest(_appConfiguration[Portal.HWSServiceBaseUrl],
                _appConfiguration[Portal.HWSServiceTokenUri], _appConfiguration[Portal.HWSServiceUserName],
                _appConfiguration[Portal.HWSServiceAPIPassword], _appConfiguration[Portal.HWSServiceSiteId],
                _appConfiguration[Portal.HWSServiceGrantType]));

            services.AddWindsor(container,
                opts => opts.UseEntryAssembly(typeof(LoginController).Assembly), // <- Recommended
                () => services.BuildServiceProvider(validateScopes: false));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, RoleManager<Role> roleManager)
        {
            //app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

            app.UseCors(DefaultCorsPolicyName);

            app.UseStaticFiles();

            app.UseRouting();
            DataInitializer.SeedData(roleManager);
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Swagger}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                // specifying the Swagger JSON endpoint.
                options.SwaggerEndpoint($"../swagger/{ApiVersion}/swagger.json", $"HealthWare API {ApiVersion}");
                options.DisplayRequestDuration(); // Controls the display of the request duration (in milliseconds) for "Try it out" requests.  
            });
            // URL: /swagger
        }
    }
}