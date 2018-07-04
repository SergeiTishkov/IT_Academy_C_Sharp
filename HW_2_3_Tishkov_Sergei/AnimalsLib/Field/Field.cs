using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AnimalsLib.Animals;
using AnimalsLib.Interfaces;
using AnimalsLib.Enums;
using AnimalsLib.Plants;

namespace AnimalsLib.Field
{
    public class Field
    {
        private readonly Random _random = new Random((int)DateTime.Now.Ticks);
        
        private List<IAnimal> _animals = new List<IAnimal>();
        private List<IPlant> _plants = new List<IPlant>();

        private readonly int _grassGrowthSpeed;

        private Field(int lowerBoundRabbits, int higherBoundRabbits, int lowerBoundTigers, int higherBoundTigers, int startGrassQuantity, int grassGrowthSpeed)
        {
            AddAnimals<Rabbit>(_random.Next(lowerBoundRabbits, higherBoundRabbits));
            AddAnimals<Tiger>(_random.Next(lowerBoundTigers, higherBoundTigers));
            AddPlants<Grass>(startGrassQuantity);

            _grassGrowthSpeed = grassGrowthSpeed;
        }

        public static Field NewField(int lowerBoundRabbits, int higherBoundRabbits, int lowerBoundTigers, int higherBoundTigers, int startGrassQuantity, int grassGrowthSpeed)
        {
            if (lowerBoundRabbits < 0 || higherBoundRabbits < 0 ||
                lowerBoundTigers < 0 || higherBoundTigers < 0 ||
                startGrassQuantity < 0 || grassGrowthSpeed < 0 ||
                lowerBoundRabbits > higherBoundRabbits ||
                lowerBoundTigers > higherBoundTigers)
                return null;
            return new Field(lowerBoundRabbits, higherBoundRabbits, lowerBoundTigers, higherBoundTigers, startGrassQuantity, grassGrowthSpeed);
        }

        public string AnimalsStatus()
        {
            StringBuilder result = new StringBuilder("Список животных на поле:\n\n");
            foreach (IAnimal animal in _animals)
            {
                result.Append(animal.ToString());
            }

            IEnumerable<IAnimal> rabbits = _animals.Where(a => a is Rabbit);
            IEnumerable<IAnimal> tigers = _animals.Where(a => a is Tiger);

            // задел на будущее, в будущем будут добавлены разные виды растений в _plants
            result.Append($"\nВсего на поле {_plants.Count(p => p is Grass)} травы,");
            result.Append($"\n{rabbits.Count()} кроликов ({rabbits.Count(r => r.Sex == Sex.Male)} самцов, {rabbits.Count(r => r.Sex == Sex.Female)} самок),");
            result.Append($"\n{tigers.Count()} тигров ({tigers.Count(t => t.Sex == Sex.Male)} самцов и {tigers.Count(t => t.Sex == Sex.Female)} самок).");

            return result.ToString();
        }

        public void LiveOneDay()
        {
            AnimalsEat();
            CreaturesBreed();
            MixAnimals();
        }

        private void AnimalsEat()
        {
            foreach (IAnimal animal in _animals)
            {
                switch (animal.TypeOfConsumption)
                {
                    case TypeOfConsumption.Herbivore:
                        AnimalEat(animal, _plants);
                        break;
                    case TypeOfConsumption.Carnivore:
                        AnimalEat(animal, _animals);
                        break;
                    // я планирую расширить программу до настоящей песочницы, этот кейс - задел на будущее
                    // он пока плохо настроен, получается, что медведь шел по полю, полному ягод, не нашел 
                    // зайца, и помер от расстройства
                    // но т.к. все равно пока всеядных животных не добавлено, я не исправлял эту проблему
                    case TypeOfConsumption.Omnivore: 
                        if (_random.NextDouble() < 0.5)
                        {
                            goto case TypeOfConsumption.Herbivore;
                        }
                        else
                        {
                            goto case TypeOfConsumption.Carnivore;
                        }
                }
            }
            RemoveDeadCreatures();

            void AnimalEat<T>(IAnimal animal, List<T> food)
                where T : IFood
            {
                int index = food.FindIndex(f => !f.IsDead && animal.CanEat.HasFlag(f.CanBeEatenAs));
                if (index > -1)
                {
                    food[index].Die();
                    animal.Eat();
                }
                else
                {
                    animal.Starve();
                }
            }
        }

        private void CreaturesBreed()
        {
            AddAnimals<Rabbit>(CountOfFullPairs<Rabbit>());
            AddAnimals<Tiger>(CountOfFullPairs<Tiger>());
            AddPlants<Grass>(_grassGrowthSpeed);

            int CountOfFullPairs<T>()
                where T : IAnimal
            {
                IEnumerable<IAnimal> fullAnimals = _animals.Where(a => a is T && !a.IsHungry);
                int males = fullAnimals.Count(a => a.Sex == Sex.Male);
                int females = fullAnimals.Count(a => a.Sex == Sex.Female);

                if (males > females)
                {
                    return females;
                }
                else
                {
                    return males;
                }
            }
        }

        private void AddAnimals<T>(int quantity)
            where T : IAnimal, new()
        {
            for (; quantity > 0; quantity--)
            {
                _animals.Add(new T());
            }
        }

        private void AddPlants<T>(int quantity)
            where T : IPlant, new()
        {
            for (; quantity > 0; quantity--)
            {
                _plants.Add(new T());
            }
        }

        private void MixAnimals()
            =>
            _animals = _animals.OrderBy(a => _random.Next()).ToList();

        private void RemoveDeadCreatures()
        {
            _animals = _animals.Where(a => !a.IsDead).ToList();
            _plants = _plants.Where(g => !g.IsDead).ToList();
        }
    }
}
