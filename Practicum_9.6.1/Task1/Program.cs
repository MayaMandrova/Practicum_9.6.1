using System;
public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var exceptions = new Exception[]
            {
                new ArgumentException("ArgumentException"),
                new FileNotFoundException("FileNotFoundException"),
                new IndexOutOfRangeException("IndexOutOfRangeException"),
                new InvalidOperationException("InvalidOperationException"),
                new CustomException("Произошла непредвиденная ошибка в приложении. Перезагрузите программу!")
            };
            int count = 1;

            foreach (var ex in exceptions)
            {
                try
                {
                    throw ex;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Непустой аргумент, передаваемый в метод, является недопустимым: " + e.Message);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("Файл не существует: " + e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Индекс находится за пределами границ массива или коллекции: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Вызов метода недопустим в текущем состоянии объекта: " + e.Message);
                }
                catch (CustomException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Блок finally выполнен {0}-й раз", count);
                    Console.WriteLine();
                    count++;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Общее исключение: " + e.Message);
        }
    }
}