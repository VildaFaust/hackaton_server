using System.Collections.Generic;

namespace NewGame4.Sessions
{
    public class SessionModel
    {
        private Dictionary<string, ISessionUnitModel> _users = new Dictionary<string, ISessionUnitModel>();
        public Dictionary<string, string> sessions = new Dictionary<string, string>();

        public void Serialize(ServerContext context)
        {
        }

        public void Deserialize(ServerContext context)
        {
        }

        public ISessionUnitModel Get(string id)
        {
            return _users[id];
        }

        public bool Contains(string id)
        {
            return _users.ContainsKey(id);
        }

        public void Add(ISessionUnitModel user)
        {
            _users.Add(user.Id, user);
            foreach (var key in user.Keys)
            {
                sessions.Add(key, user.Id);
            }
        }
    }
}