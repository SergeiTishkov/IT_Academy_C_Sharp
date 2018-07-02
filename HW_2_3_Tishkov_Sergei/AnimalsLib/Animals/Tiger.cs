using AnimalsLib.Enums;

namespace AnimalsLib.Animals
{
    class Tiger : Animal
    {
        private static int _idCounter = 1;
        private readonly int _id;
        public Tiger() : base(TypeOfFood.BigCat, TypeOfFood.MediumRodent, TypeOfConsumption.Carnivore)
        {
            _id = _idCounter++;
        }

        public override string ToString() => $"Tiger {_id}, {Sex}, is {(IsHungry ? "starving" : "full")}\n";
    }
}
