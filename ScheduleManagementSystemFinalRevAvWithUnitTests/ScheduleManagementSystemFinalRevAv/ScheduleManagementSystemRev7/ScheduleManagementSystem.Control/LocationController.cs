using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Control
{
    public class LocationController
    {
        private ILocationRetriever _locationRetriever = DependancyInjection.Instance.Resolve<ILocationRetriever>();
        private ILocationSaver _locationSaver = DependancyInjection.Instance.Resolve<ILocationSaver>();

        private IView _view;

        public interface IView
        {
            /// <summary>
            /// Alerts user of error
            /// </summary>
            /// <param name="errorMessage"></param>
            void NotifyError(string errorMessage);
        }

        public LocationController(IView view)
        {
            _view = view;
        }

        public List<ILocationMaster> GetAllLocations()
        {
            return _locationRetriever.GetAllLocations();
        }

        public void InsertLocation(ILocationMaster location)
        {
            _locationSaver.SaveLocation(location);
        }

        public void RemoveLocation(int locationId)
        {
            _locationSaver.RemoveLocation(locationId);
        }

        public ILocationMaster GetLocationByLocationId(int locationId)
        {
            return _locationRetriever.GetLocationByLocationId(locationId);
        }
    }
}
