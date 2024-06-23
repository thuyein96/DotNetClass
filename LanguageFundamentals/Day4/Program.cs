// See https://aka.ms/new-console-template for more information
using Day4;

Console.WriteLine("Encapsulation Practice");
try
{
    Teacher teacher = new Teacher();
    teacher.Name = "U Ba";
    teacher.Address = "YGN";
    teacher.Age = 30;
    teacher.TrainingFees = 30000;
    Console.WriteLine(teacher);

    Student student = new Student();
    student.SetName("Mg Mg");
    student.SetAddress("YGN");
    student.SetAge(20);
    student.SetEmail("mgmg@email.com");
    Console.WriteLine(student);

    student student1 = new Student();
    student1.SetName("Su Su");
    student1.SetAge(21);
    student1.SetEmail("susu@email.com");
    student1.SetAddress("YGN");
    Console.WriteLine(student1);

    teacher teacher1 = new Teacher();
    teacher1.Name = "Daw Hla";
    teacher1.Address = "MDY";
    teacher1.Age = 30;
    teacher1.Email = "hlahla@email.com";
    Console.WriteLine(teacher1);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}