using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job testJob;
        string testString;

        [TestInitialize]
        public void CreateTestObject()
        {
            testJob = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            testString = testJob.ToString();
        }

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
            
            Assert.AreEqual(testJob.Name, "Product tester");
            Assert.AreEqual(testJob.EmployerName.Value, "ACME");
            Assert.AreEqual(testJob.EmployerLocation.Value, "Desert");
            Assert.AreEqual(testJob.JobType.Value, "Quality control");
            Assert.AreEqual(testJob.JobCoreCompetency.Value, "Persistence");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job testJob2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsFalse (testJob.Equals(testJob2));
        }

        [TestMethod]
        public void ToStringStartsAndEndsWithBlankLine()
        {

            Assert.AreEqual(testString[0], '\n');
            Assert.AreEqual(testString[^1], '\n');
        }

        [TestMethod]
        public void ToStringContainsLabelForEachField()
        {
            Assert.IsTrue(testString.Contains("\nID: "));
            Assert.IsTrue(testString.Contains("\nName: "));
            Assert.IsTrue(testString.Contains("\nEmployer: "));
            Assert.IsTrue(testString.Contains("\nLocation: "));
            Assert.IsTrue(testString.Contains("\nPosition Type: "));
            Assert.IsTrue(testString.Contains("\nCore Competency: "));
        }

        [TestMethod]
        public void EmptyFieldReturnsDataNotAvailable()
        {
            Job oneEmptyFielder = new Job("", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string emptyBoi = oneEmptyFielder.ToString();
            Assert.IsTrue(emptyBoi.Contains("Data not available"));
        }

        [TestMethod]
        public void DetectsIfJobExists()
        {
            Job emptyFielder = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            string emptyBoi = emptyFielder.ToString();
            Assert.AreEqual(emptyBoi, "OOPS! This job does not seem to exist.");
        }
    }
}
