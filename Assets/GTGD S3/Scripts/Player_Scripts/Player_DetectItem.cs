using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class Player_DetectItem : MonoBehaviour {

		[Tooltip("What layer is being used for items.")]
		public LayerMask layerToDetect;
		[Tooltip("What transform will the ray be fired.")]
		public Transform rayTransformPivot;
		[Tooltip("The editor input button that will be used for picking up items.")]
		public string buttonPickup;
		public GUISkin guiSkin;

		private Transform itemAvailiableForPickup;
		private RaycastHit hit;
		private float detectRange = 3f;
		private float detectRadius = 0.7f;
		private bool itemInRange;

		private float labelWidth = 200;
		private float labelHeight = 100;


		void Update () {
			CastRayForDetectingItems ();
			CheckForItemPickupAttempt ();
		}

		void CastRayForDetectingItems(){
			if(Physics.SphereCast (rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect)){
				itemAvailiableForPickup = hit.transform;
				itemInRange = true;
			}
			else{
				itemInRange = false;
			}
		}

		void CheckForItemPickupAttempt(){
			if(Input.GetButtonDown (buttonPickup) && Time.timeScale > 0 && itemInRange 
				&& itemAvailiableForPickup.root.tag != GameManager_References._playerTag){
				Debug.Log ("Pickup Attempted");
				//itemAvailiableForPickup.GetComponent <Item_Master>().CallEventPickupAction(rayTransformPivot);
			}
		}

		void OnGUI(){
			if(guiSkin != null){
				GUI.skin = guiSkin;
			}
			if(itemInRange && itemAvailiableForPickup != null){
				GUI.Label (new Rect(Screen.width /2 -labelWidth /2, Screen.height /2, labelWidth, labelHeight), 
					itemAvailiableForPickup.name + " Press E to pickup item");
			}
		}

	}
}