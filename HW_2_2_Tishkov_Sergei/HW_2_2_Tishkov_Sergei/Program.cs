using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BankHW;
using BankHW.Accounts;

using UniverHW;
using UniverHW.Humans;

namespace HW_2_2_Tishkov_Sergei
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankomatPrior = new BankomatPrior("Minsk_Luchini_46");
            var priorAccount = new PriorAccount(3000);
            var account = new Account(2500);

            Console.WriteLine("Попытка получить бонус с новой карточки Приора:");
            bankomatPrior.TakeBonus(priorAccount);
            Console.WriteLine();

            Console.WriteLine("Попытка получить бонус второй раз:");
            bankomatPrior.TakeBonus(priorAccount);
            Console.WriteLine();

            Console.WriteLine("Попытка получить карточкой другого банка:");
            bankomatPrior.TakeBonus(account);
            Console.WriteLine();

            Console.WriteLine("Попытка снять деньги с карточки приора:");
            double cash = bankomatPrior.GetMoney(priorAccount, 2000);
            Console.WriteLine();

            Console.WriteLine("Попытка снять деньги с карточки другого банка(больше, чем есть на счету):");
            bankomatPrior.GetMoney(account, 3000);
            Console.WriteLine();

            Console.WriteLine("Попытка снять деньги с карточки другого банка(нормальное количество):");
            cash += bankomatPrior.GetMoney(account, 2000);
            Console.WriteLine();

            Console.WriteLine($"Ой вэй, таки у меня на руках {cash} неназванных денежных знаков!");
            Console.WriteLine("Или таки так: {0:C}", cash); // кстати, у меня значок вопроса показало, почему?

            Console.WriteLine("Проверка задачи с банкоматами закончена, нажмите любую кнопку для продолжения:");
            Console.ReadKey(true);
            Console.Clear();

            //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
            //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
            //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  

            University univer = new University();

            var techHeadmaster = new HeadOfDepartment("Albus", "Dumbledore", UniversityDepartment.Tech, AllExistingGenders.Male);
            var mathHeadmaster = new HeadOfDepartment("Victoria", "Vector", UniversityDepartment.Math, AllExistingGenders.Female);
            var histHeadmaster = new HeadOfDepartment("Bobby", "Pins", UniversityDepartment.History, AllExistingGenders.Male);

            var techTeacher = new Teacher("Severus", "Snape", UniversityDepartment.Tech, AllExistingGenders.Male);
            var mathTeacher = new Teacher("Minerva", "MacGonagall", UniversityDepartment.Math, AllExistingGenders.Female);
            var histTeacher = new Teacher("Anna", "Zauceva", UniversityDepartment.History, AllExistingGenders.Female);

            var techStudent = new Student("Sergei", "Tishkov", UniversityDepartment.Tech, AllExistingGenders.Male);
            var mathStudent = new Student("Aleksandr", "Maisak", UniversityDepartment.Math, AllExistingGenders.Male);
            var histStudent = new Student("Anton", "Akulenok", UniversityDepartment.History, AllExistingGenders.Male);

            univer.AddPeoples(techHeadmaster,  techTeacher, techStudent, mathHeadmaster,  mathTeacher, mathStudent, histHeadmaster, histTeacher, histStudent);

            Console.WriteLine("\n\nПробуем добавить такого же человека снова:");

            var techTeacher1 = new Teacher("Severus", "Snape", UniversityDepartment.Tech, AllExistingGenders.Male);
            univer.AddPeople(techTeacher1);

            Console.WriteLine("\n\nА теперь пробуем дать им денег:");

            univer.GiveThemMoney();

        }
    }
}
