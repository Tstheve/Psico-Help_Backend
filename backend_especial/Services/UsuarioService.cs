using Dapper;
using backend_especial.Models;
using backend_especial.Iservice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using backend_especial.Conexion;
using backend_especial.Controller;

namespace backend_especial.Services
{
    public class UsuarioService : IUsuarioService
    {
        Usuario _oUsuario = new Usuario();
        List<Usuario> _oUsuarios = new List<Usuario>();

        public Usuario AddUsuario(Usuario oUsuario)
        {
            _oUsuario = new Usuario();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oUsuarios = con.Query<Usuario>("InsertUsuario", this.setParameters(oUsuario),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;

            }
            return _oUsuario;
        }

        public string DeleteUsuario(int UsuarioID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("Id_Usuario", UsuarioID);
                        con.Query("DeleteUsuario", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {

                _oUsuario.Error = ex.Message;
            }
            return _oUsuario.Error;
        }

        public Usuario GetByUsuarioId(int UsuarioID)
        {
            _oUsuario = new Usuario();

            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id_Usuario", UsuarioID); var oUsuario = con.Query<Usuario>("SelectUsuario", param, commandType:

                      CommandType.StoredProcedure).ToList();

                    if (oUsuario != null && oUsuario.Count() > 0) ;
                    {
                        _oUsuario = oUsuario.SingleOrDefault();
                    }
                }


            }
            catch(Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        public List<Usuario> GetsUsuario()
        {
            _oUsuarios = new List<Usuario>();

            try
            {

               using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oUsuario = con.Query<Usuario>("DatosUsuario", commandType:
                        CommandType.StoredProcedure).ToList();
                    if (oUsuario != null && oUsuario.Count() > 0)
                    {
                        _oUsuarios = oUsuario;

                    }
                }


            }

            catch(Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuarios;


        }

        public Usuario UpdateUsuario(Usuario oUsuario)
        {
            _oUsuario = new Usuario();


            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oUsuarios = con.Query<Usuario>("ActualizarUsuario", this.setParameters(oUsuario),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch(Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        private DynamicParameters setParameters(Usuario oUsuario)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oUsuario.Id_Usuario != 0) parameters.Add("@Id_Usuario", oUsuario.Id_Usuario);

            parameters.Add("@Correo", oUsuario.Correo);
            parameters.Add("@Clave", oUsuario.Clave);
            parameters.Add("@Nombre", oUsuario.Nombre);
            parameters.Add("@Apellido", oUsuario.Apellido);
            parameters.Add("@Edad", oUsuario.Edad);
            parameters.Add("@Telefono", oUsuario.Telefono);
            parameters.Add("@Pseudonimo", oUsuario.Pseudonimo);
            return parameters;
        }
    }
}






