using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BE4v.MenuEdit.Construct
{
    public static class LoadSprites
    {
        public static void DownloadAll()
        {
            var props = typeof(LoadSprites).GetProperties();
            foreach(var prop in props)
            {
                if (prop != null)
                {
                    prop.GetGetMethod().Invoke(null, null);
                    $"Load sprite: {prop.Name}".GreenPrefix("ISprite");
                }
            }
        }

        private static Sprite be4vLogoSprite = null;
        public static Sprite be4vLogo
        {
            get
            {
                if (be4vLogoSprite == null)
                {
                    be4vLogoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/logo.png", 64, 64);
                }
                return be4vLogoSprite;
            }
        }

        private static Sprite onButtonSprite = null;
        public static Sprite onButton
        {
            get
            {
                if (onButtonSprite == null)
                {
                    onButtonSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/on.png", 64, 64);
                }
                return onButtonSprite;
            }
        }

        private static Sprite offButtonSprite = null;
        public static Sprite offButton
        {
            get
            {
                if (offButtonSprite == null)
                {
                    offButtonSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/off.png", 64, 64);
                }
                return offButtonSprite;
            }
        }

        private static Sprite trashIcoSprite = null;
        public static Sprite trashIco
        {
            get
            {
                if (trashIcoSprite == null)
                {
                    trashIcoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/trash.png", 64, 64);
                }
                return trashIcoSprite;
            }
        }

        private static Sprite notifyIcoSprite = null;
        public static Sprite notifyIco
        {
            get
            {
                if (notifyIcoSprite == null)
                {
                    notifyIcoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/notify.png", 64, 64);
                }
                return notifyIcoSprite;
            }
        }

        private static Sprite sitonIcoSprite = null;
        public static Sprite sitonIco
        {
            get
            {
                if (sitonIcoSprite == null)
                {
                    sitonIcoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/siton.png", 64, 64);
                }
                return sitonIcoSprite;
            }
        }

        private static Sprite gamingIcoSprite = null;
        public static Sprite gamingIco
        {
            get
            {
                if (gamingIcoSprite == null)
                {
                    gamingIcoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/gaming-logo.png", 64, 64);
                }
                return gamingIcoSprite;
            }
        }

        private static Sprite flyTypeIcoSprite = null;
        public static Sprite flyTypeIco
        {
            get
            {
                if (flyTypeIcoSprite == null)
                {
                    flyTypeIcoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/fly-type.png", 64, 64);
                }
                return flyTypeIcoSprite;
            }
        }

        private static Sprite pickupOrbitIcoSprite = null;
        public static Sprite pickupOrbitIco
        {
            get
            {
                if (pickupOrbitIcoSprite == null)
                {
                    pickupOrbitIcoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/pickup-orbit.png", 64, 64);
                }
                return pickupOrbitIcoSprite;
            }
        }
    }
}
