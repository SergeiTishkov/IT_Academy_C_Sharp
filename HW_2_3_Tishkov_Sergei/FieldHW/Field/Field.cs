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
        private Random random = new Random((int)DateTime.Now.Ticks);
        private int _numberOfSeason = 1;
        private List<Rabbit> _rabbits;
        private int _rabbitsFertility;
        private List<Tiger> _tigers;
        private int _grass;
        private readonly int _grassMaxCount;
        private readonly int _fieldGrassProductivity;

        public static Field GetNewField(int randomLowLimit = 10, int randomHighLimit = 50, int rabbitsFertility = 4, int rabbitsToTigersRatio = 5, int grass = 3000, int fieldGrassProductivity = 100, int grassMaxCount = 10000)
            =>
            (randomLowLimit < 0 || randomHighLimit < 0 || rabbitsToTigersRatio < 0 || grass < 0 || fieldGrassProductivity < 0 || grassMaxCount < 0) ?
            null : new Field(randomLowLimit, randomHighLimit, rabbitsFertility, rabbitsToTigersRatio, grass, fieldGrassProductivity, grassMaxCount);


        private Field(int randomLowLimit, int randomHighLimit, int rabbitsFertility, int rabbitsToTigersRatio, int grass, int fieldGrassProductivity, int grassMaxCount)
        {
            _rabbitsFertility = rabbitsFertility;
            _grassMaxCount = grassMaxCount;
            _fieldGrassProductivity = fieldGrassProductivity;
            _grass = grass > _grassMaxCount ? _grassMaxCount : grass;

            int _qOfAnimals = random.Next(randomLowLimit, randomHighLimit),
                _qOfTigers = _qOfAnimals / (1 + rabbitsToTigersRatio),
                _qOfRabbits = _qOfAnimals - _qOfTigers;

            _rabbits = new List<Rabbit>(_qOfRabbits);
            _tigers = new List<Tiger>(_qOfTigers);

            addNewRabbits(_qOfRabbits);
            addNewTigers(_qOfTigers);
        }

        private int Grass
        {
            get => _grass > _grassMaxCount ? _grassMaxCount : _grass;
            set => _grass = (value + _grass) > _grassMaxCount ? _grassMaxCount : value;
        }

        public string LiveAnotherSeason()
        {
            StringBuilder result = new StringBuilder($"*****************************************\n\n\tSTART OF {_numberOfSeason} SEASON\n\n\n");

            foreach (var rabbit in _rabbits)
            {
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
                        rabbit.IsStarved = true;
                        result.Append("Rabbit " + (rabbit.IsMale ? "male" : "female") +
                        $" {rabbit.Id} was starving this season, but still looking for couple for reprodiction.\nHope next season will be more grassful or the rabbit will die.\n\n");
                    }
                }
            }
            _rabbits = _rabbits.Where((r) => !r.IsDead).ToList();

            foreach (var tiger in _tigers)
            {
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
                        tiger.IsStarved = true;
                        result.Append("Tiger " + (tiger.IsMale ? "male" : "female") +
                        $" {tiger.Id} was starving this season, but still looking for couple for reprodiction.\nHope next season will be more rabbitful or the tiger will die.\n\n");

                    }
                }
            }
            _tigers = _tigers.Where((t) => !t.IsDead).ToList();

            _rabbits = _rabbits.Where((r) => !r.IsDead).ToList();
            _tigers = _tigers.Where((t) => !t.IsDead).ToList();

            if (_rabbits.Count == 0)
                result.Append($"All rabbits was eaten or starved, so this season rabbits won't be reproducing.\n\n");
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
                        addNewRabbits(fullMaleRabbits.Length * _rabbitsFertility);
                    }
                    else if (fullMaleRabbits.Length > fullFemaleRabbits.Length)
                    {
                        result.Append($"Each rabbit female found himself male and they made new {fullFemaleRabbits.Length * _rabbitsFertility} rabbits!\n{fullFemaleRabbits.Length - fullMaleRabbits.Length} males aren't satisfied.\n\n");
                        addNewRabbits(fullFemaleRabbits.Length * _rabbitsFertility);
                    }
                    else
                    {
                        result.Append($"Each rabbit found himself couple and they made new {fullFemaleRabbits.Length * _rabbitsFertility} rabbits!.\n\n");
                        addNewRabbits(fullFemaleRabbits.Length * _rabbitsFertility);
                    }
                }
            }

            if (_tigers.Count == 0)
                result.Append($"All tigers was starved, so this season tigers won't be reproducing.\n\n");
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
                        addNewTigers(fullMaleTigers.Length);
                    }
                    else if (fullMaleTigers.Length > fullFemaleTigers.Length)
                    {
                        result.Append($"Each tiger female found himself male and they made new {fullFemaleTigers.Length} rabbits!\n{fullFemaleTigers.Length - fullMaleTigers.Length} males aren't satisfied.\n\n");
                        addNewTigers(fullFemaleTigers.Length);
                    }
                    else
                    {
                        result.Append($"Each tiger found himself couple and they made new {fullFemaleTigers.Length} tigers!.\n\n");
                        addNewTigers(fullFemaleTigers.Length);
                    }
                }
            }

            if (_rabbits.Count < 10 && Grass > _fieldGrassProductivity * _rabbitsFertility)
            {
                int newRabbits = random.Next(2, 50);
                result.Append($"The field looks quite lovely for rabbits from other fields due to small rabbits population.\n{newRabbits} rabbits migrate to the field.\n\n");
                addNewRabbits(newRabbits);
            }

            if (_tigers.Count < 2 && _rabbits.Count > 50)
            {
                int newTigers = random.Next(2, 6);
                result.Append($"The field looks quite lovely for tigers from other fields due to small tigers population.\n{newTigers} tigers migrate to the field.\n\n");
                addNewTigers(newTigers);
            }
            Grass += _fieldGrassProductivity;
            result.Append($"End of {_numberOfSeason} season: {Grass} grass, {_rabbits.Count} rabbits, {_tigers.Count} tigers.\n\n\n\n\n");

            return result.ToString();
        }

        private void addNewRabbits(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                _rabbits.Add(new Rabbit());
                Thread.Sleep(new TimeSpan(1));
            }
        }
        private void addNewTigers(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                _tigers.Add(new Tiger());
                Thread.Sleep(new TimeSpan(1));
            }
        }
    }
}
