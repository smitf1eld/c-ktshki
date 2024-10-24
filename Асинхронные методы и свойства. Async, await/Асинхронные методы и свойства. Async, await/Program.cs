using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Асинхронные_методы_и_свойства.Async__await
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.youtube.com/"; //URL веб-страницы

           
                int visibleCharacterCount = await CountVisibleCharactersAsync(url);
                Console.WriteLine($"Количество видимых символов на странице: {visibleCharacterCount}");
         
        }

        static async Task<int> CountVisibleCharactersAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                    // Асинхронно загружаем содержимое страницы
                    string content = await client.GetStringAsync(url);

                    // Подсчитываем количество видимых символов
                    int visibleCharacterCount = 0;
                    foreach (char c in content)
                    {
                        if (!char.IsWhiteSpace(c))
                        {
                            visibleCharacterCount++;
                        }
                    }

                    return visibleCharacterCount;
                
            }
        }
    }
}

