using System;
using System.Collections.Generic;

public abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public abstract void SayHello();
}

public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void SayHello()
    {
        Console.WriteLine($"гав меня зовут {Name}");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void SayHello()
    {
        Console.WriteLine($"мяу меня зовут {Name}");
    }
}
public class Program
{
    public static void GreetAnimals(List<Animal> animals, Action<Animal> greetAction)
    {
        foreach (var animal in animals)
        {
            greetAction(animal);
        }
    }

    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog("бобик"),
            new Cat("мурка")
        };

        GreetAnimals(animals, animal => animal.SayHello());

        Action<Dog> dogGreetAction = dog => dog.SayHello();
        GreetAnimals(animals, animal => {
            if (animal is Dog dog) dogGreetAction(dog);
        });
    }
}
