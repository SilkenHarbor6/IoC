using DLL.ModeloInyeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model
{
    public class Empleado : IPersona
    {

        #region Atributos
        private IBaseDatos db;
        #endregion
        #region Propiedades
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int edad { get; set; }
        #endregion
        #region Constructor
        public Empleado()
        {
            this.db = Inyector.Get<IBaseDatos>();
        }
        #endregion
        #region Metodos de interfaz
        public bool Delete(IPersona item)
        {
            if (item == null)
            {
                return false;
            }
            return db.Delete(item);
        }

        public List<IPersona> GetAll()
        {
            return db.GetAll();
        }

        public IPersona GetById(int id)
        {
            return db.GetById(id);
        }

        public bool Save(IPersona item)
        {
            if (item == null)
            {
                return false;
            }
            return db.Save(item);
        }

        public bool Update(IPersona item)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
