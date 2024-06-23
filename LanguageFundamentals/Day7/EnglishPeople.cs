namespace Day7
{
    public class EnglishPeople : SayHello
    {
        //follow the enforce detail implementation process here because contract between English and SayHello
        public override void AboutMe()
        {
            Console.WriteLine("I am English.");
        }

        public override void SayGreetingMessage()
        {
            Console.WriteLine("Hello, Nice to see you");
        }
        public override void WorkDo()
        {
            Console.WriteLine("doing work at " + base.Address);
        }
    }
}