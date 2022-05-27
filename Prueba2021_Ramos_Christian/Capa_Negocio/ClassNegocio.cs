using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
using System.Data;

namespace Capa_Negocio
{
    public class ClassNegocio
    {
        ClassDatos objD = new ClassDatos();

        public DataTable N_listar_proveedores()
        {
            return objD.listar_proveedores();
        }

        public String N_mantenimiento_proveedores(ClassEntidad objE)
        {
            return objD.mantenimiento_proveedores(objE);
        }

    }
}
