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
    public class PsicologoService : IPsicologoService
    {
        Psicologo _oPsicologos = new Psicologo();
        List<Psicologo> _oPsicologo = new List<Psicologo>();

        public Psicologo AddPsicologo(Psicologo oPsicologo)
        {
            _oPsicologos = new Psicologo();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCita = con.Query<Psicologo>("INSERTPsicologo", this.setParameters(oPsicologo),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oPsicologos.Error = ex.Message;

            }
            return _oPsicologos;
        }

        public string DeletePsicologo(int PsicologoID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("Id_Psicologo", PsicologoID);
                        con.Query("DeletePsicologo", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {

                _oPsicologos.Error = ex.Message;
            }
            return _oPsicologos.Error;
        }

        public Psicologo GetByPsicologoId(int PsicologoID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id_Psicologo", PsicologoID); var oPsicologos = con.Query<Psicologo>("SelectPsicologo", param, commandType:

                      CommandType.StoredProcedure).ToList();

                    if (_oPsicologos != null && _oPsicologo.Count() > 0)
                    {
                        _oPsicologos = oPsicologos.SingleOrDefault();
                    }
                }


            }
            catch (Exception ex)
            {
                _oPsicologos.Error = ex.Message;
            }
            return _oPsicologos;
        }

        public List<Psicologo> GetsPsicologo()
        {
            _oPsicologo = new List<Psicologo>();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oPsicologo = con.Query<Psicologo>("DatosPsicologo", commandType:
                        CommandType.StoredProcedure).ToList();
                    if (oPsicologo != null && oPsicologo.Count() > 0)
                    {
                        _oPsicologo = oPsicologo;

                    }
                }

            }

            catch (Exception ex)
            {
                _oPsicologos.Error = ex.Message;
            }
            return _oPsicologo;
        }

        public Psicologo UpdatePsicologo(Psicologo oPsicologo)
        {
            _oPsicologos = new Psicologo();


            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oPsicologos = con.Query<Psicologo>("ActualizarPsicologo", this.updateParameters(oPsicologo),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oPsicologos.Error = ex.Message;
            }
            return _oPsicologos;
        }

        private DynamicParameters setParameters(Psicologo oPsicologos)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id_Psicologo", oPsicologos.Id_Psicologo);

            parameters.Add("@Nombre", oPsicologos.Nombre);
            parameters.Add("@Apellido", oPsicologos.Apellido);
            parameters.Add("@Edad", oPsicologos.Edad);
            parameters.Add("@Especial", oPsicologos.Especialidad);
            parameters.Add("@Años_de_experiencia", oPsicologos.Años_de_experiencia);
            return parameters;
        }


        private DynamicParameters updateParameters(Psicologo oPsicologos)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id_Psicologo", oPsicologos.Id_Psicologo);
            parameters.Add("@Nombre", oPsicologos.Nombre);
            parameters.Add("@Apellido", oPsicologos.Apellido);
            parameters.Add("@Edad", oPsicologos.Edad);
            parameters.Add("@Especial", oPsicologos.Especialidad);
            parameters.Add("@Años_de_experiencia", oPsicologos.Años_de_experiencia);
            return parameters;
        }


    }
}
