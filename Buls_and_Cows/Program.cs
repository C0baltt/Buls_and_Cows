using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulls_and_cows
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();

            //for (int y =0;y<20 ;y++ )
            for (; ; )//основной цикл программы
            {
                int cows = 0;
                int bulls = 0;

                string input;

                int[] humanArray = new int[4];

                int kolichPopytok = 1;

                int[] compArray = new int[4];//объявляем массив для числа компьютера
                compArray[0] = rnd.Next(0, 9);//генерируем первую цифру числа компьютера

                for (int i = 1; i < 4; i++)//генерируем остальной массив
                {
                    compArray[i] = rnd.Next(0, 9);//генерируем цифру

                    {
                        for (int j = i - 1; j > -1; j--)//перебираем все предыдущие цифры
                        {
                            if (compArray[i] == compArray[j])//если текущая цифра равна одной из предыдущих,то=>
                            {
                                compArray[i] = rnd.Next(0, 9);//=> генерируем ее по-новой
                                j = i;//=> и опять проверяем на совпадение с остальными => 
                                //=> (for начнется с j == i , т.к. в начале цикла сработает=>
                                //=> декремент и будем перебирать как раз с предыдущего)
                            }

                        }


                    }


                }
                //}Вывод числа компьютера (для отладки)
                //Console.WriteLine(y);
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(compArray[i]);

                }
                Console.WriteLine();
                //*/


                //Console.ReadLine();
                for (; ; )//цикл сравнения числа пользователя с числом компьютера
                {
                    int numberHuman;
                    for (; ; )
                    {
                        Console.WriteLine($"Попытка № {kolichPopytok}.\nВведи четырехзначное число:");

                        input = Console.ReadLine();
                        if (Int32.TryParse(input, out numberHuman))
                        {
                            //numberHuman = Convert.ToInt32(Console.ReadLine());//=> 
                            //=> преобразуем строку пользовотеля в число

                            if (numberHuman >= 0 && numberHuman < 10000)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Допустимы только числа в диапазоне от 0 до 9999 включительно!");
                                //Console.ReadLine();
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Допустимы только числа в диапазоне от 0 до 9999 включительно!");
                            //Console.ReadLine();
                            continue;
                        }

                    }
                    for (int i = 3; i > -1; i--)//загоняем число пользователя в массив
                    {
                        int ostatok = numberHuman % 10;//находим остаток от деления на 10
                        numberHuman = numberHuman / 10;//делим число пользователя на 10
                        humanArray[i] = ostatok;//сохраняем остаток от деления в текущий элемент массива
                    }

                    for (int i = 0; i < 4; i++)//перебираем цифры копьютера
                    {
                        for (int j = 0; j < 4; j++)//перебираем цфры пользователя
                        {
                            if (humanArray[i] == compArray[j])//если цифра компьютера равна цифре пользователя, то=> 
                            {

                                if (i == j)//=> если позиция совпадает, то//=> 
                                {
                                    bulls++;//=> быки +1
                                }
                                else
                                {
                                    cows++;//=> если позиция не совпадает, то коровы +1 //=> 
                                }
                            }
                        }
                    }

                    if (bulls == 4)//если быков 4, значит число угадано
                    {
                        Console.Write("Поздравляю, вы угадали число! Это ");
                        for (int i = 0; i < 4; i++)//выводим число:
                        {
                            Console.Write(compArray[i]);

                        }
                        Console.WriteLine();
                        Console.WriteLine($"Количество попыток   {kolichPopytok}");
                        break;// выходим из цикла
                    }
                    Console.WriteLine($"Быков {bulls}, Коров {cows}");//выводим количество быков и коров и далее обнуляем их количство
                    bulls = 0;
                    cows = 0;
                    kolichPopytok++;
                }
                Console.WriteLine();
                do
                {
                    int a;
                    Console.WriteLine("Для продолжения введите 1, для завершения введите 0");
                    //int a = Convert.ToInt32(Console.ReadLine());
                    input = Console.ReadLine();
                    if (Int32.TryParse(input, out a))
                    {
                        if (a == 1)
                        {
                            bulls = 0;
                            cows = 0;
                            kolichPopytok = 0;
                            continue;
                        }
                        else if (a == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Допустимые значения только 0 и 1!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Допустимые значения только 0 и 1!");
                    }
                }
                while (a == 0 || a == 1) ;
                //*/
                /*if (y == 19)
                {
                    Console.WriteLine("Последняя итерация");
                    Console.ReadKey();
                }*/
                Console.ReadKey();
            }

        }
    }
}