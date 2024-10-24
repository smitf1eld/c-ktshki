using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<T>
    {
        private List<T> items;

        public Stack() //конструктор
        {
            items = new List<T>();
        }

        //добавление
        public void Push(T item)
        {
            items.Add(item);
        }

        //извлечение
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст");
            }

            int lastIndex = items.Count - 1;
            T item = items[lastIndex];
            items.RemoveAt(lastIndex);
            return item;
        }

        //получение
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст");
            }

            return items[items.Count - 1];
        }

        //является ли стек пустым
        public bool IsEmpty()
        {
            return items.Count == 0;
        }

        //вывод стека
        public void PrintStack()
        {
            Console.WriteLine("Элементы стека:");
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Stack<int> intStack = new Stack<int>();

            intStack.Push(10);
            intStack.Push(20);
            intStack.Push(30);

            intStack.PrintStack();

            Console.WriteLine("Верхний элемент: " + intStack.Peek());

            Console.WriteLine("Извлеченный элемент: " + intStack.Pop());

            intStack.PrintStack();

            Console.WriteLine("Стек пуст? " + intStack.IsEmpty());

            Stack<string> stringStack = new Stack<string>();

            stringStack.Push("йоооууу??");
            stringStack.Push("оно");

            stringStack.PrintStack();

            Console.WriteLine("Верхний элемент: " + stringStack.Peek());

            Console.WriteLine("Извлеченный элемент: " + stringStack.Pop());

            stringStack.PrintStack();

            Console.WriteLine("Стек пуст? " + stringStack.IsEmpty());
        }
    }
}
