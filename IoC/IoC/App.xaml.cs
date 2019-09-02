using DLL.Model;
using DLL.ModeloInyeccion;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace IoC
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            Inyector.Map<IBaseDatos, BaseDatos>();
            Inyector.Map<IPersona, Alumno>();
            MainPage = new MainPage();
            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
