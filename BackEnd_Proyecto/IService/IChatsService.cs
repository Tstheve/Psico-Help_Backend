using BackEnd_Proyecto.Models;
using System.Collections.Generic;

namespace BackEnd_Proyecto.IService
{
    public interface IChatsService
    {
        Chats AddChats(Chats oChats);
        List<Chats> GetsChats();
        Chats GetByChatId(int ChatsID);
        string DeleteChats(int ChatsID);
        Chats UpdateChats(Chats oChats);
    }
}
