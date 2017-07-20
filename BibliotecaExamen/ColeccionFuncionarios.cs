using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaExamen
{
    public class ColeccionFuncionarios : List <FuncionarioBase>
    {


        public double Est_Sueldo_Min()
        {
            return this.Min(a => a.SueldoLiquido); 
        }
        public double Est_Sueldo_Promedio()
        {
            return this.Average(a => a.SueldoLiquido);
        }
        public double Est_Sueldo_Max()
        {
            return this.Max(a => a.SueldoLiquido);
        }


        public double Est_Sueldo_Tec_Min()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Técnico).Min(a => a.SueldoLiquido);
        }
        public double Est_Sueldo_Tec_Promedio()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Técnico).Average(a => a.SueldoLiquido);
        }
        public double Est_Sueldo_Tec_Max()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Técnico).Max(a => a.SueldoLiquido);
        }



        public double Est_Sueldo_Prof_Min()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Profesional).Min(a => a.SueldoLiquido);
        }
        public double Est_Sueldo_Prof_Promedio()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Profesional).Average(a => a.SueldoLiquido);
        }
        public double Est_Sueldo_Prof_Max()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Profesional).Max(a => a.SueldoLiquido);
        }



        public double Est_Sueldo_Espec_Min()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Especialista).Min(a => a.SueldoLiquido);
        }
        public double Est_Sueldo_Espec_Promedio()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Especialista).Average(a => a.SueldoLiquido);
        }
        public double Est_Sueldo_Espec_Max() 
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Especialista).Max(a => a.SueldoLiquido);
        }



        public int Est_Edad_Min()
        {
            return this.Min(a => a.Edad);
        }
        public double Est_Edad_Promedio()
        {
            return this.Average(a => a.Edad);
        }
        public int Est_Edad_Max()
        {
            return this.Max(a => a.Edad);
        }


        // falta
        public string Est_RutMayorSueldo()
        {
            return this.Where(a => a.SueldoLiquido == this.Max(f => f.SueldoLiquido)).FirstOrDefault().Rut; 
        }
        public string Est_RutMenorSueldo()
        { 
            return this.Where(a => a.SueldoLiquido == this.Min(f => f.SueldoLiquido)).FirstOrDefault().Rut;
        }



        public double Est_Bono_Anual_Tec_Min()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Técnico).Min(a => ((Ifuncionario)a).BonoAnual());
        }
        public double Est_Bono_Anual_Tec_Promedio()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Técnico).Average(a => ((Ifuncionario)a).BonoAnual());
        }
        public double Est_Bono_Anual_Tec_Max() 
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Técnico).Max(a => ((Ifuncionario)a).BonoAnual());
        }



        public double Est_Bono_Anual_Prof_Min()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Profesional).Min(a => ((Ifuncionario)a).BonoAnual());
        }
        public double Est_Bono_Anual_Prof_Promedio()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Profesional).Average(a => ((Ifuncionario)a).BonoAnual());
        }
        public double Est_Bono_Anual_Prof_Max()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Profesional).Max(a => ((Ifuncionario)a).BonoAnual());
        }



        public double Est_Bono_Anual_Espec_Min()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Especialista).Min(a => ((Ifuncionario)a).BonoAnual());
        }
        public double Est_Bono_Anual_Espec_Promedio()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Especialista).Average(a => ((Ifuncionario)a).BonoAnual());
        }
        public double Est_Bono_Anual_Espec_Max()
        {
            return this.Where(a => a.Enum_Tipo_Funcionario == Enum_Tipo_Funcionario.Especialista).Max(a => ((Ifuncionario)a).BonoAnual());
        }

    }
}
