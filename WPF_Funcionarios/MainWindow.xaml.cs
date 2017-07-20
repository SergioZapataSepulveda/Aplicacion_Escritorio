using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BibliotecaExamen; 


namespace WPF_Funcionarios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ColeccionFuncionarios ListadoFuncionarios = new ColeccionFuncionarios(); 

        public MainWindow()
        {
            InitializeComponent();
            InicializarComponentes();

        }

        private void InicializarComponentes()
        {
            this.cbo_Genero.ItemsSource = Enum.GetValues(typeof(Enum_Genero));
            this.cbo_TipoFuncionario.ItemsSource = Enum.GetValues(typeof(Enum_Tipo_Funcionario));
            this.cbo_Tecnico_Rotacion.ItemsSource = Enum.GetValues(typeof(Enum_Tecnico_Rotacion));
            this.cbo_Jefatura_Estudios.ItemsSource = Enum.GetValues(typeof(Enum_Jefatura_Estudios));

            this.cbo_Genero.SelectedValue = Enum_Genero.Femenino;
            this.cbo_TipoFuncionario.SelectedValue = Enum_Tipo_Funcionario.Técnico;
            this.cbo_Tecnico_Rotacion.SelectedValue = Enum_Tecnico_Rotacion.UCI; 
            this.cbo_Jefatura_Estudios.SelectedValue = Enum_Jefatura_Estudios.Superior; 

            this.dtp_Fecha_Nacimiento.SelectedDate = new DateTime(1998, 01, 01);
            this.dtp_Fecha_Contrato.SelectedDate = new DateTime(2014,01,01);
            this.dtp_Jefatura_Fecha_Nacimiento.SelectedDate = new DateTime(1970, 01, 01);

            validarOpciones(); 
        }

        private void validarOpciones()
        {
            if (cbo_TipoFuncionario.SelectedValue != null)
            {
                if ((Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue == Enum_Tipo_Funcionario.Técnico)
                {
                    this.txt_Tecnico_Turnos.Text = string.Empty; // pregunta para que hay que agregar esta linea ? auto respuesta:  evita que quede informacion de campos anteriores
                    this.txt_Tecnico_Turnos.IsEnabled = true; 
                    this.cbo_Tecnico_Rotacion.IsEnabled = true;

                    this.txt_Profesional_Especializacion.Text = string.Empty;
                    this.txt_Profesional_Especializacion.IsEnabled = false;
                    this.txt_Profesional_TecnicosACargo.Text = string.Empty;
                    this.txt_Profesional_TecnicosACargo.IsEnabled = false;

                    this.txt_Especialista_AniosEspecializacion.Text = string.Empty;
                    this.txt_Especialista_AniosEspecializacion.IsEnabled = false; 
                }

                if ((Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue == Enum_Tipo_Funcionario.Profesional)
                {
                    this.txt_Tecnico_Turnos.Text = string.Empty;
                    this.txt_Tecnico_Turnos.IsEnabled = false;
                    this.cbo_Tecnico_Rotacion.IsEnabled = false;

                    this.txt_Profesional_Especializacion.Text = string.Empty;
                    this.txt_Profesional_Especializacion.IsEnabled = true;
                    this.txt_Profesional_TecnicosACargo.Text = string.Empty;
                    this.txt_Profesional_TecnicosACargo.IsEnabled = true;

                    this.txt_Especialista_AniosEspecializacion.Text = string.Empty;
                    this.txt_Especialista_AniosEspecializacion.IsEnabled = false;
                }

                if ((Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue == Enum_Tipo_Funcionario.Especialista)
                {
                    this.txt_Tecnico_Turnos.Text = string.Empty;
                    this.txt_Tecnico_Turnos.IsEnabled = false;
                    this.cbo_Tecnico_Rotacion.IsEnabled = false;

                    this.txt_Profesional_Especializacion.Text = string.Empty;
                    this.txt_Profesional_Especializacion.IsEnabled = false;
                    this.txt_Profesional_TecnicosACargo.Text = string.Empty;
                    this.txt_Profesional_TecnicosACargo.IsEnabled = false;

                    this.txt_Especialista_AniosEspecializacion.Text = string.Empty;
                    this.txt_Especialista_AniosEspecializacion.IsEnabled = true;
                } 
            }
        }

        private void cbo_TipoFuncionario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validarOpciones(); 
        }





        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FuncionarioBase registro = new FuncionarioBase();


                if ((Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue == Enum_Tipo_Funcionario.Técnico)
                {
                    FuncionarioTecnico _FuncionarioTecnico = new FuncionarioTecnico();
                    _FuncionarioTecnico.Turnos = int.Parse(txt_Tecnico_Turnos.Text);
                    _FuncionarioTecnico.Enum_Tecnico_Rotacion = (Enum_Tecnico_Rotacion)cbo_Tecnico_Rotacion.SelectedValue;
                    _FuncionarioTecnico.Enum_Tipo_Funcionario = (Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue;
                    registro = _FuncionarioTecnico;
                }
                if ((Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue == Enum_Tipo_Funcionario.Profesional)
                {
                    FuncionarioProfesional _FuncionarioProfesional = new FuncionarioProfesional();
                    _FuncionarioProfesional.TenicosACargo = int.Parse(txt_Profesional_TecnicosACargo.Text);
                    _FuncionarioProfesional.CursoEspecializacion = txt_Profesional_Especializacion.Text;
                    _FuncionarioProfesional.Enum_Tipo_Funcionario = (Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue; 
                    registro = _FuncionarioProfesional;
                }
                if ((Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue == Enum_Tipo_Funcionario.Especialista)
                {
                    FuncionarioEspecialista _FuncionarioEspecialista = new FuncionarioEspecialista();
                    _FuncionarioEspecialista.AniosEspecializacion = int.Parse(txt_Especialista_AniosEspecializacion.Text);
                    _FuncionarioEspecialista.Enum_Tipo_Funcionario = (Enum_Tipo_Funcionario)cbo_TipoFuncionario.SelectedValue; 

                    registro = _FuncionarioEspecialista;
                }

                registro.Rut = txt_Rut.Text;
                registro.Enum_Genero = (Enum_Genero)cbo_Genero.SelectedValue;
                registro.FechaNacimiento = (DateTime)dtp_Fecha_Nacimiento.SelectedDate;
                registro.FechaContratacion = (DateTime)dtp_Fecha_Contrato.SelectedDate;
                registro.SueldoBase = int.Parse(txt_SueldoBase.Text);
                registro.Jefatura.Rut = txt_Jefatura_Rut.Text;
                registro.Jefatura.FechaNacimiento = (DateTime)dtp_Jefatura_Fecha_Nacimiento.SelectedDate;

                registro.Jefatura.Enum_Jefatura_Estudios = (Enum_Jefatura_Estudios)cbo_Jefatura_Estudios.SelectedValue;
                registro.Jefatura.NombreJefe = txt_Jefatura_Nombre_Jefe.Text;
                registro.NombreJefe(); 
         

                ListadoFuncionarios.Add(registro);

                dg_Mostrar.ItemsSource = ListadoFuncionarios;
                dg_Mostrar.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error {0}", ex.Message)); 
            }
        }

        private void dg_Mostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Mostrar.SelectedIndex != -1)
            {
                Ifuncionario registroDataGrid = (Ifuncionario)ListadoFuncionarios[dg_Mostrar.SelectedIndex];

                chk_Chek_Vacaciones.IsChecked = registroDataGrid.Vacaciones();
                txt_bono_Anual.Text = registroDataGrid.BonoAnual().ToString();
                txt_bono_Trienio.Text = registroDataGrid.BonoTrienio().ToString();
            }  
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.txt_Est_Sueldo_Min.Text = ListadoFuncionarios.Est_Sueldo_Min().ToString();
                this.txt_Est_Sueldo_Promedio.Text = ListadoFuncionarios.Est_Sueldo_Promedio().ToString();
                this.txt_Est_Sueldo_Max.Text = ListadoFuncionarios.Est_Sueldo_Max().ToString();

                this.txt_Est_Tec_Sueldo_Min.Text = ListadoFuncionarios.Est_Sueldo_Tec_Min().ToString();
                this.txt_Est_Tec_Sueldo_Promedio.Text = ListadoFuncionarios.Est_Sueldo_Tec_Promedio().ToString();
                this.txt_Est_Tec_Sueldo_Max.Text = ListadoFuncionarios.Est_Sueldo_Tec_Max().ToString();

                this.txt_Est_Profec_Sueldo_Min.Text = ListadoFuncionarios.Est_Sueldo_Prof_Min().ToString();
                this.txt_Est_Profec_Sueldo_Promedio.Text = ListadoFuncionarios.Est_Sueldo_Prof_Promedio().ToString();
                this.txt_Est_Profec_Sueldo_Max.Text = ListadoFuncionarios.Est_Sueldo_Prof_Max().ToString();

                this.txt_Est_Espec_Sueldo_Min.Text = ListadoFuncionarios.Est_Sueldo_Espec_Min().ToString();
                this.txt_Est_Espec_Sueldo_Promedio.Text = ListadoFuncionarios.Est_Sueldo_Espec_Promedio().ToString();
                this.txt_Est_Espec_Sueldo_Max.Text = ListadoFuncionarios.Est_Sueldo_Espec_Max().ToString();

                this.txt_Est_Edad_Min.Text = ListadoFuncionarios.Est_Edad_Min().ToString();
                this.txt_Est_Edad_Promedio.Text = ListadoFuncionarios.Est_Edad_Promedio().ToString();
                this.txt_Est_Edad_Max.Text = ListadoFuncionarios.Est_Edad_Max().ToString();

                this.txt_Est_Rut_Sueldo_Max.Text = ListadoFuncionarios.Est_RutMayorSueldo();
                this.txt_Est_Rut_Sueldo_Min.Text = ListadoFuncionarios.Est_RutMenorSueldo(); 

            }
            catch (Exception)
            {
                MessageBox.Show("Atención 1 o más campos no tienen datos para mostrar"); 
            }
        }
    }
}
