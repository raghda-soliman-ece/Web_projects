using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a simple C# console application to manage tracks and courses, where each track can have an array of courses. 
//Use a base class Track with properties like TrackId, TrackName, and DurationInMonths, and a derived class Course
//with additional properties such as CourseId, CourseName, and Hours.
//Note that we have different types of Courses as next 
//ProgrammingCourse → adds Language or Level
//DesignCourse → adds Tools or Specialization
//MathCourse → adds Difficulty or Credits
//Implement constructors that demonstrate constructor chaining with the base keyword, and add a C# indexer in the Track class to access courses by index.
//Provide methods to add courses to a track and display all courses. 
//In Main, create a few tracks with multiple courses, use the indexer to access courses, and display their information, applying inheritance, composition, and indexers together.

namespace ConsoleApp1
{
    class Course
    {


        public string Name { get; set; }
        public int ID { get; set; }
        public int Hours { get; set; }


        public Course(string Name, int Id)
        {
            this.Name = Name;
            this.ID = Id;
        }
        public Course(int Id)
        {
            this.ID = Id;
        }
        public Course(int Id, int Hours) : this(Id)
        {
            this.Hours = Hours;
        }

        public Course(string Name, int Id, int Hours) : this(Name, Id)
        {
            this.Hours = Hours;
        }

        public virtual string GetDetails()
        {
            return $"ID: {ID} | Name: {Name} | Hours: {Hours}";
        }
    }

    class ProgrammingCourse : Course
    {
        public string Language { get; set; }
        public ProgrammingCourse(int id, string name, int hours, string language)
            : base(name, id, hours)
        {
            this.Language = language;
        }
        public override string GetDetails()
        {
            return base.GetDetails() + $" | Language: {Language}";
        }
    }

    class DesignCourse : Course
    {
        public string Tool { get; set; }

        public DesignCourse(int id, string name, int hours, string tool)
            : base(name, id, hours)
        {
            this.Tool = tool;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $" | Tool: {Tool}";
        }
    }

    class MathCourse : Course
    {
        public string Difficulty { get; set; }

        public MathCourse(int id, string name, int hours, string difficulty)
            : base(name, id, hours)
        {
            this.Difficulty = difficulty;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $" | Difficulty: {Difficulty}";
        }
    }
    class Track
    {


        public string Name { get; set; }
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public int DurationInMonths { get; set; }

        public Course this[int index]
        {
            get { return Courses[index]; }
            set { Courses[index] = value; }
        }

        public Track(int Id)
        {
            this.Id = Id;
        }

        public Track(string Name)
        {
            this.Name = Name;
        }
        public Track(int Id, int DurationInMonths) : this(Id)
        {

            this.DurationInMonths = DurationInMonths;
        }

        public Track(string Name, int Id) : this(Id)
        {
            this.Name = Name;
        }
        public Track(int DurationInMonths, string Name) : this(Name)
        {
            this.DurationInMonths = DurationInMonths;
        }
        public Track(string Name, int Id, int DurationInMonths) : this(Name, Id)
        {
            this.DurationInMonths = DurationInMonths;
        }

        public Track(string Name, int Id, Course[] Courses, int DurationInMonths) : this(Name, Id, DurationInMonths)
        {
            this.Courses = Courses;
        }

        public void PrintAllCourses()
        {
            Console.WriteLine($"--- Track: {Name} (Duration: {DurationInMonths} Months) ---");
            foreach (var course in Courses)
            {
                if (course != null)
                {
                    Console.WriteLine(course.GetDetails());
                }
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Course[] myCourses = new Course[3];

            Track webTrack = new Track(".NET Full Stack", 101, myCourses, 6);

            webTrack[0] = new ProgrammingCourse(1, "C# Basics", 40, "C#");
            webTrack[1] = new DesignCourse(2, "UI Design", 20, "Figma");
            webTrack[2] = new MathCourse(3, "Calculus", 30, "Hard");

            webTrack.PrintAllCourses();

            Console.ReadKey();
        }
    }
}
