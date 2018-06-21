﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using FieldHW.Animals;

namespace FieldHW.Field
{
    public class Field
    {
        private readonly Random random = new Random((int)DateTime.Now.Ticks);
        private int _numberOfSeason = 1;
        private List<IAnimal> _rabbits;
        private readonly int _rabbitsFertility;
        private List<IAnimal> _tigers;
        private int _grass;
        private readonly int _grassMaxCount;
        private readonly int _fieldGrassProductivity;

        public static Field GetNewField(int randomLowLimit = 10, int randomHighLimit = 50, int rabbitsFertility = 4,
            int rabbitsToTigersRatio = 5, int grass = 3000, int fieldGrassProductivity = 100, int grassMaxCount = 10000)
            =>
            (randomLowLimit < 0 || randomHighLimit < 0 || rabbitsToTigersRatio < 0 || grass < 0 || fieldGrassProductivity < 0 || grassMaxCount < 0) ?
            null : new Field(randomLowLimit, randomHighLimit, rabbitsFertility, rabbitsToTigersRatio, grass, fieldGrassProductivity, grassMaxCount);


        private Field(int randomLowLimit, int randomHighLimit, int rabbitsFertility, int rabbitsToTigersRatio, int grass, int fieldGrassProductivity, int grassMaxCount)
        {
            _rabbitsFertility = rabbitsFertility;
            _grassMaxCount = grassMaxCount;
            _fieldGrassProductivity = fieldGrassProductivity;
            _grass = grass > _grassMaxCount ? _grassMaxCount : grass;

            int _qOfAnimals = random.Next(randomLowLimit, randomHighLimit);
            int _qOfTigers = _qOfAnimals / (1 + rabbitsToTigersRatio);
            int _qOfRabbits = _qOfAnimals - _qOfTigers;

            _rabbits = new List<IAnimal>(_qOfRabbits);
            _tigers = new List<IAnimal>(_qOfTigers);

            AddNewRabbits(_qOfRabbits);
            AddNewTigers(_qOfTigers);
        }

        private int Grass
        {
            get => _grass;
            set => _grass = (value + _grass) > _grassMaxCount ? _grassMaxCount : value;
        }

