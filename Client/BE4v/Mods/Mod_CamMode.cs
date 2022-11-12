using System;
using UnityEngine;

namespace BE4v.Mods
{
    public static class Mod_CamMode
    {
        public static void Toggle_Enable()
        {
            if (_isEnable)
            {
                OnDestroy();
                return;
            }
            OnDestroy(true);
            CamOnHead = Camera.main;
            
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.GetComponent<Collider>()?.Destroy();
            gameObject.GetComponent<Renderer>()?.Destroy();
            gameObject.AddComponent<Camera>();

            Transform transform = CamOnHead.transform;
            Transform transform1 = gameObject.transform;
            transform1.localScale = transform.localScale;
            transform1.rotation = transform.rotation;
            transform1.position = transform.position;
            transform1.parent = transform;

            Cam3thPerson = gameObject;
            _isEnable = true;
        }

        public static void OnDestroy(bool updateStatus = true)
        {
            Cam3thPerson?.gameObject?.Destroy();
            if (updateStatus)
            {
                Cam3thPerson = null;
                _isEnable = false;
                // UpdateStatus();
            }
            if (CamOnHead != null)
                CamOnHead.enabled = true;
        }

        public static void Update()
        {
            CamOnHead.enabled = false;
        }

        public static void LateUpdate()
        {
            Cam3thPerson.transform.localPosition = (Vector3.up / 4) + (Vector3.back * 3);
        }

        private static GameObject Cam3thPerson = null;
        
        private static Camera CamOnHead = null;

        public static bool _isEnable = false;
    }
}