using System;
namespace Animals;
public abstract class Animal
{
    private string _name;
    private int _age;
    private string _gender;
    public string Name
    {
        get => _name;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            _name = value;
        }
    }
    public int Age
    {
        get => _age;
        private set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            _age = value;
        }
    }
    public string Gender
    {
        get => _gender;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            _gender = value;
        }
    }
    public Animal(string name,int age,string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }
    public abstract string ProduceSound();
    public override string ToString() => $"{GetType().Name}{Environment.NewLine}" +
        $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
}