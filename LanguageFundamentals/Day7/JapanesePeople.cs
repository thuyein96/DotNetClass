namespace Day7
{
    public class JapanesePeople:SayHello
    {
        public override void AboutMe()
        {
            Console.WriteLine("I am Japanese.");
        }

        public override void SayGreetingMessage()
        {
            Console.WriteLine("Kohnichiwa")
        }

        public override void WorkDo()
        {
            Console.WriteLine("doing work at"+base.Address);
        }
    }
}