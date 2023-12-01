using System;

namespace Сотрудники
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            int age = 0;
            int DepartmentNumber = 0; //номер отдела
            int OvertimeWork = 0;     //переносим из класса
            int DayShiftsMin = 0;     //переносим из класса
            int NightShiftsMin = 0;   //число обязательных смен (переносим из класса)
            double LeaderSalary;      //итоговая зарплата начальника смены
            double Bonus = 0;         //сумма премии
            double BonusValue = 0;

            Random rnd = new Random();

            Employee employee = new Employee("", 0, 0, 0, 0, 0, 0);
            ShiftLeader leader = new ShiftLeader("", 0, 0, 0, 0, 0, 0);
            Employee[] people = new Employee[7];          //массив сотрудников
            ShiftLeader[] leaders = new ShiftLeader[2];   //массив начальников

            leader.ShiftsCount(DayShiftsMin, NightShiftsMin); //записали сюда значения из класса ShiftLeader

            //СОТРУДНИКИ
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"Сотрудник {i + 1}");
                people[i] = new Employee("", 0, 0, 0, 0, 0, 0);

                Console.Write("\tВведите имя: ");
                name = Console.ReadLine();

                Console.Write("\tВведите возраст: ");       //должен быть от 16 до 50
                age = Convert.ToInt32(Console.ReadLine());
                while (age < 16 || age > 50)
                {
                    Console.WriteLine("Возраст не подходит, введите заново: ");
                    age = Convert.ToInt32(Console.ReadLine());
                }

                if (i < 5) //если индекс меньше 5, то закидываем сотрудников в первый отдел
                {
                    DepartmentNumber = 1;                            //указали номер отдела
                    people[i].EmployeeDepartment(DepartmentNumber);  //записали номер отдела
                }
                else
                {
                    DepartmentNumber = 2;
                    people[i].EmployeeDepartment(DepartmentNumber);
                }

                people[i].PersonInfo(name, age);   //записываем введенные значения в класс
                people[i].Shifts(age);             //запускаем заполнение смен

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Информация о сотрудниках: ");
            for (int j = 0; j < people.Length; j++)  //вывод информации о всех сотрудниках
            {
                Console.WriteLine($"Сотрудник {j + 1}");
                people[j].EmployeeInfoOutput();

                Console.ReadKey();
                Console.WriteLine();
            }

            //НАЧАЛЬНИКИ
            for (int i = 0; i < leaders.Length; i++)
            {
                leaders[i] = new ShiftLeader("", 0, 0, 0, 0, 0, 0);

                for (int j = 0; j < people.Length; j++)
                {
                    if (people[j].DayShiftsCount > DayShiftsMin && i == 0) //если дневных смен больше обязательного минимума и рассматриваем начальника дневной смены
                    {
                        OvertimeWork = leaders[i].DayOvertimeCount(people[j].DayShiftsCount);
                    }
                    else if (people[j].NightShiftsCount > DayShiftsMin && i == 1)
                    {
                        OvertimeWork = leaders[i].NightOvertimeCount(people[j].NightShiftsCount);
                    }

                    leaders[i].TimeWork(OvertimeWork);
                    LeaderSalary = leaders[i].LeaderSalary(OvertimeWork, out BonusValue); //посчитали зарплату и сохранили

                    Bonus = leaders[i].BonusCount(BonusValue);  //посчитали размер бонуса за одного сотрудника
                    leaders[i].SalaryBonus(Bonus); //связали переменные разных класов (закинули)
                }
            }

            Console.Write("Нажмите любую клавишу, чтобы увидеть итоговую зарплату начальников каждой из смен: ");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Информация о начальниках смен: ");
            for (int j = 0; j < leaders.Length; j++)  //вывод информации о всех сотрудниках
            {
                Console.WriteLine($"Начальник смены {j + 1}");
                leaders[j].LeadersInfoOutput();

                Console.ReadKey();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
