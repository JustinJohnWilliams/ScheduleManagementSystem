using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.Location_Master")]
    internal class Location_MasterDto : ILocationMaster
    {
        private int _locationId;
        [Column(Storage = "_locationId", IsPrimaryKey=true, IsDbGenerated=true)]
        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        private string _locationName;
        [Column(Storage = "_locationName")]
        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        private string _locationBuilding;
        [Column(Storage = "_locationBuilding")]
        public string LocationBuilding
        {
            get { return _locationBuilding; }
            set { _locationBuilding = value; }
        }

        private string _locationFloor;
        [Column(Storage = "_locationFloor")]
        public string LocationFloor
        {
            get { return _locationFloor; }
            set { _locationFloor = value; }
        }

        private string _locationRoom;
        [Column(Storage = "_locationRoom")]
        public string LocationRoom
        {
            get { return _locationRoom; }
            set { _locationRoom = value; }
        }

        private int _locationCapacity;
        [Column(Storage = "_locationCapacity")]
        public int LocationCapacity
        {
            get { return _locationCapacity; }
            set { _locationCapacity = value; }
        }

        private bool _isAVAvailable;
        [Column(Storage = "_isAVAvailable")]
        public bool IsAVAvailable
        {
            get { return _isAVAvailable; }
            set { _isAVAvailable = value; }
        }

        private bool _isPhoneAvailable;
        [Column(Storage = "_isPhoneAvailable")]
        public bool IsPhoneAvailable
        {
            get { return _isPhoneAvailable; }
            set { _isPhoneAvailable = value; }
        }

        private bool _isVideoConfAvailable;
        [Column(Storage = "_isVideoConfAvailable")]
        public bool IsVideoConfAvailable
        {
            get { return _isVideoConfAvailable; }
            set { _isVideoConfAvailable = value; }
        }

        #region ILocationMaster Members

        int ILocationMaster.LocationId
        {
            get { return _locationId; }
        }

        string ILocationMaster.LocationName
        {
            get { return _locationName; }
        }

        string ILocationMaster.LocationBuilding
        {
            get { return _locationBuilding; }
        }

        string ILocationMaster.LocationFloor
        {
            get { return _locationFloor; }
        }

        string ILocationMaster.LocationRoom
        {
            get { return _locationRoom; }
        }

        int ILocationMaster.LocationCapacity
        {
            get { return _locationCapacity; }
        }

        bool ILocationMaster.IsAvAvailable
        {
            get { return _isAVAvailable; }
        }

        bool ILocationMaster.IsPhoneAvailable
        {
            get { return _isPhoneAvailable; }
        }

        bool ILocationMaster.IsVideoConfAvailable
        {
            get { return _isVideoConfAvailable; }
        }

        #endregion
    }
}
