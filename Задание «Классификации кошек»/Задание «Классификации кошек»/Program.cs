using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание__Классификации_кошек_
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Введите количество кошек: ");

            int catCount;
            while (!int.TryParse(Console.ReadLine(), out catCount) || catCount <= 0)
            {
                Console.Write("Пожалуйста, введите корректное число: ");
            }

            Cat[] cats = GenerateRandomCats(catCount);

            Console.Write("Введите путь к файлу для сохранения информации: ");
            string filePath = Console.ReadLine();

            DisplayCatInfo(cats, filePath);
        }

        public static Cat[] GenerateRandomCats(int count)
        {
            Random random = new Random();
            Cat[] cats = new Cat[count];

            for (int i = 0; i < count; i++)
            {
                bool validCat = false;
                while (!validCat)
                {
                    try
                    {
                        int fluffiness = random.Next(-20, 121);
                        if (random.Next(2) == 0)
                        {
                            double weight = random.Next(50, 161);
                            cats[i] = new Tiger(weight, fluffiness);
                        }
                        else
                        {
                            cats[i] = new CuteCat(fluffiness);
                        }

                        validCat = true;
                    }
                    catch (CatException e)
                    {
                        Console.WriteLine($"Exception occurred: {e.Message}");
                    }
                }
            }
            return cats;
        }

        public static void DisplayCatInfo(Cat[] catsArr, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var cat in catsArr)
                {
                    string catInfo = cat.ToString();
                    string fluffinessCheck = cat.FluffinessCheck();

                    Console.WriteLine(catInfo);
                    Console.WriteLine(fluffinessCheck);

                    writer.WriteLine(catInfo);
                    writer.WriteLine(fluffinessCheck);
                }
            }
        }
    }

    public abstract class Cat
    {
        public abstract int Fluffiness { get; }
        public abstract string FluffinessCheck();
        public override string ToString()
        {
            return $"A cat with fluffiness: {Fluffiness}";
        }
    }

    public class CatException : ArgumentException
    {
        public CatException(string message) : base(message)
        {

        }
    }

    public class CuteCat : Cat
    {
        private int fluffiness;
        public override int Fluffiness => fluffiness;
        public override string FluffinessCheck()
        {
            if (fluffiness == 0)
            {
                return "Sphynx";
            }
            if (fluffiness >= 1 && fluffiness <= 20)
            {
                return "Slightly";
            }
            if (fluffiness >= 21 && fluffiness <= 50)
            {
                return "Medium";
            }
            if (fluffiness >= 51 && fluffiness <= 75)
            {
                return "Heavy";
            }

            return "OwO";
        }

        public CuteCat(int fluffiness = 50)
        {
            if (fluffiness <= 0 || fluffiness >= 140)
            {
                throw new CatException($"Unable to create a cute cat with fluffiness: {fluffiness}");
            }
            this.fluffiness = fluffiness;
        }

        public override string ToString()
        {
            return $"A cute cat with fluffiness: {fluffiness}";
        }
    }

    public class Tiger : Cat
    {
        private double weight { get; }
        private int fluffiness;

        public double Weight => weight;
        public override int Fluffiness => fluffiness;
        public override string FluffinessCheck()
        {
            return "Kycb!";
        }

        public override string ToString()
        {
            return $"A tiger with weight: {weight} fluffiness: {fluffiness}";
        }

        public Tiger(double weight, int fluffiness = 50)
        {
            if (weight < 75.0 || weight > 140.0)
            {
                throw new CatException($"Unable to create a tiger with weight:{weight}");
            }

            if (fluffiness < 0 || fluffiness > 100)
            {
                throw new CatException($"Unable to create a tiger with fluffiness {fluffiness}");
            }

            this.weight = weight;
            this.fluffiness = fluffiness;
        }
    }
}