        public string LiveAnotherSeason()
        {
            StringBuilder result = new StringBuilder($"*****************************************\n\n\tSTART OF {_numberOfSeason} SEASON\n\n\n");

            foreach (var _rabbit in _rabbits)
            {
                var rabbit = _rabbit as Rabbit;
                if (Grass > 0)
                {
                    rabbit.Eat();
                    Grass--;
                    result.Append("Rabbit " + (rabbit.IsMale ? "male" : "female") +
                        $" {rabbit.Id} is full and looking for couple for reprodiction.\nHope the tigers won't eat it before it succeed.\n\n");
                }
                else
                {
                    if (rabbit.IsStarved)
                    {
                        rabbit.IsDead = true;
                        result.Append("Rabbit " + (rabbit.IsMale ? "male" : "female") +
                        $" {rabbit.Id} is dead due to starvation for more than one season.\n\n");
                    }
                    else
                    {
                        rabbit.Starve();
                        result.Append("Rabbit " + (rabbit.IsMale ? "male" : "female") +
                        $" {rabbit.Id} was starving this season, but still looking for couple for reprodiction.\nHope next season will be more grassful or the rabbit will die.\n\n");
                    }
                }
            }
            RemoveDeadAnimals(ref _rabbits);

            foreach (var _tiger in _tigers)
            {
                var tiger = _tiger as Tiger;
                if (_rabbits.Count > 0)
                {
                    tiger.Eat();
                    _rabbits.Remove(_rabbits[random.Next(0, _rabbits.Count)]);
                    result.Append("Tiger " + (tiger.IsMale ? "male" : "female") +
                        $" {tiger.Id} is full and looking for couple for reprodiction.\n\n");
                }
                else
                {
                    if (tiger.IsStarved)
                    {
                        tiger.IsDead = true;
                        result.Append("Tiger " + (tiger.IsMale ? "male" : "female") +
                        $" {tiger.Id} is dead due to starvation for more than one season.\n\n");
                    }
                    else
                    {
                        tiger.Starve();
                        result.Append("Tiger " + (tiger.IsMale ? "male" : "female") +
                        $" {tiger.Id} was starving this season, but still looking for couple for reprodiction.\nHope next season will be more rabbitful or the tiger will die.\n\n");

                    }
                }
            }
            RemoveDeadAnimals(ref _rabbits);
            RemoveDeadAnimals(ref _tigers);

            // TODO Копирование кода, и слабая читабельность.
            // Идея в том, что при правильном разделении на классы,
            // и создания "пищевых пристрастий" ENUM Flags можно в сделать
            // общий вариант обработки как для кроликов так и для тигров.
            // Ну и с точки зрения тестирование, проверить что тут происходить
            // просто не возможно. Если усложнить логику и ввести поле то всё
            // станет ещё хуже. Первый принцип SOLID - Single Responsibility.
            // Пока вы работаете над чем-то один. И вы никогда не будете к этому
            // возвращаться чтобы посмотреть или переписать один огромный метод будет работать
            // TODO Вот вам полная версия упрощённой песочницы. https://1drv.ms/f/s!Av6RHCnJE8oAgZJbLN1UsegiEk-BCw
            // Можете по ковыряться, и с задачей и с тестами. Сразу говорю что смотреть даже не просите,
            // песочниц со стандартными ошибками я уже слишком много видел. Это скорее вам как разминка 
            // для мозга если захотите

            if (_rabbits.Count == 0)
                result.Append($"All rabbits are dead, so this season rabbits won't be reproducing.\n\n");
            else
            {
                var fullMaleRabbits = _rabbits.Where((r) => r.IsMale && r.IsFull).ToArray();
                var fullFemaleRabbits = _rabbits.Where((r) => !r.IsMale && r.IsFull).ToArray();

                if (fullMaleRabbits.Length == 0)
                    result.Append($"There isn't any male rabbit on the field, so this season rabbits won't be reproducing\n\n");
                else if (fullFemaleRabbits.Length == 0)
                    result.Append($"There isn't any female rabbit on the field, so this season rabbits won't be reproducing\n\n");
                else
                {
                    result.Append($"There is {fullMaleRabbits.Length} full rabbits males and {fullFemaleRabbits.Length} full rabbits females, and they are making couples!\n");

                    if (fullMaleRabbits.Length < fullFemaleRabbits.Length)
                    {
                        result.Append($"Each rabbit male found himself female and they made new {fullMaleRabbits.Length * _rabbitsFertility} rabbits!\n{fullMaleRabbits.Length - fullFemaleRabbits.Length} females aren't satisfied.\n\n");
                        AddNewRabbits(fullMaleRabbits.Length * _rabbitsFertility);
                    }
                    else if (fullMaleRabbits.Length > fullFemaleRabbits.Length)
                    {
                        result.Append($"Each rabbit female found himself male and they made new {fullFemaleRabbits.Length * _rabbitsFertility} rabbits!\n{fullFemaleRabbits.Length - fullMaleRabbits.Length} males aren't satisfied.\n\n");
                        AddNewRabbits(fullFemaleRabbits.Length * _rabbitsFertility);
                    }
                    else
                    {
                        result.Append($"Each rabbit found himself couple and they made new {fullFemaleRabbits.Length * _rabbitsFertility} rabbits!.\n\n");
                        AddNewRabbits(fullFemaleRabbits.Length * _rabbitsFertility);
                    }
                }
            }

            if (_tigers.Count == 0)
                result.Append($"All tigers are dead, so this season tigers won't be reproducing.\n\n");
            else
            {
                var fullMaleTigers = _tigers.Where((t) => t.IsMale && t.IsFull).ToArray();
                var fullFemaleTigers = _tigers.Where((t) => !t.IsMale && t.IsFull).ToArray();

                if (fullMaleTigers.Length == 0)
                    result.Append($"There isn't any male tiger on the field, so this season tigers won't be reproducing\n\n");
                else if (fullFemaleTigers.Length == 0)
                    result.Append($"There isn't any female tiger on the field, so this season tigers won't be reproducing\n\n");
                else
                {
                    result.Append($"There is {fullMaleTigers.Length} full tigers males and {fullFemaleTigers.Length} full tigers females, and they are making couples!\n");

                    if (fullMaleTigers.Length < fullFemaleTigers.Length)
                    {
                        result.Append($"Each tiger male found himself female and they made new {fullMaleTigers.Length} tigers!\n{fullMaleTigers.Length - fullFemaleTigers.Length} females aren't satisfied.\n\n");
                        AddNewTigers(fullMaleTigers.Length);
                    }
                    else if (fullMaleTigers.Length > fullFemaleTigers.Length)
                    {
                        result.Append($"Each tiger female found himself male and they made new {fullFemaleTigers.Length} rabbits!\n{fullFemaleTigers.Length - fullMaleTigers.Length} males aren't satisfied.\n\n");
                        AddNewTigers(fullFemaleTigers.Length);
                    }
                    else
                    {
                        result.Append($"Each tiger found himself couple and they made new {fullFemaleTigers.Length} tigers!.\n\n");
                        AddNewTigers(fullFemaleTigers.Length);
                    }
                }
            }

            AnimalsMigration(result, _rabbits, AnimalTypePlural.rabbits, 10, Grass > _fieldGrassProductivity * _rabbitsFertility, 50);
            AnimalsMigration(result, _tigers, AnimalTypePlural.tigers, 2, _rabbits.Count > 50, 6);


            Grass += _fieldGrassProductivity;
            result.Append($"End of {_numberOfSeason++} season: {Grass} grass, {_rabbits.Count} rabbits, {_tigers.Count} tigers.\n\n\n\n\n");

            return result.ToString();
        }

        private void AddNewRabbits(int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _rabbits.Add(new Rabbit());
        }
        private void AddNewTigers(int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _tigers.Add(new Tiger());
        }

        private void RemoveDeadAnimals(ref List<IAnimal> animals) => animals = animals.Where(a => !a.IsDead).ToList();
        
        private void AnimalsMigration(StringBuilder result, List<IAnimal> animals, AnimalTypePlural type, int minCountOfAnimals, bool isFoodEnough, int maxRandomBound)
        {
            if(animals.Count < minCountOfAnimals && isFoodEnough)
            {
                int newAnimals = random.Next(2, maxRandomBound);
                result.Append($"The field looks quite lovely for {type} from other fields due to small {type} population.\n{newAnimals} {type} migrate to the field.\n\n");

                if(type == AnimalTypePlural.rabbits)
                    AddNewRabbits(newAnimals);
                else
                    AddNewTigers(newAnimals);
            }
        }
    }
}