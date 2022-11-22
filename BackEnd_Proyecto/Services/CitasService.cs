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

namespace BackEnd_Proyecto.Service
{
    public class CitasService : ICitasService
    {
        Citas _oCita = new Citas();
        List<Citas> _oCitas = new List<Citas>();

        public Citas AddCitas(Citas oCitas)
        {
            _oCita = new Citas();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCita = con.Query<Citas>("InsertCita", this.setParameters(oCitas),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;

            }
            return _oCita;
        }

        public string DeleteCitas(int CitasID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("Id_cita", CitasID);
                        con.Query("DeleteCita", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {

                _oCita.Error = ex.Message;
            }
            return _oCita.Error;
        }

        public Citas GetByCitasId(int CitasID)
        {
            _oCita = new Citas();

            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id_cita", CitasID); var oCita = con.Query<Citas>("SelectCita", param, commandType:

                      CommandType.StoredProcedure).ToList();

                    if (_oCita != null && _oCitas.Count() > 0)
                    {
                        _oCita = oCita.SingleOrDefault();
                    }
                }


            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCita;
        }

        public List<Citas> GetsCitas()
        {
            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oCitas = con.Query<Citas>("DatosCita", commandType:
                        CommandType.StoredProcedure).ToList();
                    if (oCitas != null && oCitas.Count() > 0)
                    {
                        _oCitas = oCitas;

                    }
                }

            }

            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCitas;
        }

        public Citas UpdateCitas(Citas oCitas)
        {
            _oCita = new Citas();


            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCita = con.Query<Citas>("ActualizarCita", this.updateParameters(oCitas),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCita;
        }
        private DynamicParameters setParameters(Citas oCitas)
        {
            DynamicParameters parameters = new DynamicParameters();


            parameters.Add("@Fecha", oCitas.Fecha);
            parameters.Add("@Id_Usuario", oCitas.Id_Usuario);
            parameters.Add("@Id_Psicologo", oCitas.Id_Psicologo);
            parameters.Add("@Id_Municipio", oCitas.Id_Municipio);
            return parameters;
        }


        private DynamicParameters updateParameters(Citas oCitas)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id_cita", oCitas.Id_Cita);
            parameters.Add("@Id_cita", oCitas.Id_Cita);
            parameters.Add("@Fecha", oCitas.Fecha);
            parameters.Add("@Id_Usuario", oCitas.Id_Usuario);
            parameters.Add("@Id_Psicologo", oCitas.Id_Psicologo);
            parameters.Add("@Id_Municipio", oCitas.Id_Municipio);
            return parameters;
        }



    }
}
