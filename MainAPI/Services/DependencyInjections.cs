using MainAPI.Data;
using MainAPI.Business;
using MainAPI.Business.DarlosValley;
using MainAPI.Data.Interface;
using MainAPI.Data.Interface.DarlosValley;
using MainAPI.Data.Repository;
using MainAPI.Data.Repository.DarlosValley;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainAPI.Data.Interface.CP;
using MainAPI.Data.Repository.CP;
using MainAPI.Business.CP;

namespace MainAPI.Services
{
    public static class DependencyInjections
    {
        public static void Register (IServiceCollection services)
        {
            services

                .AddTransient<EncryptionService>()
                .AddTransient<JWTService>()
                .AddTransient<EmailService>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient(typeof(IGeneric<>), typeof(GenericRepository<>))
                
                .AddTransient<IStatusEnum, StatusEnumRepository>().AddTransient<StatusEnumBusiness>()
                .AddTransient<IWork, WorkRepository>().AddTransient<WorkBusiness>()
                .AddTransient<IBlog, BlogRepository>().AddTransient<BlogBusiness>()
                .AddTransient<IPerson, PersonRepository>().AddTransient<PersonBusiness>()
                .AddTransient<IUser, UserRepository>().AddTransient<UserBusiness>()
                .AddTransient<IImageSet, ImageSetRepository>().AddTransient<ImageSetBusiness>();
        }
    }
}
