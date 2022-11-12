using UnityEngine;
using VRC;
using BE4v.Mods.Core;
using IL2CPP_Core.Objects;
using System;
using VRC.SDKBase;
using IL2ExitGames.Client.Photon;
using IL2Photon.Realtime;
using Player = VRC.Player;

namespace BE4v.Mods.Min
{
    public class MouseTP : IUpdate
    {
      
     
        public void Update()
        {
            if (!Threads.isCtrl) return;
           
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                Player player = Player.Instance;
                if (player == null) return;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    player.transform.position = hit.point;
            }
        }
    }
}
