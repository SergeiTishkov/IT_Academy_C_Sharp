using System;

using AnimalsLib.Enums;
using AnimalsLib.Interfaces;

namespace AnimalsLib.Animals
{
    abstract class Animal : IAnimal
    {
        private static Random _random = new Random((int)DateTime.Now.Ticks);

        public bool IsHungry { get; private set; }

        public bool IsDead { get; private set; }

        public TypeOfFood CanBeEatenAs { get; }

        public TypeOfFood CanEat { get; }

        public TypeOfConsumption TypeOfConsumption { get; }

        public Sex Sex { get; }

        protected Animal(TypeOfFood canBeEatenAs, TypeOfFood canEat, TypeOfConsumption typeOfConsumption)
        {
            CanBeEatenAs = canBeEatenAs;
            CanEat = canEat;
            TypeOfConsumption = typeOfConsumption;
            
            if(_random.NextDouble() > 0.5)
            {
                Sex = Sex.Female;
            }
            else
            {
                Sex = Sex.Male;
            }
        }

        public void Eat() => IsHungry = false;

        public void Die() => IsDead = true;

        public void Starve()
        {
            if (IsHungry)
            {
                Die();
            }
            else
            {
                IsHungry = true;
            }
        }
    }
}
