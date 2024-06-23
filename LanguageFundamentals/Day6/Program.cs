// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Human human = new Human()
{
    Type = "Human",
    Name = "Mg Mg",
    LifeSpan = 21,
    BloodType = "B",
    IdCard = "12/Datka(11)123456",
    Occupation = "Student"
};

Dog dog = new Dog()
{
    Type = "Dog",
    Name = "Jucy",
    LifeSpan = 20
};

Console.WriteLine(human);
human.Sound();
Console.WriteLine(dog);
dog.Sound();