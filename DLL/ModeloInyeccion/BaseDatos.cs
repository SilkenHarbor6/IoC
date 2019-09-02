using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Model;

namespace DLL.ModeloInyeccion
{
    public class BaseDatos : IBaseDatos
    {
        #region Atributos
        private static List<IPersona> dbPersonas;
        private int index;
        private int id=3;
        #endregion
        #region Constructor
        public BaseDatos()
        {
            if (dbPersonas==null)
            {
                dbPersonas = new List<IPersona>();
            }
        }
        #endregion

        #region Metodos de la interfaz
        public bool Delete(IPersona item)
        {
            try
            {
                index = dbPersonas.FindIndex(p => p.IdPersona.Equals(item.IdPersona));
                dbPersonas.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<IPersona> GetAll()
        {
            return dbPersonas;
        }

        public IPersona GetById(int id)
        {
            return dbPersonas.Find(p => p.IdPersona.Equals(id));
        }

        public bool Save(IPersona item)
        {
            if (item.IdPersona==0)
            {
                item.IdPersona = id;
            }
            dbPersonas.Add(item);
            return true;
        }

        public bool Update(IPersona item)
        {
            try
            {
                index = dbPersonas.FindIndex(p => p.IdPersona.Equals(item.IdPersona));
                dbPersonas[index] = item;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
