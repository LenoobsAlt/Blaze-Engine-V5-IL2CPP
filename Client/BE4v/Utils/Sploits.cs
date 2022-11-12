using System;
using System.Collections.Generic;
using UnityEngine;
using VRC.Core;
using VRC.UI;

namespace BE4v.Utils
{
    public static class Sploits
    {
        public static void ForceVoteKick(APIUser user)
        {
            PageUserInfo userInfo = new PageUserInfo()
            {
                user = user
            };
            for (int i = 0; i <= 20; i++)
                userInfo.InitiateVoteToKick();
        }
    }
}
