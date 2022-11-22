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
    public class ChatsService : IChatsService
    {
        Chats _oChats = new Chats();
        List<Chats> _oChat = new List<Chats>();

        public Chats AddChats(Chats oChats)
        {
            _oChats = new Chats();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oChat = con.Query<Chats>("InsertChats", this.setParameters(oChats),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oChats.Error = ex.Message;

            }
            return _oChats;
        }

       

        public string DeleteChats(int ChatsID)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("Id_Chat", ChatsID);
                        con.Query("DeleteChat", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {

                _oChats.Error = ex.Message;
            }
            return _oChats.Error;
        }

            public Chats GetByChatId(int ChatsID)
            {
                _oChats = new Chats();

                try
                {
                    using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        var param = new DynamicParameters();
                        param.Add("@Id_Chat", ChatsID); var oChats = con.Query<Chats>("SelectChats", param, commandType: CommandType.StoredProcedure);
                        if (oChats != null && oChats.Count() > 0)
                        {
                            _oChats = oChats.SingleOrDefault();
                        }

                    }
                }
                catch (Exception ex)
                {
                    _oChats.Error = ex.Message;
                }
                return _oChats;
            }


        public List<Chats> GetsChats()
        {
            _oChat = new List<Chats>();

            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oChat = con.Query<Chats>("DatosChat", commandType:

                         CommandType.StoredProcedure).ToList();
                    if (oChat != null && oChat.Count() > 0)
                    {
                        _oChat = oChat;
                    }
                }
            }
            catch (Exception ex)
            {
                _oChats.Error = ex.Message;

            }
            return _oChat;
        }

        public Chats UpdateChats(Chats oChats)
        {
            _oChats = new Chats();

            try
            {

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oChat = con.Query<Chats>("Actualizar_Chat", this.updateParameters(oChats),
                         commandType: CommandType.StoredProcedure);
                    }
                }


            }
            catch (Exception ex)
            {

                _oChats.Error = ex.Message;
            }

            return _oChats;
        }


        private DynamicParameters setParameters(Chats oChats)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id_Usuario", oChats.Id_Usuario);
            parameters.Add("@Asunto", oChats.Asunto);
            parameters.Add("@Id_Psicologo", oChats.Id_Psicologo);

            return parameters;
        }

        private DynamicParameters updateParameters(Chats oChats)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id_Chat", oChats.Id_Chat);
            parameters.Add("@Id_Usuario", oChats.Id_Usuario);
            parameters.Add("@Asunto", oChats.Asunto);
            parameters.Add("@Id_Psicologo", oChats.Id_Psicologo);

            return parameters;
        }

    }
}
