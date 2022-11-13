using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace catProductos.Models
{
    public class clsProductos
    {
        public clsProductos(){
            this.intId = 0;
            this.strEstatus = "A";
            this.strNombre = "";
            this.strUnidadMedida = "";
            this.floatConsumo = 0;
            this.intInsumo = 0;
            this.doubleStock = 0;
            this.strconConnectionString = ConfigurationManager.ConnectionStrings["BDPC"].ConnectionString;
        }

        public string strconConnectionString { get; set; }
        public int intId { get; set; }
        public string strNombre { get; set; }
        public string strUnidadMedida { get; set; }
        public double doubleStock { get; set; }
        public string strEstatus { get; set; }
        public float floatConsumo { get; set; }
        public int intInsumo { get; set; }

        public string Agregar(clsProductos pobjProductos)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosAgregar", objconConexion);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre = cmdComando.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = pobjProductos.strNombre;

                SqlParameter unidad = cmdComando.Parameters.Add("@unidad", SqlDbType.VarChar, 80);
                unidad.Direction = ParameterDirection.Input;
                unidad.Value = pobjProductos.strUnidadMedida;

                SqlParameter stok = cmdComando.Parameters.Add("@stok", SqlDbType.Decimal);
                stok.Direction = ParameterDirection.Input;
                stok.Value = pobjProductos.doubleStock;

                SqlParameter consumo = cmdComando.Parameters.Add("@consumo", SqlDbType.Float);
                consumo.Direction = ParameterDirection.Input;
                consumo.Value = pobjProductos.floatConsumo;

                SqlParameter insumo = cmdComando.Parameters.Add("@insumo", SqlDbType.Int);
                insumo.Direction = ParameterDirection.Input;
                insumo.Value = pobjProductos.intInsumo;

                SqlParameter estatus = cmdComando.Parameters.Add("@estatus", SqlDbType.VarChar, 1);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = pobjProductos.strEstatus;

                objconConexion.Open();
                cmdComando.ExecuteNonQuery();
                objconConexion.Close();

                return "Operación realizada con éxito.";
            }
            catch(Exception ex)
            {
                return "Error al realizar la operación: " + ex.Message;
            }
        }

        public string Modificar(clsProductos pobjProductos)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosModificar", objconConexion);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter id = cmdComando.Parameters.Add("@idproducto", SqlDbType.Int);
                id.Direction = ParameterDirection.Input;
                id.Value = pobjProductos.intId;

                SqlParameter nombre = cmdComando.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = pobjProductos.strNombre;

                SqlParameter unidad = cmdComando.Parameters.Add("@unidad", SqlDbType.VarChar, 80);
                unidad.Direction = ParameterDirection.Input;
                unidad.Value = pobjProductos.strUnidadMedida;


                SqlParameter consumo = cmdComando.Parameters.Add("@consumo", SqlDbType.Float);
                consumo.Direction = ParameterDirection.Input;
                consumo.Value = pobjProductos.floatConsumo;

                SqlParameter insumo = cmdComando.Parameters.Add("@insumo", SqlDbType.Int);
                insumo.Direction = ParameterDirection.Input;
                insumo.Value = pobjProductos.intInsumo;

                objconConexion.Open();
                cmdComando.ExecuteNonQuery();
                objconConexion.Close();

                return "Operación realizada con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al realizar la operación: " + ex.Message;
            }
        }

        public string Inhabilitar(int pintId)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosEstatus", objconConexion);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter id = cmdComando.Parameters.Add("@idproducto", SqlDbType.Int);
                id.Direction = ParameterDirection.Input;
                id.Value = pintId;

                SqlParameter estatus = cmdComando.Parameters.Add("@estatus", SqlDbType.VarChar, 1);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = "I";

                objconConexion.Open();
                cmdComando.ExecuteNonQuery();
                objconConexion.Close();

                return "Operación realizada con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al realizar la operación: " + ex.Message;
            }
        }

        public string Habilitar(int pintId)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosEstatus", objconConexion);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter id = cmdComando.Parameters.Add("@idproducto", SqlDbType.Int);
                id.Direction = ParameterDirection.Input;
                id.Value = pintId;

                SqlParameter estatus = cmdComando.Parameters.Add("@estatus", SqlDbType.VarChar, 1);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = "A";

                objconConexion.Open();
                cmdComando.ExecuteNonQuery();
                objconConexion.Close();

                return "Operación realizada con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al realizar la operación: " + ex.Message;
            }
        }

        public string Consultar()
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosConsultar", objconConexion);
                cmdComando.CommandType = CommandType.StoredProcedure;

                objconConexion.Open();
                cmdComando.CommandTimeout = 300;
                StringBuilder strDatos = new StringBuilder();
                SqlDataReader drRegistros = cmdComando.ExecuteReader();
                strDatos.Append("[");
                while (drRegistros.Read())
                {
                    strDatos.Append("{" + '"' + "Id" + '"' + ":" + drRegistros["Id"] + ", "
                        + '"' + "Nombre" + '"' + ":" + drRegistros["Nombre"] + ", "
                        + '"' + "UnidadMedida" + '"' + ":" + drRegistros["UnidadMedida"] + ", "
                        + '"' + "Consumo" + '"' + ":" + drRegistros["Consumo"] + ", "
                        + '"' + "Stok" + '"' + ":" + drRegistros["Stok"] + ", "
                        + '"' + "Insumo" + '"' + ":" + drRegistros["Insumo"] + ", "
                        + '"' + "Estatus" + '"' + ":" + drRegistros["Estatus"] + "}, ");

                }
                strDatos.Remove(strDatos.Length - 2, 2);
                drRegistros.Close();
                strDatos.Append("]");
                return strDatos.ToString();
            }
            catch (Exception ex)
            {
                return "Error al realizar la operación: " + ex.Message;
            }
        }

        public string Buscar(string valor)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosBuscar", objconConexion);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter id = cmdComando.Parameters.Add("@valor", SqlDbType.VarChar, 80);
                id.Direction = ParameterDirection.Input;
                id.Value = valor;

                objconConexion.Open();
                cmdComando.CommandTimeout = 300;
                StringBuilder strDatos = new StringBuilder();
                SqlDataReader drRegistros = cmdComando.ExecuteReader();
                strDatos.Append("[");
                while (drRegistros.Read())
                {
                    strDatos.Append("{" + '"' + "Id" + '"' + ":" + drRegistros["Id"] + ", "
                        + '"' + "Nombre" + '"' + ":" + drRegistros["Nombre"] + ", "
                        + '"' + "UnidadMedida" + '"' + ":" + drRegistros["UnidadMedida"] + ", "
                        + '"' + "Consumo" + '"' + ":" + drRegistros["Consumo"] + ", "
                        + '"' + "Stok" + '"' + ":" + drRegistros["Stok"] + ", "
                        + '"' + "Insumo" + '"' + ":" + drRegistros["Insumo"] + ", "
                        + '"' + "Estatus" + '"' + ":" + drRegistros["Estatus"] + "}, ");

                }
                strDatos.Remove(strDatos.Length - 2, 2);
                drRegistros.Close();
                strDatos.Append("]");
                return strDatos.ToString();
            }
            catch (Exception ex)
            {
                return "Error al realizar la operación: " + ex.Message;
            }
        }
    }
}