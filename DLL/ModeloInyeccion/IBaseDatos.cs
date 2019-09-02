using DLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ModeloInyeccion
{
    public interface IBaseDatos
    {
        List<IPersona> GetAll();
        IPersona GetById(int id);
        bool Save(IPersona item);
        bool Delete(IPersona item);
        bool Update(IPersona item);
    }
}
