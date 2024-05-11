using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Group
    {
        public List<Person> Persons { get; set; }
        public Group(List<Person> persons)
        {
            Persons = persons;
        }

        public delegate void SortDelegate(int answer, Group group);

        public event SortDelegate SortEvent;

        public void StartProcess(int answer, Group group)
        {
            Console.WriteLine("Начинаем сортировку!");
            OnChooseTaken(answer, group);
        }

        protected virtual void OnChooseTaken(int answer, Group group)
        {
            SortEvent?.Invoke(answer, group); 
        }
    }
}