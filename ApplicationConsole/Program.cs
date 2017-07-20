using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaExamen;

namespace ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FuncionarioBase func = new FuncionarioBase();
            func.Rut = "12314861-1";
            func.Enum_Genero = Enum_Genero.Femenino;
            func.FechaNacimiento = new DateTime(1990, 01, 01);
            func.Enum_Tipo_Funcionario = Enum_Tipo_Funcionario.Especialista;
            func.Jefatura.NombreJefe = "Jose Risopatron";

            Console.WriteLine(func.MostrarDatos());
            Console.ReadLine(); 
        }
    }
}
