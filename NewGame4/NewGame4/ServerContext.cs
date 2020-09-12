using NewGame4.Commands;
using NewGame4.Decks;
using NewGame4.Sessions;
using NewGame4.Users;
using NewGame4.Utilities;

namespace NewGame4
{
    public class ServerContext
    {
        public CommandModel CommandModel;
        public Factory Factory;
        public BdConnection BdConnection;
        public UserModel UserModel;
        public SessionModel SessionModel;
        public DeckModel DeckModel;
    }
}