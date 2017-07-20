using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaExamen
{
    public class FuncionarioTecnico : FuncionarioBase, Ifuncionario
    {
        private int _Turnos;

        public int Turnos
        {
            get { return _Turnos; }
            set {
                if (value <= 1)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Error el valor debe ser mayor a 1 ::: valor ingresado {0}", value));
                }
                _Turnos = value; }
        }
        
        public Enum_Tecnico_Rotacion Enum_Tecnico_Rotacion { get; set; }


        public FuncionarioTecnico()
        {
            this.Init();
        }


        private void Init()
        {
            Turnos = 10; // al hacer una validacion dentro de una propiedad "full" asignar a las variables valores distintos de los por defecto, valores que esten dentro de los rangos validos de las validaciones
            Enum_Tecnico_Rotacion = Enum_Tecnico_Rotacion.Urgencia; 
        }



        public bool Vacaciones()
        {
            if (MesesCont >= 6)
                return true;
            return false;
        }



        public double BonoAnual()
        {
            if (Turnos > 60)
                return SueldoLiquido * 0.1;
            return 0;
        }

        public double BonoTrienio()
        {
            if (Turnos > 120 && (MesesCont / 12) > 3)
                return SueldoLiquido * 0.1;
            return 0;
        }
    }
}
