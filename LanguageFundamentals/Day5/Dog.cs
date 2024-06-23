namespace Day5
{
    public class Dog:Animal
    {
        public Dog(string a):base(a)
        {

        }
        public override void Sound()
        {
            Console.WriteLine($"{base.Name} Woak..Woak.Woak.");
        }
    }
}