using backend_especial.Models;
using System.Collections.Generic;


namespace backend_especial.Iservice
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
