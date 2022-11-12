using UnityEngine;
using VRC;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class Invisible : IUpdate
    {
        public static void Toggle()
        {
            GameObject gameObject = VRCPlayer.Instance.avatarGameObject;
            Transform parent = gameObject.transform.parent;
            if (parent.name != szName)
            {
                gameObject.transform.SetParent(parent.parent);
                gameObject.transform.localPosition = Vector3.zero;
                foreach(Transform transform in parent.parent)
                {
                    if (transform.name == szName_Proxy)
                        UnityEngine.Object.Destroy(parent.gameObject);
                }
                VRCPlayer.Instance.ReloadAvatarNetworkedRPC(Player.Instance);
            }
            else
            {
                GameObject newObject = new GameObject(szName_Proxy);
                newObject.transform.position = gameObject.transform.position;
                newObject.transform.SetParent(parent);
                gameObject.transform.SetParent(newObject.transform);
                iCount = 200;
            }
        }

        public void Update()
        {
            if (!Threads.isCtrl) return;
            if (Input.GetKeyDown(KeyCode.X))
            {
                Toggle();
                return;
            }
            if (iCount < 1) return;
            iCount--;
            GameObject gameObject = VRCPlayer.Instance.avatarGameObject;
            Transform parent = gameObject.transform.parent;
            if (parent.name != szName)
            {
                parent.localPosition = new Vector3(0, -1000, 0);
                gameObject.transform.localPosition = Vector3.zero;
            }
        }

        public static int iCount = 0;

        public static string szName = "ForwardDirection";

        public static string szName_Proxy = "BE4V_Proxy";
    }
}
