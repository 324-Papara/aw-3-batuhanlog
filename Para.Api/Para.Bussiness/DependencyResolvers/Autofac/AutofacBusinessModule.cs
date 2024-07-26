using Autofac;
using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Query.Customer.GetAll;
using Para.Data.DapperRepository;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register UnitOfWork instances for different domain models

            builder.RegisterType<UnitOfWork<Customer>>().As<IUnitOfWork<Customer>>().SingleInstance();
            builder.RegisterType<UnitOfWork<CustomerDetail>>().As<IUnitOfWork<CustomerDetail>>().SingleInstance();
            builder.RegisterType<UnitOfWork<CustomerPhone>>().As<IUnitOfWork<CustomerPhone>>().SingleInstance();
            builder.RegisterType<UnitOfWork<CustomerAddress>>().As<IUnitOfWork<CustomerAddress>>().SingleInstance();


            builder.RegisterType<CustomerReadOnlyRepository>().As<ICustomerReadOnlyRepository>().SingleInstance();
        }
    }
}
