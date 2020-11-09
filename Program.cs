using System;
using DeptManager.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DeptManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o código do departamento desejado: ");
            string codigo= Console.ReadLine();

            using (var db= new employeesContext())
            {
                var GerenteDoDepartamento= db.DeptManager
                .Include(gd=> gd.DeptNoNavigation)
                .Include(gd=> gd.EmpNoNavigation)
                .Where(gd=> gd.DeptNoNavigation.DeptNo==codigo)
                .OrderBy(gd=> gd.ToDate);
                foreach (var GerenteDepartamento in GerenteDoDepartamento)
                {
                    Departments departamento= GerenteDepartamento.DeptNoNavigation;
                    Employees gerente= GerenteDepartamento.EmpNoNavigation;
                    
                    if (gerente.Gender=="M")
                    {
                        Console.WriteLine($" O {departamento.DeptName} é administrado pelo Sr. {gerente.LastName}");
                    }

                    else if (gerente.Gender=="F")
                    {
                        Console.WriteLine($" O {departamento.DeptName} é administrado pela Sra. {gerente.LastName}");
                    }
                }

            }
        }
    }
}