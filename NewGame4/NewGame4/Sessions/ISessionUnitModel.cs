using System.Collections.Generic;

namespace NewGame4.Sessions
{
    public interface ISessionUnitModel
    {
         string Id { get; set; }
         string[] Keys { get; set; }
         string UserIdOwner { get; set;}
         string Status { get; set; }
         string UserId { get; set; }
         string UserName { get; set; }
         string UserSecondName { get; set; }
         string UserCards { get; set; }
         string UserLastStep { get; set; }
         string UserCoins { get; set; }
         string UserJokers { get; set; }
         string GiftOfTheUniverse { get; set; }
         string GearColor { get; set; }
         Dictionary<string, CameraData> Cameras { get; }
    }
}