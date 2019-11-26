using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;
using WildFarm.Foods;
using System.Linq;

namespace WildFarm
{
    public class Engine
    {
        public void Run()
        {
            var animals = new List<Animal>();
            var counter = 0;

            while (true)
            {
                var command = Console.ReadLine().Split();
                
                if (command[0] == "End")
                {
                    break;
                }
                if (counter % 2 == 0)
                {
                    if (command[0] == "Hen")
                    {
                        var name = command[1];
                        var weight = double.Parse(command[2]);
                        var wingSize = double.Parse(command[3]);

                        var currHen = new Hen(name, weight, wingSize);
                        animals.Add(currHen);
                    }
                    else if (command[0] == "Owl")
                    {
                        var name = command[1];
                        var weight = double.Parse(command[2]);
                        var wingSize = double.Parse(command[3]);

                        var currOwl = new Owl(name, weight, wingSize);
                        animals.Add(currOwl);
                    }
                    else if (command[0] == "Mouse")
                    {
                        var name = command[1];
                        var weight = double.Parse(command[2]);
                        var livingRegion = command[3];

                        var currMouse = new Mouse(name, weight, livingRegion);
                        animals.Add(currMouse);
                    }
                    else if (command[0] == "Cat")
                    {
                        var name = command[1];
                        var weight = double.Parse(command[2]);
                        var livingRegion = command[3];
                        var breed = command[4];

                        var currCat = new Cat(name, weight, livingRegion, breed);
                        animals.Add(currCat);
                    }
                    else if (command[0] == "Dog")
                    {
                        var name = command[1];
                        var weight = double.Parse(command[2]);
                        var livingRegion = command[3];

                        var currDog = new Dog(name, weight, livingRegion);
                        animals.Add(currDog);
                    }
                    else if (command[0] == "Tiger")
                    {
                        var name = command[1];
                        var weight = double.Parse(command[2]);
                        var livingRegion = command[3];
                        var breed = command[4];

                        var currTiger = new Tiger(name, weight, livingRegion, breed);
                        animals.Add(currTiger);
                    }
                    Console.WriteLine(animals.Last().ProduceSound());
                }
                else
                {
                    if (command[0] == "Fruit")
                    {
                        var quantity = int.Parse(command[1]);
                        var currFruit = new Fruit(quantity);

                        if (animals.Last().GetType().Name == "Hen" || animals.Last().GetType().Name == "Mouse")
                        {
                            HenEating(animals, quantity);
                            MouseEating(animals, quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat Fruit!");
                        }
                    }
                    else if (command[0] == "Meat")
                    {
                        var quantity = int.Parse(command[1]);
                        var currMeat = new Meat(quantity);
                        
                        if(animals.Last().GetType().Name == "Hen" || animals.Last().GetType().Name == "Cat" ||
                            animals.Last().GetType().Name == "Tiger" || animals.Last().GetType().Name == "Dog" || animals.Last().GetType().Name == "Owl")
                        {
                            HenEating(animals, quantity);
                            CatEating(animals, quantity);
                            TigerEating(animals, quantity);
                            DogEating(animals, quantity);
                            OwlEating(animals, quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat Meat!");
                        }
                    }
                    else if (command[0] == "Seeds")
                    {
                        var quantity = int.Parse(command[1]);
                        var currSeeds = new Seeds(quantity);

                        if(animals.Last().GetType().Name == "Hen")
                        {
                            HenEating(animals, quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat Seeds!");
                        }
                    }
                    else if (command[0] == "Vegetable")
                    {
                        var quantity = int.Parse(command[1]);
                        var currVegetable = new Vegetable(quantity);
                        
                        if(animals.Last().GetType().Name == "Mouse" || animals.Last().GetType().Name == "Hen" || animals.Last().GetType().Name == "Cat")
                        {
                            HenEating(animals, quantity);
                            MouseEating(animals, quantity);
                            CatEating(animals, quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat Vegetable!");
                        }
                    }
                }
                counter++;
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
        public void HenEating(List<Animal>animals,int quantity)
        {
            if (animals.Last().GetType().Name == "Hen")
            {
                animals.Last().Weight += 0.35 * quantity;
                animals.Last().FoodEaten += quantity;
            }
        }
        public void MouseEating(List<Animal> animals, int quantity)
        {
            if (animals.Last().GetType().Name == "Mouse")
            {
                animals.Last().Weight += 0.10 * quantity;
                animals.Last().FoodEaten += quantity;
            }
        }
        public void CatEating(List<Animal> animals, int quantity)
        {
            if (animals.Last().GetType().Name == "Cat")
            {
                animals.Last().Weight += 0.30 * quantity;
                animals.Last().FoodEaten += quantity;
            }
        }
        public void TigerEating(List<Animal> animals, int quantity)
        {
            if (animals.Last().GetType().Name == "Tiger")
            {
                animals.Last().Weight += 1.00 * quantity;
                animals.Last().FoodEaten += quantity;
            }
        }
        public void DogEating(List<Animal> animals, int quantity)
        {
            if (animals.Last().GetType().Name == "Dog")
            {
                animals.Last().Weight += 0.40 * quantity;
                animals.Last().FoodEaten += quantity;
            }
        }
        public void OwlEating(List<Animal> animals, int quantity)
        {
            if (animals.Last().GetType().Name == "Owl")
            {
                animals.Last().Weight += 0.25 * quantity;
                animals.Last().FoodEaten += quantity;
            }
        }
    }
}
