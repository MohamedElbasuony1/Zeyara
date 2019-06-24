using Common.Validations;
using Contracts;
using DAL;
using FluentValidation;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repos;
using System.Linq;
using Services;
using Common.mapping;
using AutoMapper;
using System.Reflection;
using DTOs;

namespace Common.Extentions
{
    public static class ServiceExtention
    {
        public static void ConfigureSqlContext(this IServiceCollection services, string connectionstring)
        {
            services.AddDbContext<MyContext>(a => a.UseSqlServer(connectionstring));
        }
        

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<PatientService>();
            services.AddScoped<DoctorService>();
            services.AddScoped<PasswordHasherService>();
            services.AddScoped<NotificationService>();
        }
        public static void ConfigureMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] {
                typeof(UserProfile).GetTypeInfo().Assembly,
                typeof(CertificationMapping).GetTypeInfo().Assembly,
                typeof(PhoneMapping).GetTypeInfo().Assembly,
                typeof(AddressMapping).GetTypeInfo().Assembly,
                typeof(UserProfileMapping).GetTypeInfo().Assembly });
        }
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
        public static void ConfigureRepos(this IServiceCollection services)
        {
            services.AddScoped<IAddressReposatory, AddressReposatory>();
            services.AddScoped<ICardReposatory,CardReposatory>();
            services.AddScoped<ICertificateReposatory, CertificateReposatory>();
            services.AddScoped<ICommentReposatory , CommentReposatory>();
            services.AddScoped<IDoctorReposatory, DoctorReposatory>();
            services.AddScoped<IMessageReposatory, MessageReposatory>();
            services.AddScoped<INotificationReposatory, NotificationReposatory>();
            services.AddScoped<IOnlineUserReposatory, OnlineUserReposatory>();
            services.AddScoped<IPhoneReposatory, PhoneReposatory>();
            services.AddScoped<IPromotionReposatory, PromotionReposatory>();
            services.AddScoped<IReportReposatory, ReportReposatory>();
            services.AddScoped<IRoleReposatory, RoleReposatory>();
            services.AddScoped<ISpecializationReposatory, SpecializationReposatory>();
            services.AddScoped<ITransactionReposatory, TransactionReposatory>();
            services.AddScoped<IUserPromotionReposatory, UserPromotionReposatory>();
            services.AddScoped<IUserReposatory, UserReposatory>();
            services.AddScoped<IUserTokenReposatory, UserTokenReposatory>();
        }


        public static void ConfigureValidations(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<Address>, AddressEntityValidation>();
            services.AddSingleton<IValidator<Card>, CardEntityValidation>();
            services.AddSingleton<IValidator<Certificate>, CertificateEntityValidation>();
            services.AddSingleton<IValidator<Comment>, CommentEntityValidation>();
            services.AddSingleton<IValidator<Doctor>, DoctorEntityValidation>();
            services.AddSingleton<IValidator<Message>, MessageEntityValidation>();
            services.AddSingleton<IValidator<Notification>, NotificationEntityValidation>();
            services.AddSingleton<IValidator<OnlineUser>, OnlineUserEntityValidation>();
            services.AddSingleton<IValidator<Phone>, PhoneEntityValidation>();
            services.AddSingleton<IValidator<Promotion>, PromotionEntityValidation>();
            services.AddSingleton<IValidator<Report>, ReportEntityValidation>();
            services.AddSingleton<IValidator<Role>, RoleEntityValidation>();
            services.AddSingleton<IValidator<Specialization>, SpecializationEntityValidation>();
            services.AddSingleton<IValidator<Transaction>, TransactionEntityValidation>();
            services.AddSingleton<IValidator<User>, UserEntityValidation>();
            services.AddSingleton<IValidator<UserPromotion>, UserPromotionEntityValidation>();
            services.AddSingleton<IValidator<DoctorModel>, DoctorModelEntityValidation>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureModelState(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var result = new
                    {
                        Code = "00009",
                        Message = "Validation errors",
                        Errors = errors
                    };
                    return new BadRequestObjectResult(result);
                };
            });
        }

    }
}
