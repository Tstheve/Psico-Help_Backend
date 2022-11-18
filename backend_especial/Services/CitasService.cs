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
                        var oCita = con.Query<Citas>("usp_InsertUsuario", this.setParameters(oCitas),
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
                        con.Query("usp_DeleteCita", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
                    param.Add("@Id_cita", CitasID); var oCita = con.Query<Citas>("usp_SelectCita", param, commandType:

                      CommandType.StoredProcedure).ToList();

                    if (_oCita != null && _oCitas.Count() > 0);
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
            _oCitas = new List<Citas>();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oCitas = con.Query<Citas>("usp_SelectCitasAll", commandType:
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
                        var oCita = con.Query<Citas>("usp_UpdateCita", this.setParameters(oCitas),
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

            if (oCitas.Id_cita != 0) parameters.Add("@Id_cita", oCitas.Id_cita);

            parameters.Add("@Fecha", oCitas.Fecha);
            parameters.Add("@Hora", oCitas.hora);
            parameters.Add("@Id_Usuario", oCitas.Id_Usuario);
            parameters.Add("@Psicologo", oCitas.Psicologo);
            parameters.Add("@Municipio", oCitas.Municipio);
            return parameters;
        }



    }
}
