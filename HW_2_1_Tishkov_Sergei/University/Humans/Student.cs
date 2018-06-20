using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO Моя вижла ругается что вы переименовали проект но не поменяли RootNamespace =)
// https://i.imgur.com/JcaoAuy.png

namespace Education.Humans
{
    public abstract class Student : Human
    {
        // TODO Не используется в наследниках. Можно смело делать Private
        protected LectionType _specialization;

        // TODO Ребята из SonarQube считают что конструктор должен быть protected
        // https://rules.sonarsource.com/csharp/RSPEC-3442
        public Student(string fullName, LectionType specialization) : base(fullName) => _specialization = specialization;

        public abstract void Learn(Lection lection);

        protected bool IsMySpecialization(Lection lection) => _specialization.HasFlag(lection.TypeOfLection);
    }
}
