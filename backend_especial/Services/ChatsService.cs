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
    public class ChasService : IChatsService
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
                        param.Add("@Id_Chat", ChatsID); var oChats = con.Query<Chats>("SelectChats", param, commandType:

                                CommandType.StoredProcedure);
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
                    if (oChat != null && oChat .Count() > 0)
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
                        var oChat = con.Query<Chats>("Actualizar_Chat", this.setParameters(oChats),
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




        private object setParameters(Chats oChats)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (oChats.Id_Chat != 0) parameters.Add("@Id_Chats", oChats.Id_Chat);

            parameters.Add("@Id_Usuario", oChats.Id_Usuario);
            parameters.Add("@Asunto", oChats.Asunto);
            parameters.Add("@Id_Psicologo", oChats.Id_Psicologo);

            return parameters;
        }


    }


}


