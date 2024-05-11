namespace Task2
{
    internal class Person
    {
        public string Surname { get; set; }

        public Person(string surname)
        {
            if (!IsValidName(surname))
                throw new CustomException("Фамилия должна содержать только буквы!");

            Surname = surname;
        }

        private bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}