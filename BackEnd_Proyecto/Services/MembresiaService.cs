using Dapper;
using BackEnd_Proyecto.Models;
using BackEnd_Proyecto.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_Proyecto.Conexion;
using BackEnd_Proyecto.Controllers;

namespace BackEnd_Proyecto.Services
{
    public class MembresiaService : IMembresiaService
    {

        Membresia _oMembresias = new Membresia();
        List<Membresia> _oMembresia = new List<Membresia>();

        public Membresia AddMembresia(Membresia oMembresia)
        {
            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCita = con.Query<Citas>("InserMembresia", this.setParameters(oMembresia),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMembresias.Error = ex.Message;

            }
            return _oMembresias;
        }

        public string DeleteMembresia(int MembresiaID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("Id_Membresia", MembresiaID);
                        con.Query("DeleteMembresia", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {

                _oMembresias.Error = ex.Message;
            }
            return _oMembresias.Error;
        }

        public Membresia GetByMembresiaId(int MembresiaID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id_Membresia", MembresiaID); var oMembresias = con.Query<Membresia>("SelectMembresia", param, commandType:

                      CommandType.StoredProcedure).ToList();

                    if (_oMembresias != null && _oMembresia.Count() > 0)
                    {
                        _oMembresias = oMembresias.SingleOrDefault();
                    }
                }


            }
            catch (Exception ex)
            {
                _oMembresias.Error = ex.Message;
            }
            return _oMembresias;
        }

        public List<Membresia> GetsMembresia()
        {
            _oMembresia = new List<Membresia>();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oMembresia = con.Query<Membresia>("DatosMembresia", commandType:
                        CommandType.StoredProcedure).ToList();
                    if (oMembresia != null && oMembresia.Count() > 0)
                    {
                        _oMembresia = oMembresia;

                    }
                }

            }

            catch (Exception ex)
            {
                _oMembresias.Error = ex.Message;
            }
            return _oMembresia;
        }

        public Membresia UpdateMembresia(Membresia oMembresia)
        {
            _oMembresias = new Membresia();


            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oMembresias = con.Query<Membresia>("ActualizarMembresia", this.updateParameters(oMembresia),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMembresias.Error = ex.Message;
            }
            return _oMembresias;
        }

        private DynamicParameters setParameters(Membresia oMembresias)
        {
            DynamicParameters parameters = new DynamicParameters();


            parameters.Add("@Descripcion", oMembresias.Descripcion);
            parameters.Add("@Precio", oMembresias.Precio);
            parameters.Add("@Id_Usuario", oMembresias.Id_Membresia);
            return parameters;
        }

        private DynamicParameters updateParameters(Membresia oMembresias)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id_Membresia", oMembresias.Id_Membresia);
            parameters.Add("@Descripcion", oMembresias.Descripcion);
            parameters.Add("@Precio", oMembresias.Precio);
            parameters.Add("@Id_Usuario", oMembresias.Id_Membresia);
            return parameters;
        }

    }
}
