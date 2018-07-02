using AnimalsLib.Enums;

namespace AnimalsLib.Interfaces
{
    interface IAnimal : IFood
    {
        Sex Sex { get; }
        TypeOfConsumption TypeOfConsumption { get; }
        TypeOfFood CanEat { get; }
        void Eat();
        void Starve();
        bool IsHungry { get; }
    }
}
