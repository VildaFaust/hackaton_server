using System.Collections.Generic;

namespace NewGame4.Sessions
{
    public class SessionUnitModel : ISessionUnitModel
    {
        public string Id { get; set; }
        public string[] Keys { get; set; }
        public string UserIdOwner { get; set;}
        public string Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSecondName { get; set; }
        public string UserCards { get; set; }
        public string UserLastStep { get; set; }
        public string UserCoins { get; set; }
        public string UserJokers { get; set; }
        public string GiftOfTheUniverse { get; set; }
        public string GearColor { get; set; }
        
        public Dictionary<string, CameraData> Cameras { get; }

        public SessionUnitModel()
        {
            Cameras = new Dictionary<string, CameraData>();
        }
    }
    
    public class CameraData
    {
        public byte[] Camera;
        public int X;
        public int Y;
        public bool IsActive;
    }
}