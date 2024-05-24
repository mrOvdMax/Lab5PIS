namespace Lab5PIS;

public class Student
{
    //public int Id { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Group { get; set; }
    
    public int YearOfEducation { get; set; }

    public Student(string login, string name, string surname, string group, int yearOfEducation)
    {
        Login = login;
        Name = name;
        Surname = surname;
        Group = group;
        YearOfEducation = yearOfEducation;
    }
}