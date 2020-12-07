using System;
using ifound_api.Backoffice.Domain.Business;
using Core.Business;
using Core.IOC;
using Core.Messaging;
using Core.Model;
using Core.Repository;
using Core.Repository.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace ifound_api
{
    public static class ContainerIoc
    {
        public static IServiceProvider InitializeIoC(IServiceCollection services)
        {
            DependencyResolution.Instance.Container.Configure(x => x.For<IConflictsResolved>().Use<DatabaseWinsConflictsResolved>());
            DependencyResolution.Instance.Container.Configure(x => x.For<IUnitOfWork>().Use<SGPDataUnitOfWork>().AlwaysUnique());

            /*************************************************************************************************
            *        Mapeia todas as interfaces de repositório comum para os repositórios bases              *
            **************************************************************************************************/
            DependencyResolution.Instance.Container.Configure(config =>
            {
                //Padrão
                config.Scan(scanner =>
                {
                    scanner.Assembly("octeto-core");

                    //repositórios
                    scanner.AddAllTypesOf(typeof(IQueryRepository<>));
                    scanner.AddAllTypesOf(typeof(ICommandRepository<>));

                    //business - somente para model
                    scanner.AddAllTypesOf(typeof(IQueryBusiness<>));
                    scanner.AddAllTypesOf(typeof(ICommandBusiness<>));

                    //business - para usar com model/viewmodel
                    scanner.AddAllTypesOf(typeof(IQueryBusiness<,>));
                    scanner.AddAllTypesOf(typeof(ICommandBusiness<,>));

                    scanner.WithDefaultConventions();
                });

                //Populate the container using the service collection
                config.Populate(services);
            });


            /*********************************
            *        Events Handlers         *
            **********************************/
            DependencyResolution.Instance.Container.Configure(x => x.Scan(scanner =>
            {
                scanner.Assembly("ifound-api");
                scanner.AddAllTypesOf(typeof(IModelConvertibleHandler<,>));
                scanner.AddAllTypesOf(typeof(IEventHandler<>));
            }));

            /*************************************************************************************************
            *        Para os casos onde é necessária a customização                                          *
            **************************************************************************************************/
            DependencyResolution.Instance.Container.Configure(x =>
            {
                //x.For<ILogRepository>().Use<SaveOnDiscRepositorio>();

                //Tipos que não utilizarão o repositório base
                x.For<ILostOrFoundBusiness>().Use<LostOrFoundBusiness>();
            });

            return DependencyResolution.Instance.Container.GetInstance<IServiceProvider>();
        }
    }
}