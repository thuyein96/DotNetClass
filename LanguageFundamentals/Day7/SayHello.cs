namespace Day7
{
    public abstract class SayHello
    {
        public string Name { get; set; }
        public string Address { get; set; }
        
        //abstraction process here bacause say what
        public  abstract void SayGreetingMessage();
        public abstract void AboutMe();
        public abstract void WorkDo();

        public void DisplayInfo()
        {
            Console.WriteLine($"{Name} live in at {Address}");
        }
    }
}