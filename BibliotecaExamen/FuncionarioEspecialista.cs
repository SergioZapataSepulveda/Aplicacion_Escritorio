using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaExamen
{
    public class FuncionarioEspecialista : FuncionarioBase, Ifuncionario
    {
        private int _AniosEspecializacion;

        public int AniosEspecializacion
        {
            get { return _AniosEspecializacion; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Error, Los años de experiencia deben ser igual o mayores a 1")); 
                }
                _AniosEspecializacion = value; }
        }
        

        public FuncionarioEspecialista()
        {
            this.Init();
        }


        private void Init()
        {
            AniosEspecializacion = 10;
        }



        public bool Vacaciones()
        {
            if (MesesCont >= 12)
                return true;
            return false;
        }

        public double BonoAnual()
        {
            if (AniosEspecializacion > 2)
                return SueldoLiquido * 0.05;
            return 0;
        }

        public double BonoTrienio()
        {
            if (AniosEspecializacion > 4 && (MesesCont / 12) > 3)
                return SueldoLiquido * 0.05;
            return 0;
        }
    }
}