using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }
        private int _emptyFieldCounter;

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency; 
        }

        public string CheckForEmptyField(string value)
        {
            if (value == "" || value == null)
            {
                _emptyFieldCounter++; //If this counter reaches 5, the job "doesn't exist" and prints a special message
                return "Data not available";
            }
            else
            {
                return value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            string[] valueArray = { Name, EmployerName.Value, EmployerLocation.Value, JobType.Value, JobCoreCompetency.Value };
            int x = 0;
            foreach (string value in valueArray)
            {
                valueArray[x] = CheckForEmptyField(value);
                x++;
            }

            if(_emptyFieldCounter == 5)
            {
                return "OOPS! This job does not seem to exist.";
            }

            string formattedString = $"\nID: {Id}" +
                $"\nName: {valueArray[0]}" +
                $"\nEmployer: {valueArray[1]}" +
                $"\nLocation: {valueArray[2]}" +
                $"\nPosition Type: {valueArray[3]}" +
                $"\nCore Competency: {valueArray[4]}\n";
            return formattedString;
        }
    }
}
