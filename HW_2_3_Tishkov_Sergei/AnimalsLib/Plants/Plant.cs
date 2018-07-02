using AnimalsLib.Enums;
using AnimalsLib.Interfaces;

namespace AnimalsLib.Plants
{
    abstract class Plant : IPlant
    {
        public bool IsDead { get; internal set; }

        public TypeOfFood CanBeEatenAs { get; }

        public void Die() => IsDead = true;

        protected Plant(TypeOfFood canBeEatenAs)
        {
            CanBeEatenAs = canBeEatenAs;
        }
    }
}
