using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScheduleManagementSystem.Test
{
    public abstract class TestContextSpecification
    {
        private TestContext _testContextInstance;

        /// <summary>
        /// gets or sets the test context which provides the information and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        /// <summary>
        /// Steps that are run before each test
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {
            try
            {
                BecauseOf();
            }
            catch (Exception becauseOfException)
            {
                try
                {
                    Cleanup();
                    throw becauseOfException;
                }
                catch (Exception ex)
                {
                    throw new Exception(becauseOfException.Message, ex);
                }

            }
        }

        /// <summary>
        /// Steps that are run after each test.
        /// </summary>
        [TestCleanup()]
        public void TestCleanUp()
        {
            Cleanup();
        }

        /// <summary>
        /// Acts on the context to create the observable condition.
        /// </summary>
        protected abstract void BecauseOf();

        /// <summary>
        /// Cleans up the context after the specification is verified.
        /// </summary>
        protected abstract void Cleanup();


    }
}
