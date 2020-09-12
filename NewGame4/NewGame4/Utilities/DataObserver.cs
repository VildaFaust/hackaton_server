using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Timers;
using NewGame4.Users;
using Newtonsoft.Json;

namespace NewGame4.Utilities
{
    public class DataObserver : IController
    {
        private readonly ServerContext _context;
        private Timer _aTimer;
        private Dictionary<string, object> _users = new Dictionary<string, object>()
        {
            {"UserId", "user_id"}
        };


        public DataObserver(ServerContext context, UserModel userModel)
        {
            _context = context;
        }

        private void Serialize(ServerContext context)
        {
            var command = new SqlCommand("")
            {
                Connection = context.BdConnection.Connection
            };
            
            // _users.Add("UserId", new SessionUnitModel(){UserId = "user_id"});
            // _users.Add("UserIdOwner", new SessionUnitModel(){UserIdOwner = "user_owner_id"});
            // _users.Add("Status", new SessionUnitModel(){Status = "status"});

            string jsonData = JsonConvert.SerializeObject(_users, Formatting.Indented);

            command.CommandText = $"INSERT INTO sessions(session) VALUES('{jsonData}')";
            command.ExecuteNonQuery();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Serialize(_context);
        }

        public void Activate()
        {
            _aTimer = new Timer(6000);
            _aTimer.Elapsed += OnTimedEvent;
            _aTimer.AutoReset = true;
            _aTimer.Enabled = true;
        }
        
        public void Deactivate()
        {
            _aTimer.Elapsed -= OnTimedEvent;
            _aTimer.Enabled = false;
            _aTimer = null;
        }
    }
}