using System;
using System.Timers;
using NewGame4.Utilities;

namespace NewGame4.Sessions
{
    public class SessionController : IController
    {
        private readonly ServerContext _context;
        private readonly SessionModel _model;
        private Timer _aTimer;
        

        public SessionController(ServerContext context, SessionModel model)
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