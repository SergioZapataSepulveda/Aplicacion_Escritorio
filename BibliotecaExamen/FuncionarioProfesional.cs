using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaExamen
{
    public class FuncionarioProfesional : FuncionarioBase, Ifuncionario
    {
        private int _TenicosACargo;

        public int TenicosACargo
        {
            get { return _TenicosACargo; }
            set {
                if (value < 1 || value > 300)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Error el rango de tecnicos a cargo debe estar entre 1 y 300"));
                }
                
                _TenicosACargo = value; }
        }
        
        public string CursoEspecializacion { get; set; }


        public FuncionarioProfesional()
        {
            this.Init();
        }


        private void Init()
        {
            TenicosACargo = 10;
            CursoEspecializacion = string.Empty; 
        }



        public bool Vacaciones()
        {
            if (MesesCont >= 10)
                return true;
            return false;
        }

        public double BonoAnual()
        {
            if (TenicosACargo > 30)
                return SueldoLiquido * 0.07; 
            return 0;
        }

        public double BonoTrienio()
        {
            if (TenicosACargo > 30 && (MesesCont/12) > 3)
                return SueldoLiquido * 0.07;
            return 0;
        }
    }
}
 