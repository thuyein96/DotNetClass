namespace BindingPractice.Models
{
    public class Employee
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Email { get; set;}
        //Has-A Relationship
        public Address HomeAddress { get; set; }
    }
}