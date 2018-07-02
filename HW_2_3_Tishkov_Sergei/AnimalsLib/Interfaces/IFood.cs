using AnimalsLib.Enums;

namespace AnimalsLib.Interfaces
{
    interface IFood
    {
        TypeOfFood CanBeEatenAs { get; }
        bool IsDead { get; }
        void Die();
    }
}
