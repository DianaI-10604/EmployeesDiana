using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сотрудники
{
    class ShiftLeader : Employee
    {
        //создать в Main массив начальников
        public double ShiftLeaderSalary = 108390;  //зарплата начальника дневной смены //изначально оклад
        private int OvertimeWork = 0;
        public double Bonus = 0;       //итоговая сумма премии
        //private double BonusValue = 0; //сумма за каждого сотрудника (в %)

        public ShiftLeader(string name, int age, int DepartmentNumber, int NightShiftsCount, int DayShiftsCount, int DayShiftsMin, int NightShiftsMin) : base(name, age, DepartmentNumber, NightShiftsCount, DayShiftsCount, DayShiftsMin, DayShiftsMin)
        { }
        public void TimeWork(int OvertimeWork) //закидываем отсюда туда
        {
            this.OvertimeWork = OvertimeWork;
        }
        //public void Bonusvalue(double BonusValue) //закидываем в Main
        //{
        //    BonusValue = this.BonusValue;
        //}
        public void SalaryBonus(double Bonus) //закидываем отсюда туда
        {
            Bonus = this.Bonus;
        }
        public double LeaderSalary(int OvertimeWork, out double BonusValue) //расчет заработной платы начальника смены
        {
            BonusValue = 0;
            BonusValue = BonusCheck(OvertimeWork, BonusValue);

            ShiftLeaderSalary += ShiftLeaderSalary * BonusValue; //условие того, каким будет BonusValue, находится в Main
            return ShiftLeaderSalary;
        }
        private double BonusCheck(int OvertimeWork, double BonusValue)  //считаем размер бонуса за каждого сотрудника
        {
            if (OvertimeWork >= 1 && OvertimeWork <= 10) //Бонус 3% от оклада
            {
                BonusValue = 0.03;
            }
            else if (OvertimeWork >= 11 && OvertimeWork <= 15) //Бонус 5% от оклада
            {
                BonusValue = 0.05;
            }
            else if (OvertimeWork >= 16) //бонус 7%
            {
                BonusValue = 0.07;
            }
            return BonusValue;
        }
        public double BonusCount(double BonusValue) //считаем бонус
        {
            Bonus += ShiftLeaderSalary * BonusValue;
            return Bonus;
        }
        public int DayOvertimeCount(int DayShiftsCount) //считаем сколько переработано ДНЕВНЫХ СМЕН
        {
            OvertimeWork += DayShiftsCount - DayShiftsMin;
            return OvertimeWork;
        }
        public int NightOvertimeCount(int NightShiftsCount) //переработка НОЧНЫХ СМЕН
        {
            OvertimeWork += NightShiftsCount - NightShiftsMin;
            return OvertimeWork;
        }
        public void LeadersInfoOutput() //выводим информацию о начальниках смены
        {
            Console.WriteLine($"Зарплата: {Math.Round(ShiftLeaderSalary, 3)}");
            Console.WriteLine($"Всего переработок на {OvertimeWork} смены");
            Console.WriteLine($"Итоговый бонус: {Math.Round(Bonus, 3)} руб");
        }
    }
}
