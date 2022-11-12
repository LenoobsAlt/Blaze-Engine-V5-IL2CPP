using UnityEngine;
using BE4v.Mods.Core;
using VRCSDK2;
using VRC;

namespace BE4v.Mods.Min
{
    public class PortableObject : IUpdate
    {
        public void Update()
        {
            if (!Threads.isCtrl) return;
            if (Input.GetKeyDown(KeyCode.L))
            {
                Player player = Player.Instance;
                if (player == null) return;
				if (gameObject == null)
					OnCreate();
				else
					OnDestroy();
			}
		}
		public void OnCreate()
		{
			OnDestroy();

			Transform transform = VRC.Player.Instance.transform;
			Vector3 position = transform.position + (transform.forward / .75f);
			position.y += .4f;

			#region Create Object
			gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			gameObject.transform.position = position;
			gameObject.transform.rotation = transform.rotation;
			gameObject.transform.localScale = new Vector3(.025f, .025f, .025f);
			gameObject.GetComponent<Collider>()?.Destroy();
			#endregion
			#region BoxCollider
			BoxCollider boxCollider = gameObject.GetOrAddComponent<BoxCollider>();
			boxCollider.size = new Vector3(1f, 1f, 0.05f);
			boxCollider.isTrigger = true;
			#endregion
			#region VRCPickup
			VRC_Pickup pickup = gameObject.GetOrAddComponent<VRC_Pickup>();
			pickup.proximity = 0.3f;
			pickup.pickupable = true;
			pickup.orientation = VRC.SDKBase.VRC_Pickup.PickupOrientation.Grip;
			pickup.allowManipulationWhenEquipped = false;
			#endregion
			#region Rigidbody
			Rigidbody rigidbody = gameObject.GetOrAddComponent<Rigidbody>();
			rigidbody.useGravity = true;
			rigidbody.isKinematic = true;
			#endregion
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}

		public void OnDestroy()
		{
			UnityEngine.Object.Destroy(gameObject);
			gameObject = null;
		}

		public GameObject gameObject = null;

	}
}
