using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transmtn.DTO.Notifications;

namespace BE4v.Utils
{
    public static class Notification
    {
        public static void SendInvite(VRC.Player Player, string worldId)
        {
            if (Player == null)
                return;

            NotificationDetails notificationDetails = new NotificationDetails();
            notificationDetails[new IL2String_utf8("worldId")] = new IL2String_utf16(worldId);
            NotificationManager.Instance.SendNotification(Player.user.id, "requestInvite", string.Empty, notificationDetails);
        }
    }
}
