using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Сотрудники
{
    class Employee : Person
    {
        protected int DepartmentNumber;    //номер отдела
        public int NightShiftsCount;    //количество ночных смен за мес
        public int DayShiftsCount;      //количество дневных смен за мес
        protected int DayShiftsMin = 25;   //число обязательных смен, после которых уже начисляется процент начальнику смены
        protected int NightShiftsMin = 15; //число обязательных ночныз смен для начисления премии начальнику смены
        protected double salary;           //зарплата

        private double NightShiftCost = 2200; //ночная смена
        private double DayShiftCost = 1600; //Дневная смена

        public Employee(string name, int age, int DepartmentNumber, int NightShiftsCount, int DayShiftsCount, int DayShiftsMin, int NightShiftsMin) : base(name, age) //наследуем значения от класса Person
        {
            this.DayShiftsCount = DayShiftsCount;
            this.NightShiftsCount = NightShiftsCount;
        }
        public void ShiftsCount(int DayShiftsMin, int NightShiftsMin)  //перекидываем минимальные значения отсюда в Main
        {
            DayShiftsMin = this.DayShiftsMin;
            NightShiftsMin = this.NightShiftsMin;
        }
        public void Dayshiftscount(int DayShiftsCount, int NightShiftsCount)
        {
            DayShiftsCount = this.DayShiftsCount;
            NightShiftsCount = this.NightShiftsCount;
        }
        public void Shifts(Employee[] people, int i, int age) //заполнение смен
        {
            Random rnd = new Random();
            if (age < 18)  //если младше 18, то только дневные смены
            {
                DayShiftsCount = rnd.Next(20, 60); //может как отработать меньше, так и переработать
            }
            else if (age >= 18) //если старше - и дневные, и ночные
            {
                NightShiftsCount = rnd.Next(20, 40);
                DayShiftsCount = rnd.Next(20, 40);
            }

            DepartmentInfo(people, i); //отдел
        }
        private void DepartmentInfo(Employee[] people, int i)
        {
            if (i < 5) //если индекс меньше 5, то закидываем сотрудников в первый отдел
            {
                people[i].DepartmentNumber = 1;  //указали номер отдела                                                       
            }
            else
            {
                people[i].DepartmentNumber = 2;
            }
        }

        private double EmployeeSalary(double salary) //расчет заработной платы каждого сотрудника
        {
            salary = DayShiftCost * DayShiftsCount + NightShiftCost * NightShiftsCount; //стоимость ночных и дневных смен
            return salary;
        }

        public void EmployeeInfoOutput() //выводим информацию о сотрудниках
        {
            base.InfoOutput(); //имя и возраст

            Console.WriteLine($"\tНомер отдела: {DepartmentNumber}");
            Console.WriteLine($"\tВсего отработано смен за месяц: {DayShiftsCount + NightShiftsCount}, из них:");
            Console.WriteLine($"\tДневных: {DayShiftsCount}");
            Console.WriteLine($"\tНочных: {NightShiftsCount}");

            salary = EmployeeSalary(salary);  //рассчитали зарплату
            Console.WriteLine($"\tЗарплата: {salary} руб");
        }
    }
}