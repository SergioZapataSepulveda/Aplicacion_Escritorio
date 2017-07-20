using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaExamen
{
    public class FuncionarioBase
    {
        private string _Rut;
        public string Rut
        {   get { return _Rut; }
            set { if (value.Length < 9 || value.Length > 10 )
                     throw new ArgumentOutOfRangeException(string.Format("Error de Rut, debe tener entre 9 y 10 caracteres ::: {0}", value.Length));

                _Rut = value; }
        }
        
        public int Edad { get; set; }
        public Enum_Genero Enum_Genero { get; set; }
        DateTime fechaMinima =  new DateTime(1900, 01, 01); 

        private DateTime _FechaNacimiento;
        public DateTime FechaNacimiento
        {   get { return _FechaNacimiento; }
            set { TimeSpan anios = DateTime.Now - value;
                  int _edad = (anios.Days) / 365;
                  if (value > DateTime.Now || value < fechaMinima)
                     throw new ArgumentOutOfRangeException(string.Format("Error de fecha de Nacimiento")); 
                  if (_edad < 18)
                     throw new ArgumentOutOfRangeException(string.Format("Error la fecha de nacimiento Funcionario debe dar una edad mayor a 18 años :::: {0} años tiene con la fecha ingresada", _edad));
                
                  Edad = _edad;
                  _FechaNacimiento = value; }
        }

        private DateTime _FechaContratacion;
        public DateTime FechaContratacion
        {   get { return _FechaContratacion; }
            set { if (value > DateTime.Now || value < fechaMinima)
                     throw new ArgumentOutOfRangeException(string.Format("Error de fecha de Contrato"));

                  TimeSpan meses = DateTime.Now - value;
                  int contrato = (meses.Days * 12)/ 365;
                  MesesCont = contrato;
                  _FechaContratacion = value; }
        }

        private int _SueldoBase;
        public int SueldoBase
        {   get { return _SueldoBase; }
            set { SueldoLiquido = value*0.81;
                  _SueldoBase = value; }
        }
        
        public double SueldoLiquido { get; set; }

        public Enum_Tipo_Funcionario Enum_Tipo_Funcionario { get; set; }
        public int MesesCont { get; set; }
        public string NomJefe { get; set; }
        public Jefatura Jefatura { get; set; }
        


        public FuncionarioBase()
        {
            this.Init(); 
        }


        private void Init()
        {
            Rut = "2223442-3";
            Edad = 0;
            Enum_Genero = Enum_Genero.Femenino;
            FechaNacimiento = new DateTime(1990, 01, 01); // tiene que estar inicializada de esta manera para evitar problemas en la validacion al darle un valor 
            FechaContratacion = new DateTime(2010, 01, 01);
            SueldoBase = 0;
            SueldoLiquido = 0;
            Enum_Tipo_Funcionario = Enum_Tipo_Funcionario.Especialista;
            Jefatura = new Jefatura();
            NomJefe = "Jefe CTM"; 
            
        }



        public StringBuilder MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(string.Format("Rut funcionario: {0}", Rut));
            datos.AppendLine(string.Format("Edad funcionario: {0}", Edad));
            datos.AppendLine(string.Format("Genero funcionario: {0}", Enum_Genero));
            datos.AppendLine(string.Format("Nacimiento funcionario: {0}", FechaNacimiento.ToString("dd/MM/yyyy")));
            datos.AppendLine(string.Format("Rut funcionario: {0}", Enum_Tipo_Funcionario));
            datos.AppendLine(string.Format("Nombre Jefe: {0}", Jefatura.NombreJefe)); 

            return datos; 
        }



        public void NombreJefe()
        {
            NomJefe = Jefatura.NombreJefe;
        }


    }
}
