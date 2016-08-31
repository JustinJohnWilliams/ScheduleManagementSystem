using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Configuration;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Dal;

namespace ScheduleManagementSystem.Control
{
    public class DependancyInjection
    {
        private static IUnityContainer _instance;
        static DependancyInjection()
        {
            _instance = null;
        }

        private static IUnityContainer BuildContainer()
        {
            IUnityContainer container = new UnityContainer();



            InjectionConstructor meetingInjectionConstructor =
                new InjectionConstructor(ConfigurationManager.ConnectionStrings["JustinHomeDMS"].ConnectionString);
            //InjectionConstructor meetingInjectionConstructor =
            //      new InjectionConstructor(ConfigurationManager.ConnectionStrings["Ryan7DMS"].ConnectionString);
            //InjectionConstructor meetingInjectionConstructor =
            //        new InjectionConstructor(ConfigurationManager.ConnectionStrings["RyanLaptop"].ConnectionString);


            container.RegisterType<IMeetingScheduler, MeetingRepository>()
                .Configure<InjectedMembers>()
                .ConfigureInjectionFor<MeetingRepository>(meetingInjectionConstructor);

            container.RegisterType<IMeetingRetriever, MeetingRepository>()
                .Configure<InjectedMembers>()
                .ConfigureInjectionFor<MeetingRepository>(meetingInjectionConstructor);

            container.RegisterType<IUserSaver, UserRepository>()
                .Configure<InjectedMembers>()
                .ConfigureInjectionFor<UserRepository>(meetingInjectionConstructor);

            container.RegisterType<IUserRetriever, UserRepository>()
                .Configure<InjectedMembers>()
                .ConfigureInjectionFor<UserRepository>(meetingInjectionConstructor);

            container.RegisterType<ILocationRetriever, MeetingRepository>()
                .Configure<InjectedMembers>()
                .ConfigureInjectionFor<MeetingRepository>(meetingInjectionConstructor);

            container.RegisterType<ILocationSaver, MeetingRepository>()
                .Configure<InjectedMembers>()
                .ConfigureInjectionFor<MeetingRepository>(meetingInjectionConstructor);

            container.Configure<InjectedMembers>()
                .ConfigureInjectionFor<CustomSettingRepository>(meetingInjectionConstructor);

            return container;
        }

        public static IUnityContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = BuildContainer();
                }

                return _instance;
            }
        }
    }
}
