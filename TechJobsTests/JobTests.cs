using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job testJob1 = new Job();
            Job testJob2 = new Job();
            Assert.AreNotEqual(testJob1.Id, testJob2.Id);
            Assert.IsTrue((testJob1.Id - testJob2.Id == 1) || (testJob2.Id - testJob1.Id == 1));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testJob = new Job("Product tester", "ACME", "Desert", "Quality control", "Persistence");
            Assert.AreEqual(testJob.Name, "Product tester");
            Assert.AreEqual(testJob.EmployerName.Value, "ACME");
            Assert.AreEqual(testJob.EmployerLocation.Value, "Desert");
            Assert.AreEqual(testJob.JobType.Value, "Quality control");
            Assert.AreEqual(testJob.JobCoreCompetency.Value, "Persistence");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job testJob1 = new Job("Product tester", "ACME", "Desert", "Quality control", "Persistence");
            Job testJob2 = new Job("Product tester", "ACME", "Desert", "Quality control", "Persistence");
            Assert.IsFalse (testJob1.Equals(testJob2));
        }
    }
}
