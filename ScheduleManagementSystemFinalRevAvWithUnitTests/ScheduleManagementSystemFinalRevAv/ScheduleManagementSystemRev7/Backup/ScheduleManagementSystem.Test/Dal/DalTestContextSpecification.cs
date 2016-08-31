using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Dal;
using System.Configuration;

namespace ScheduleManagementSystem.Test.Dal
{
    public abstract class DalTestContextSpecification : TestContextSpecification
    {
        protected ILocationRetriever LocationRetriever { get; private set; }
        protected IMeetingScheduler MeetingScheduler { get; private set; }
        protected IMeetingRetriever MeetingRetriever { get; private set; }
        protected IUserRetriever UserRetriever { get; private set; }
        protected IUserSaver UserSaver { get; private set; }

        public DalTestContextSpecification()
        {
            LocationRetriever = new MeetingRepository(ConfigurationManager.ConnectionStrings["RyanLaptop"].ConnectionString);
            MeetingScheduler = new MeetingRepository(ConfigurationManager.ConnectionStrings["RyanLaptop"].ConnectionString);
            MeetingRetriever = new MeetingRepository(ConfigurationManager.ConnectionStrings["RyanLaptop"].ConnectionString);
            UserRetriever = new UserRepository(ConfigurationManager.ConnectionStrings["RyanLaptop"].ConnectionString);
            UserSaver = new UserRepository(ConfigurationManager.ConnectionStrings["RyanLaptop"].ConnectionString);

            //LocationRetriever = new MeetingRepository(ConfigurationManager.ConnectionStrings["Ryan7DMS"].ConnectionString);
            //MeetingScheduler = new MeetingRepository(ConfigurationManager.ConnectionStrings["Ryan7DMS"].ConnectionString);
            //MeetingRetriever = new MeetingRepository(ConfigurationManager.ConnectionStrings["Ryan7DMS"].ConnectionString);
            //UserRetriever = new UserRepository(ConfigurationManager.ConnectionStrings["Ryan7DMS"].ConnectionString);
            //UserSaver = new UserRepository(ConfigurationManager.ConnectionStrings["Ryan7DMS"].ConnectionString);
        }
    }
}
