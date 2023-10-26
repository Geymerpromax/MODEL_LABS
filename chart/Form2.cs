using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;


namespace chart
{
    public partial class Form2 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();

        
        public Form2()
        {
            InitializeComponent();
        }
        
        private void L1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Lab1);
        }
        private void L2_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Lab2);
        }
        private void L3_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Lab3);
        }
        private void L4_Click(object sender, EventArgs e)
        {            
            Task.Factory.StartNew(Lab4);          
        }


        private void Lab1()
        {          
            // Запускаем консоль.        
            AllocConsole();

            List<double> arrayPointOne = new List<double>();
            List<double> arrayPointTwo = new List<double>();

            const double g = 9.8; // Ускорение свободного падения 
            const double y0 = 2000; // Начальная высота 
            const double v0 = 50; // Начальная скорость 
            const double dt = 1; // Шаг по времени 
            const double m = 15; // Масса зонда 

            const double p = 1.2754; // Плотность воздуха
            const double c = 0.55; // безразмерный коэфициент лобового сопротивления для полусферы
            const double s = 80; // Площадь парашюта
            double k = 0.5 * c * s * p; // коэффициент сопротивления воздуха
            

            double t = 0; // Время
            //double a = 0; // Ускорение 
            double v = v0; // Скорость
            double y = y0; // Высота(Путь)

            double tRise = 0; // Время подъёма
            double tFall = 0; // Время падения
            double tGlobal = 0; // Всё время движения
            double yMax = 0; // Макс. высота
            
            Console.WriteLine("Зонд выпущен!");

            tRise = v0 / g;
          
            for (; t < tRise; t += dt)
            {               
                v = v0 - g * t;
                y = y0 + v0 * t - 0.5 * g * t * t;
                Console.WriteLine($"Прошедшее время {t} сек, Скорость {v} м/с, Высота {y} м");
                arrayPointOne.Add(t);
                arrayPointOne.Add(v);

                arrayPointTwo.Add(t);
                arrayPointTwo.Add(y);
            }
            v = v0 - g * tRise;
            yMax = y0 + v0 * tRise - 0.5 * g * tRise * tRise;
            y = yMax;

            arrayPointOne.Add(t);
            arrayPointOne.Add(v);

            arrayPointTwo.Add(t);
            arrayPointTwo.Add(y);

            Console.WriteLine($"Прошедшее время {tRise} сек, Скорость {v} м/с, Высота {yMax} м\n");
            Console.WriteLine("Парашют раскрыт!");
            Console.WriteLine($"Время подъёма {tRise} сек \nМаксимальная высота {yMax} м\n");


            for (double t1 = 0; y <= yMax; t1 += dt)
            {
                t += dt;
                v =  m * g / k * (1 - Math.Exp(-k * t1 / m));
                y = (m * g / k) * (t + (m / (k * k)) * (1 - Math.Exp(-k * t / m)));
                Console.WriteLine($"Прошедшее время {t} сек, Скорость {v} м/с, Высота {yMax - y} м");

                arrayPointOne.Add(t);
                arrayPointOne.Add(v);

                arrayPointTwo.Add(t);
                arrayPointTwo.Add(y);
            }

            Console.WriteLine($"Время падения {t} сек");
            
            

            Application.Run(new Form1(arrayPointOne, arrayPointTwo, new List<string> { "Зависимость скорости от времени", "Зависимость расстояния от времени" }));
        }
        private void Lab2()
        {
            // Запускаем консоль.        
            AllocConsole();
            double M = 100000; // масса космической станции (кг)
            double R = 6371000; // радиус Земли (м)
            double h0 = 384400000; // начальное расстояние от центра Земли до станции (м)
            double vx0 = 10; // начальная горизонтальная скорость станции (м/c)
            double G = 6.67430E-11; // гравитационная постоянная (м^3/(кг*с^2))

            double y0 = 0; // начальная вертикальная координата (на экваторе)

            // рассчитываем начальные координаты и скорости
            double x0 = R + h0;

            // моделируем движение
            double dt = 0.1; // шаг по времени (с)
            double t = 0; // текущее время (с)

            double x = 384400000;
            double y = 0;
            double vx = vx0;
            double vy = 0;

            while (x != x0 || y != y0) 
            {
                // рассчитываем расстояние до центра Земли
                double r = Math.Sqrt(x * x + y * y);

                // вычисляем ускорение
                double ax = -G * M * x / (r * r * r);
                double ay = -G * M * y / (r * r * r);

                // обновляем координаты и скорости с использованием метода Рунге-Кутты 4-го порядка
                double k1x = vx * dt;
                double k1y = vy * dt;
                double k1vx = ax * dt;
                double k1vy = ay * dt;

                double k2x = (vx + 0.5 * k1vx) * dt;
                double k2y = (vy + 0.5 * k1vy) * dt;
                double k2vx = ax * dt;
                double k2vy = ay * dt;

                double k3x = (vx + 0.5 * k2vx) * dt;
                double k3y = (vy + 0.5 * k2vy) * dt;
                double k3vx = ax * dt;
                double k3vy = ay * dt;

                double k4x = (vx + k3vx) * dt;
                double k4y = (vy + k3vy) * dt;
                double k4vx = ax * dt;
                double k4vy = ay * dt;

                x += (k1x + 2 * k2x + 2 * k3x + k4x) / 6;
                y += (k1y + 2 * k2y + 2 * k3y + k4y) / 6;
                vx += (k1vx + 2 * k2vx + 2 * k3vx + k4vx) / 6;
                vy += (k1vy + 2 * k2vy + 2 * k3vy + k4vy) / 6;

                t += dt;
            } 

            Console.WriteLine($"Космическая станция достигла орбиты Земли за время {t} секунд.");
        }
        private void Lab3()
        {
            // Запускаем консоль.        
            AllocConsole();
            int a = 3; //интенсивность внутривидовой конкуренции
            int R = 1; //скорость воспроизводства;
            double N0 = 100; //начальная численность популяции           
            double Nt = N0;
            double N = 0;
            int i = 1;
            double b = 0.1;
            while (b <= 10)
            {
                N = (Nt * R) / (1 + Math.Pow((a * Nt), b));
                Console.WriteLine("{0}. {1}", i, N);
                Nt = N;
                b += 0.1f;
                i++;
            }

        }
        private void Lab4()
        {
            int employmentFirstOperator = 0;
            int employmentSecondOperator = 0;
            //static int timeTalkFirst = 0;
            //static int timeTalkSecond = 0;
            int timerWorkDay = 0;
            int WorkDay = 1;

            int queue = 0;

            System.Timers.Timer timerWork;
            System.Timers.Timer timerUpdater;
            System.Timers.Timer timerTalkFirst;
            System.Timers.Timer timerTalkSecond;
            //int clients = 0;
            //Console.WriteLine("Введите длину рабочего дня в милисекундах: ");
            //timerWorkDay = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите количество клиентов: ");
            //clients = Convert.ToInt32(Console.ReadLine());

            // Запускаем консоль.        
            AllocConsole();
            ////

            timerWork = new System.Timers.Timer(60000);//мс
            timerWork.Elapsed += TimerWorkEvent;
            timerWork.AutoReset = true;
            timerWork.Enabled = true;
            Console.WriteLine("Начало рабочего дня в {0:HH:mm:ss}", DateTime.Now);
            Console.WriteLine("Длина рабочего дня 100000 / {0} мс\n", timerWorkDay);
            //Console.WriteLine("Количество клиентов {0}", clients);
            ////
            timerUpdater = new System.Timers.Timer(1000);//мс
            timerUpdater.Elapsed += timerUpdaterEvent;
            timerUpdater.AutoReset = true;
            timerUpdater.Enabled = true;

            Console.ReadLine();

            int RandomiseTimeTalk()
            {
                Random rand = new Random();
                int time = rand.Next(5000, 5000);
                return time;
            }
            bool RandomiseClient()
            {
                Random rand = new Random();
                int client = rand.Next(0, 2);
                if (WorkDay == 0)
                {
                    return false;
                }
                return Convert.ToBoolean(client);
            }
            void TimerWorkEvent(Object source, ElapsedEventArgs e)
            {
                WorkDay = 0;
                Console.WriteLine("\nРабочий день закончен в {0:HH:mm:ss}\nЖдём завершения текущих звонков, новые звонки не принимаются.\n", e.SignalTime);

                timerWork.Stop();
                timerWork.Dispose();
            }
            void TimeTalkFirstEvent(Object source, ElapsedEventArgs e)
            {
                queue--;
                Console.WriteLine("Звонок первому оператору завершен в {0:HH:mm:ss}", e.SignalTime);
                Console.WriteLine("Очередь обновлена.\nТекущая очередь: {0}", queue);
                employmentFirstOperator = 0;
                timerTalkFirst.Stop();
                timerTalkFirst.Dispose();
            }
            void TimeTalkSecondEvent(Object source, ElapsedEventArgs e)
            {
                queue--;
                Console.WriteLine("Звонок второму оператору завершен в {0:HH:mm:ss}", e.SignalTime);
                Console.WriteLine("Очередь обновлена.\nТекущая очередь: {0}", queue);
                employmentSecondOperator = 0;
                timerTalkSecond.Stop();
                timerTalkSecond.Dispose();
            }
            void timerUpdaterEvent(Object source, ElapsedEventArgs e)
            {
                switch (RandomiseClient())
                {
                    case true:
                        Console.WriteLine("{0:HH:mm:ss} Поступил звонок ", e.SignalTime);
                        if (WorkDay == 0)
                        {
                            Console.WriteLine("Рабочий день был закончен, звонки больше не принимаются...");
                            break;
                        }
                        queue++;
                        Console.WriteLine("Очередь обновлена.\nТекущая очередь: {0}", queue);
                        if (employmentFirstOperator == 0)
                        {
                            Console.WriteLine("Первый оператор принял звонок.");
                            employmentFirstOperator = 1;
                            timerTalkFirst = new System.Timers.Timer(RandomiseTimeTalk());
                            timerTalkFirst.Elapsed += TimeTalkFirstEvent;
                            timerTalkFirst.AutoReset = true;
                            timerTalkFirst.Enabled = true;
                            break;
                        }
                        if (employmentSecondOperator == 0)
                        {
                            Console.WriteLine("Второй оператор принял звонок.");
                            employmentSecondOperator = 1;
                            timerTalkSecond = new System.Timers.Timer(RandomiseTimeTalk());
                            timerTalkSecond.Elapsed += TimeTalkSecondEvent;
                            timerTalkSecond.AutoReset = true;
                            timerTalkSecond.Enabled = true;
                            break;
                        }
                        break;
                    case false:
                        Console.WriteLine("{0:HH:mm:ss} ----- ", e.SignalTime);
                        break;
                }
                if (employmentFirstOperator == 0 && employmentSecondOperator == 0 && WorkDay == 0)
                {
                    Console.WriteLine("\nВсе звонки завершены");
                    Console.WriteLine("Необслужено клиентов: {0}", queue);
                    timerUpdater.Stop();
                    timerUpdater.Dispose();
                }
            }
        }
    }
}
