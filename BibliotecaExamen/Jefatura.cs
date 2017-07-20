using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaExamen
{
    public class Jefatura
    {
        public string Rut { get; set; }
        public string NombreJefe { get; set; }
        public int Edad { get; set; }

        DateTime FechaMinima = new DateTime(1990, 01, 01); 
        private DateTime _FechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set {
                TimeSpan tiempo = DateTime.Now - value;
                double anios = tiempo.Days / 365;

               
                Edad = (int)anios; 
                _FechaNacimiento = value; }
        }

        public Enum_Jefatura_Estudios Enum_Jefatura_Estudios { get; set; }



        public Jefatura()
        {
            this.Init(); 

        }

        private void Init()
        {
            Rut = "2242";
            NombreJefe = "Jefe Cirujanos"; 
            Edad = 0;
            FechaNacimiento = new DateTime(1900, 01, 01);
            Enum_Jefatura_Estudios = Enum_Jefatura_Estudios.Doctorado; 
        }




        
    }
}
