namespace Day6
{
    public class Human:Mammal
    {
        public string BloodType { get; set; }
        public string IdCard { get; set; }
        public string Occupation { get; set; }
        public override void Sound()
        {
            Console.WriteLine($"Hello, Nice to see you, I am {base.Name}");
        }

        public void DoWork()
        {
            Console.WriteLine($"I am {base.Name} {Occupation}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {BloodType}, {IdCard}, {Occupation}";
        }
    }
}