public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public Project FinalProject { get; set; }
}

public class Project
{
    public int Id { get; set; }

    public string Description { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime FinishedAt { get; set; }

    public string GitHubUrl { get; set; }

    public Student Student { get; set; }
}

var s1 = new Student("Blah Blah");
var s2 = new Student("John Blah");

var p1 = new Project("Super fun project!");

s1.FinalProject = p1;
s2.FinalProject = p1;