using System;
using System.Collections.Generic;
using System.Linq;

class WorkingHours
{
    static void Main()
    {
        // Sample Usage
        var application = new HoursTrackingApplication();

        // Adding fellows
        var ujjwal = new Fellow("Ujjwal");
        var aarati = new Fellow("Aarati");
        var shyam = new Fellow("Shyam");

        application.AddFellow(ujjwal);
        application.AddFellow(aarati);
        application.AddFellow(shyam);

        // Adding projects
        var projectX = new Project("ProjectX");
        var projectY = new Project("ProjectY");

        application.AddProject(projectX);
        application.AddProject(projectY);

        // Adding working hours with random values
        var random = new Random();

        ujjwal.AddWorkingHours(new WorkingDay(DateTime.Parse("2023-11-01"), projectX, random.Next(1, 10)));
        ujjwal.AddWorkingHours(new WorkingDay(DateTime.Parse("2023-11-02"), projectY, random.Next(1, 10)));

        aarati.AddWorkingHours(new WorkingDay(DateTime.Parse("2023-11-01"), projectX, random.Next(1, 10)));
        aarati.AddWorkingHours(new WorkingDay(DateTime.Parse("2023-11-03"), projectX, random.Next(1, 10)));

        shyam.AddWorkingHours(new WorkingDay(DateTime.Parse("2023-11-02"), projectY, random.Next(1, 10)));
        shyam.AddWorkingHours(new WorkingDay(DateTime.Parse("2023-11-03"), projectX, random.Next(1, 10)));

        // Displaying hours
        application.DisplayHoursByFellow(ujjwal);
        application.DisplayHoursByWeek(DateTime.Parse("2023-11-01"));
        application.DisplayHoursByProject(projectX);

        // Save data to database or text file (You can implement this based on your needs)
        application.SaveData();

        Console.ReadLine();
    }
}

class HoursTrackingApplication
{
    private List<Fellow> fellows;
    private List<Project> projects;

    public HoursTrackingApplication()
    {
        fellows = new List<Fellow>();
        projects = new List<Project>();
    }

    public void AddFellow(Fellow fellow)
    {
        fellows.Add(fellow);
    }

    public void AddProject(Project project)
    {
        projects.Add(project);
    }

    public void DisplayHoursByFellow(Fellow fellow)
    {
        Console.WriteLine($"Working Hours for {fellow.Name}:");
        foreach (var day in fellow.WorkingDays)
        {
            Console.WriteLine($"{day.Date.ToShortDateString()} - {day.Project.Name}: {day.Hours} hours");
        }
        Console.WriteLine();
    }

    public void DisplayHoursByWeek(DateTime weekStartDate)
    {
        Console.WriteLine($"Working Hours for Week starting from {weekStartDate.ToShortDateString()}:");
        foreach (var fellow in fellows)
        {
            var weeklyHours = fellow.GetWeeklyHours(weekStartDate);
            if (weeklyHours > 0)
            {
                Console.WriteLine($"{fellow.Name}: {weeklyHours} hours");
            }
        }
        Console.WriteLine();
    }

    public void DisplayHoursByProject(Project project)
    {
        Console.WriteLine($"Working Hours for Project {project.Name}:");
        foreach (var fellow in fellows)
        {
            var projectHours = fellow.GetHoursByProject(project);
            if (projectHours > 0)
            {
                Console.WriteLine($"{fellow.Name}: {projectHours} hours");
            }
        }
        Console.WriteLine();
    }

    public void SaveData()
    {
        // Implement saving data to database or text file
        Console.WriteLine("Data saved successfully.");
    }
}

class Fellow
{
    public string Name { get; }
    public List<WorkingDay> WorkingDays { get; }

    public Fellow(string name)
    {
        Name = name;
        WorkingDays = new List<WorkingDay>();
    }

    public void AddWorkingHours(WorkingDay workingDay)
    {
        WorkingDays.Add(workingDay);
    }

    public double GetWeeklyHours(DateTime weekStartDate)
    {
        return WorkingDays
            .Where(day => day.Date >= weekStartDate && day.Date < weekStartDate.AddDays(7))
            .Sum(day => day.Hours);
    }

    public double GetHoursByProject(Project project)
    {
        return WorkingDays
            .Where(day => day.Project == project)
            .Sum(day => day.Hours);
    }
}

class WorkingDay
{
    public DateTime Date { get; }
    public Project Project { get; }
    public double Hours { get; }

    public WorkingDay(DateTime date, Project project, double hours)
    {
        Date = date;
        Project = project;
        Hours = hours;
    }
}

class Project
{
    public string Name { get; }

    public Project(string name)
    {
        Name = name;
    }
}
