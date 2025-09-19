using System;
using System.IO;

class Student
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";

    public int Age { get; set; } = 0;

    public string Department { get; set; } = "";

    public Student(int id = 0, string name = "", int age = 0, string dep = "")
    {
        Id = id ;
        Name = name ?? "";
        Department = dep ?? "";
        Age = age ;
    }

    public Student()
    {
        
    }

    public override string ToString()
    {
        return $"{Id},{Name},{Department},{Age}";
    }
}


class Program
{
    static void AddStudent()
    {
        Console.WriteLine("Enter Id:");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Enter Name: ");
        string? name = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Age: ");
        int age = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Enter Department: ");
        string? dep = Console.ReadLine() ?? "";

        // Student s = new Student(id, name, age, dep);

        Student s = new Student { Id = id, Name = name, Age = age, Department = dep };

        using FileStream fin = new FileStream("text.txt", FileMode.Append);

        using StreamWriter Sw = new StreamWriter(fin);

        Sw.WriteLine(s.ToString());

        // Sw.Close();                because using  , using
        // fin.Close();

        Console.WriteLine("Student Added!");
    }


    static void ReadStudents()
    {
        if (File.Exists("text.txt"))
        {
            using FileStream fout = new FileStream("text.txt", FileMode.Open);

            using StreamReader Sr = new StreamReader(fout);

            string? LineRead = "";
            
            while ((LineRead = Sr.ReadLine()) != null)
            {
                Console.WriteLine(LineRead);
            }
            // Sr.Close();
            // fout.Close();
        }
        else
        {
            Console.WriteLine("text.txt doesnot exists");
        }
    }
    static void Main(string[] args)
    {
        bool start = true;
        while (start)
        {
            Console.WriteLine("Menu");

            Console.WriteLine("Add Student by Entering 1");
            Console.WriteLine("Read Student List by Entering 2");
            Console.WriteLine("For Exit Enter 3");
            
            string? inputchoice = Console.ReadLine();

            switch (inputchoice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ReadStudents();
                    break;
                case "3":
                    start = false;
                    break;
                default:
                    Console.WriteLine("You have to choose 1, 2 or 3. No other Option");
                    break;
            }
        }
    }
}
