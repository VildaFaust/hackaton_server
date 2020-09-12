using System;
using System.Timers;
using NewGame4.Utilities;

namespace NewGame4.Users
{
    public class UserController : IController
    {
        private readonly ServerContext _context;
        private readonly UserModel _model;
        private Timer _aTimer;
        

        public UserController(ServerContext context, UserModel model)
        {
            _context = context;
            _model = model;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _model.Serialize(_context);
        }

        public void Activate()
        {
            _model.Deserialize(_context);
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