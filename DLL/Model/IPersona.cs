using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model
{
    public interface IPersona
    {
        int IdPersona { get; set; }
        String Nombre { get; set; }
        String Apellido { get; set; }
        String Direccion { get; set; }
        int edad { get; set; }
        List<IPersona> GetAll();
        IPersona GetById(int id);
        bool Save(IPersona item);
        bool Delete(IPersona item);
        bool Update(IPersona item);
    }
}
