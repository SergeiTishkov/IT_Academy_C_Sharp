using AnimalsLib.Enums;

namespace AnimalsLib.Animals
{
    class Rabbit : Animal
    {
        private static int _idCounter = 1;
        private readonly int _id;
        public Rabbit() : base(TypeOfFood.MediumRodent, TypeOfFood.Grass, TypeOfConsumption.Herbivore)
        {
            _id = _idCounter++;
        }

        public override string ToString() => $"Rabbit {_id}, {Sex}, is {(IsHungry ? "starving" : "full")}\n";
    }
}
