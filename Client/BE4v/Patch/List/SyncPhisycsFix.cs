using System;
using IL2CPP_Core.Objects;
using UnityEngine;
using BE4v.Patch.Core;
using VRC.Networking.Tween;

namespace BE4v.Patch.List
{
    // Thx: BlaBlaName#3854
    // Source: https://github.com/Mopo3eX/EasyFix/
    public class SyncPhisycsFix // : IPatch
    {
        public delegate void _ApplyEvent(IntPtr instance, IntPtr target, float _float, bool _bool);

        public void Start()
        {
            IL2Method method = SyncPhysics.Instance_Class.GetMethod("ApplyEvent");
            if (method == null)
                throw new NullReferenceException();

            __ApplyEvent = PatchUtils.FastPatch<_ApplyEvent>(method, ApplyEvent);
        }

        public static void ApplyEvent(IntPtr instance, IntPtr target, float _float, bool _bool)
        {
            if (instance == IntPtr.Zero || target == IntPtr.Zero)
                return;

            SyncPhysics sync = new SyncPhysics(instance);
            PositionEvent positionEvent = new PositionEvent(target);

            if (Vector3.Distance(Vector3.zero, positionEvent.Position) > 1000 || Vector3.Distance(Vector3.zero, positionEvent.Velocity) > 150)
            {
                foreach (var col in sync.gameObject.GetComponents<Collider>())
                {
                    col.enabled = false;
                }
                foreach (var body in sync.gameObject.GetComponents<Rigidbody>())
                {
                    body.isKinematic = false;
                }
                return;
            }

            __ApplyEvent(instance, target, _float, _bool);
        }

        public static _ApplyEvent __ApplyEvent;

    }
}
