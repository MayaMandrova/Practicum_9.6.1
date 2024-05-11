using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите пять фамилий для сортировки: ");
                    List<Person> people = new List<Person>
                    {
                        new Person(Console.ReadLine()),
                        new Person(Console.ReadLine()),
                        new Person(Console.ReadLine()),
                        new Person(Console.ReadLine()),
                        new Person(Console.ReadLine())
                    };

                    Group group = new Group(people);

                    group.SortEvent += SortList;
                    group.StartProcess(ChooseSorting(), group);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }
        static int ChooseSorting()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите сортировку: \nнажмите 1, если сортировка от А до Я \nнажмите 2, если сортировка от Я до А");

                    int answer = Convert.ToInt32(Console.ReadLine());

                    if (answer != 1 && answer != 2)
                        throw new CustomException("Неверно внесены данные! Нужно выбрать 1 или 2!");
                    else
                        return answer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        static void SortList(int answer, Group group)
        {
            if (answer == 1)
                group.Persons.Sort((person1, person2) => string.Compare(person1.Surname, person2.Surname));

            else if (answer == 2)
                group.Persons.Sort((person1, person2) => string.Compare(person2.Surname, person1.Surname));

            else
                throw new CustomException("Неверно внесены данные!");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(group.Persons[i].Surname);
            }
        }
    }
}