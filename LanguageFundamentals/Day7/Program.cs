// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
EnglishPeople englishPeople = new EnglishPeople()
{
    Name = "Smith",
    Address = "USA"
};
englishPeople.DisplayInfo();
englishPeople.AboutMe();
englishPeople.SayGreetingMessage();
englishPeople.WorkDo();

JapanesePeople japanesePeople= new JapanesePeople()
{
    Name = "Amoi",
    Address = "Tokyo"
}
japanesePeople.DisplayInfo();
japanesePeople.AboutMe();
japanesePeople.SayGreetingMessage();
japanesePeople.WorkDo();