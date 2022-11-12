using System;
using UnityEngine;
using VRC;
using VRC.Core;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class AdvancedEffects //: IUpdate
    {
        public void Update()
        {
            if (Status.isJumpEffects)
            {
                if (lastRadius != 0f)
                {
                    lastRadius += Time.deltaTime;
                    CreateCylinderEffect(Vector3.zero, lastRadius);
                }
            }
        }


        public static float lastRadius = 0f;

        public static void CreateCylinderEffect(Vector3 position, float radius)
        {
            if (radius == 0 || Threads.be4v_gui == null) return;
            lastRadius = radius;
            LineRenderer lineRenderer = null;
            if (radius > 5f)
            {
                if (position != Vector3.zero)
                {
                    Threads.be4v_gui.transform.position = position;
                    lineRenderer = Threads.be4v_gui.GetOrAddComponent<LineRenderer>();

                    lineRenderer.startWidth = 0.1f;
                    lineRenderer.endWidth = 0.1f;
                    lineRenderer.useWorldSpace = true;
                }
                else
                {
                    position = Threads.be4v_gui.transform.position;
                }
            }
            if (lineRenderer != null)
            {
                if (radius > 50f)
                {
                    Threads.be4v_gui.transform.position = Vector3.zero;
                    lineRenderer.SetPositions(new Vector3[0]);
                    lastRadius = 0;
                    return;
                }
                int count = 12;
                float degrees = 360 / count;

                Vector3[] vectors = new Vector3[count + 1];
                for (int i = 0; i < count; i++)
                {
                    vectors[i] = position + new Vector3(
                        Mathf.Sin(degrees * i) * radius,
                        0.25f,
                        Mathf.Cos(degrees * i) * radius
                    );
                    if (i == 0)
                    {
                        vectors[count] = position + new Vector3(
                            Mathf.Sin(degrees * i) * radius,
                            0.25f,
                            Mathf.Cos(degrees * i) * radius
                        );
                    }
                }
                lineRenderer.SetPositions(vectors);
            }

        }
    }
}
