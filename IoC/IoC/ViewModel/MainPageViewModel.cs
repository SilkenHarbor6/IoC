using DLL.Model;
using DLL.ModeloInyeccion;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace IoC.ViewModel
{
    public class MainPageViewModel:BaseViewModel
    {
        public ObservableCollection<IPersona> Personas { get; set; }
        private bool isRefresh;
        private IPersona p;
        public IPersona Persona
        {
            get
            {
                return p;
            }
            set
            {
                p = value; OnPropertyChanged("Persona");
            }
        }
        public MainPageViewModel()
        {
            CargarDatos();
        }
        public bool IsRefreshing
        {
            get
            {
                return isRefresh;
            }
            set
            {
                if (isRefresh == value)
                {
                    return;
                }
                isRefresh = value; OnPropertyChanged("IsRefreshing");
            }
        }
        public ICommand Refresh
        {
            get
            {
                return new RelayCommand(CargarDatos);
            }
        }
        private void CargarDatos()
        {
            isRefresh = false;
            Personas = new ObservableCollection<IPersona>();
            var alumno = Inyector.Get<IPersona>();
            var gestion = Inyector.Get<IBaseDatos>();
            alumno.IdPersona = 1;
            alumno.Nombre = "Juan";
            alumno.Apellido = "Salvador";
            alumno.Direccion = "Santana";
            alumno.edad = 30;
            gestion.Save(alumno);

            alumno = Inyector.Get<IPersona>();
            alumno.IdPersona = 2;
            alumno.Nombre = "Juan";
            alumno.Apellido = "Salvador";
            alumno.Direccion = "Santana";
            alumno.edad = 35;
            gestion.Save(alumno);
            foreach (var item in gestion.GetAll())
            {
                Personas.Add(item);
            }
        }
    }
}
