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
    public class MunicipioService : IMunicipioService
    {
        Municipio _oMunicipios = new Municipio();
        List<Municipio> _oMunicipio = new List<Municipio>();

        public Municipio AddMunicipio(Municipio oMunicipio)
        {
            _oMunicipios = new Municipio();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oMunicipios = con.Query<Municipio>("InsertMunicipio", this.setParameters(oMunicipio),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMunicipios.Error = ex.Message;

            }
            return _oMunicipios;
        }

        public string DeleteMunicipio(int MunicipioID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("Id_Municipio", MunicipioID);
                        con.Query("DeleteMunicipio", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {

                _oMunicipios.Error = ex.Message;
            }
            return _oMunicipios.Error;
        }
    

        public Municipio GetByMunicipioId(int MunicipioID)
        {
                try
                {
                    using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        var param = new DynamicParameters();
                        param.Add("@Id_Municipio", MunicipioID); var oPsicologos = con.Query<Municipio>("SelectMunicipio", param, commandType:

                          CommandType.StoredProcedure).ToList();

                        if (_oMunicipios != null && _oMunicipio.Count() > 0)
                        {
                            _oMunicipios = _oMunicipio.SingleOrDefault();
                        }
                    }


                }
                catch (Exception ex)
                {
                    _oMunicipios.Error = ex.Message;
                }
                return _oMunicipios;
        }

        public List<Municipio> GetsMunicipio()
        {
            _oMunicipio = new List<Municipio>();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oMunicipio = con.Query<Municipio>("DatosMunicipio", commandType:
                        CommandType.StoredProcedure).ToList();
                    if (oMunicipio != null && oMunicipio.Count() > 0)
                    {
                        _oMunicipio = oMunicipio;

                    }
                }

            }

            catch (Exception ex)
            {
                _oMunicipios.Error = ex.Message;
            }
            return _oMunicipio;
        }

        public Municipio UpdateMunicipio(Municipio oMunicipio)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oMunicipios = con.Query<Municipio>("usp_UpdateMunicipio", this.setParameters(oMunicipio),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMunicipios.Error = ex.Message;
            }
            return _oMunicipios;
        }

        private DynamicParameters setParameters(Municipio oMunicipio)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oMunicipio.Id_Municipio != 0) parameters.Add("@Id_Municipio", oMunicipio.Id_Municipio);

            parameters.Add("@Nombre_Municipio", oMunicipio.Nombre_Municipio);
            parameters.Add("@Departamento", oMunicipio.Departamento);
            parameters.Add("@Id_Usuario", oMunicipio.Id_Usuario);
            return parameters;
        }

    }
}
