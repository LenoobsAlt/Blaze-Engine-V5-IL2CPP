using System;
using System.Net;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.Utils
{
    public static class Sprites
    {

        public static Sprite DownloadSprite(string url, int width, int height)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.DownloadData(url);

                Texture2D texture = new Texture2D(width, height);
                if (texture.LoadImage(bytes))
                    texture.Apply();

                return CreateSprite(texture, new Rect(0.0f, 0.0f, width, height), new Vector2(0.5f, 0.5f), 100.0f, 0, SpriteMeshType.FullRect, false);
            }
        }

        public static void SaveSpriteImg(Sprite sprite, string name)
        {
            Texture2D texture = sprite.texture;
            Texture2D unblockTexture = FileDebug.createReadabeTexture2D(texture);
            unblockTexture.EncodeToPNG_Save(name);
        }

        public static Sprite CreateSprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit = 100, uint extrude = 0, SpriteMeshType meshType = SpriteMeshType.Tight, bool generateFallbackPhysicsShape = false)
        {
            Sprite sprite = Sprite.Create(texture, rect, pivot, pixelsPerUnit, extrude, meshType, generateFallbackPhysicsShape);
            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            return sprite;
        }

        private static Texture2D MakeTex(int width, int height, Color col)
        {
            var pix = new Color[width * height];

            for (int i = 0; i < pix.Length; i++)
            {
                pix[i] = col;
            }

            var result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }


    }
}
