namespace Lab5PIS.Data;

public class DataInitializer
{
    public List<Student> Data()
    {
        return new List<Student>()
        {
            new Student("is-23fiot-22-106", "Yana", "Pron`", "IS-23", 2),
            new Student("is-23fiot-22-105", "Pavlo", "Ovsiyk", "IS-23", 2),
            new Student("is-23fiot-22-104", "Maksym", "Ovdiienko", "IS-23", 2),
            new Student("is-23fiot-22-103", "Dmytro", "Nifontov", "IS-23", 2),
            new Student("is-23fiot-22-102", "Kirill", "Nesterenko", "IS-23", 2),
        };
    }
}