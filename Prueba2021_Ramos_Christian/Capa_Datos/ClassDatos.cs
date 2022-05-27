using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;
using System.Configuration;

namespace Capa_Datos
{
    public class ClassDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        //SqlConnection cn = new SqlConnection("server=localhost;integrated security=true;database=DB_PRUEBA");
        public DataTable listar_proveedores()
        {
            SqlCommand cmd = new SqlCommand("usp_Listar_Proveedores", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String mantenimiento_proveedores(ClassEntidad objE)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("usp_Mantenimeintos_Proveedores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_proveedor", objE.cod_proveedor);
            cmd.Parameters.AddWithValue("@dsc_ruc", objE.dsc_ruc);
            cmd.Parameters.AddWithValue("@dsc_razon_social", objE.dsc_razon_social);
            cmd.Parameters.AddWithValue("@dsc_nombre_comercial", objE.dsc_nombre_comercial);
            cmd.Parameters.AddWithValue("@num_celular", objE.num_celular);
            cmd.Parameters.AddWithValue("@dsc_direccion", objE.dsc_direccion);
            cmd.Parameters.AddWithValue("@fecha_creacion", objE.fecha_creacion);
            cmd.Parameters.AddWithValue("@flg_activo", objE.flg_activo);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = objE.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }
    }
}
