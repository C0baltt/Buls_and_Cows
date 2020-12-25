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
            Console.WriteLine("Добро пожаловать! Это игра \"Быки и Коровы \"\n" +
                "Знаете ли вы правила?\n" +
                "Введите 1, если знаете и 0, если нет");

            string input;
            int a;
            
            for (; ; )
            {
                input = Console.ReadLine();
                if (Int32.TryParse(input, out a))
                {
                    if (a == 1)
                    {
                        break;
                    }
                    else if (a == 0)
                    {
                        Console.WriteLine("Правила игры:\n" +
                            "Компьютер задумывает четыре различные цифры из 0, 1, 2, ...9.Игрок делает ходы, чтобы узнать эти " +
                            "цифры и их порядок. Каждый ход состоит из четырёх цифр, 0 может стоять на первом месте." +
                            "В ответ компьютер показывает число отгаданных цифр, стоящих на своих местах(число быков) и" +
                            "число отгаданных цифр, стоящих не на своих местах(число коров)." +
                            "При этом если ввели меньше четырех цифр, остальные заполняются нулями\n" +
                            "Пример:\n" +
                            "Компьютер задумал 0834.\n" +
                            "Игрок сделал ход 8134.\n" +
                            "Компьютер ответил: 2 быка(цифры 3 и 4) и 1 корова(цифра 8).\n" +
                            "Для запуска игры нажмите Enter...");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Допустимые значения только 0 и 1!");
                        
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Допустимые значения только 0 и 1!");
                    continue;
                }
            }


            var rnd = new Random();
            //for (int y =0;y<20 ;y++ )
            for (bool exit1 = false; exit1 == false;)
            {
                int cows = 0;
                int bulls = 0;



                int[] humanArray = new int[4];

                int kolichPopytok = 1;

                int[] compArray = new int[4];//объявляем массив для числа компьютера


                //основной цикл программы
                for (bool exit2 = false; exit2 == false;)
                {
                    compArray[0] = rnd.Next(0, 9);//генерируем первую цифру числа компьютера
                    //генерируем остальной массив
                    for (int i = 1; i < 4; i++)
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

                    //Console.WriteLine(y);
                    /*//}Вывод числа компьютера (для отладки)
                    for (int i = 0; i < 4; i++)
                    {
                        Console.Write(compArray[i]);

                    }
                    Console.WriteLine();
                    //*/

                    //Console.ReadLine();
                    //цикл сравнения числа пользователя с числом компьютера
                    for (; ; )
                    {
                        int numberHuman;
                        //цикл проверки числа пользователя на допустимость
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
                        //загоняем число пользователя в массив
                        for (int i = 3; i > -1; i--)
                        {
                            int ostatok = numberHuman % 10;//находим остаток от деления на 10
                            numberHuman = numberHuman / 10;//делим число пользователя на 10
                            humanArray[i] = ostatok;//сохраняем остаток от деления в текущий элемент массива
                        }
                        //перебираем цифры копьютера
                        for (int i = 0; i < 4; i++)
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
                            bulls = 0;
                            cows = 0;
                            kolichPopytok = 0;
                            exit2 = true;
                            break;// выходим из цикла
                        }
                        Console.WriteLine($"Быков {bulls}, Коров {cows}");//выводим количество быков и коров и далее обнуляем их количство
                        bulls = 0;
                        cows = 0;
                        kolichPopytok++;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Сыграем еще?\nДля продолжения введите 1, для завершения введите 0");
                for (; ; )
                {

                    //int a = Convert.ToInt32(Console.ReadLine());
                    input = Console.ReadLine();
                    if (Int32.TryParse(input, out a))
                    {
                        if (a == 1)
                        {
                            bulls = 0;
                            cows = 0;
                            kolichPopytok = 0;
                            break;
                        }
                        else if (a == 0)
                        {
                            exit1 = true;
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
            }

            //*/
            /*if (y == 19)
            {
                Console.WriteLine("Последняя итерация");
                Console.ReadKey();
            }*/


            //Console.ReadKey();



        }
    }
}