using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Test.Dal.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Test.Dal
{
    [TestClass]
    public class when_retrieving_locations : DalTestContextSpecification
    {
        private int _locationId1;
        private int _locationId2;
        private int _locationId3;

        public when_retrieving_locations()
        {
            _locationId1 = -1;
            _locationId2 = -2;
            _locationId3 = -3;
        }
        protected override void BecauseOf()
        {
            using (DMSTestDataContext testDataContext = new DMSTestDataContext())
            {
                List<Location_MasterDto> locationMasterDtos = new List<Location_MasterDto>();
                locationMasterDtos.Add(new Location_MasterDto
                                        {
                                            IsAVAvailable = true,
                                            IsPhoneAvailable = true,
                                            IsVideoConfAvailable = true,
                                            LocationBuilding = "Building1",
                                            LocationCapacity = 10,
                                            LocationFloor = "1",
                                            LocationId = _locationId1,
                                            LocationName = "Test 1",
                                            LocationRoom = "TestRoom"
                                        });
                locationMasterDtos.Add(new Location_MasterDto
                                        {
                                            IsAVAvailable = true,
                                            IsPhoneAvailable = true,
                                            IsVideoConfAvailable = true,
                                            LocationBuilding = "Building2",
                                            LocationCapacity = 10,
                                            LocationFloor = "1",
                                            LocationId = _locationId2,
                                            LocationName = "Test 2",
                                            LocationRoom = "TestRoom"
                                        });
                locationMasterDtos.Add(new Location_MasterDto
                                        {
                                            IsAVAvailable = true,
                                            IsPhoneAvailable = true,
                                            IsVideoConfAvailable = true,
                                            LocationBuilding = "Building3",
                                            LocationCapacity = 10,
                                            LocationFloor = "1",
                                            LocationId = _locationId3,
                                            LocationName = "Test 3",
                                            LocationRoom = "TestRoom"
                                        });

                testDataContext.Location_MasterDtos.InsertAllOnSubmit(locationMasterDtos);
                testDataContext.SubmitChanges();

                _locationId1 = locationMasterDtos.ElementAt(0).LocationId;
                _locationId2 = locationMasterDtos.ElementAt(1).LocationId;
                _locationId3 = locationMasterDtos.ElementAt(2).LocationId;

            }
        }

        protected override void Cleanup()
        {
            using (DMSTestDataContext testDataContext = new DMSTestDataContext())
            {
                testDataContext.Location_MasterDtos.DeleteAllOnSubmit(
                                            testDataContext.Location_MasterDtos.Where(c => c.LocationId == _locationId1
                                                                                        || c.LocationId == _locationId2
                                                                                        || c.LocationId == _locationId3));
                testDataContext.SubmitChanges();
            }
        }

        [TestMethod]
        public void should_return_correct_location_by_location_id()
        {
            ILocationMaster location = LocationRetriever.GetLocationByLocationId(_locationId2);

            Assert.IsTrue(location.IsAvAvailable);
            Assert.IsTrue(location.IsPhoneAvailable);
            Assert.IsTrue(location.IsVideoConfAvailable);
            Assert.AreEqual("Building2", location.LocationBuilding);
            Assert.AreEqual(10, location.LocationCapacity);
            Assert.AreEqual("1", location.LocationFloor);
            Assert.AreEqual(_locationId2, location.LocationId);
            Assert.AreEqual("Test 2", location.LocationName);
            Assert.AreEqual("TestRoom", location.LocationRoom);
        }
    }
}
