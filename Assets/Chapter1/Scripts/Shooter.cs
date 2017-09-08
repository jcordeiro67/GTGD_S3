using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1 {

	public class Shooter : MonoBehaviour {

		public float fireRate = 0.3f;
		private float nextFire;
		private RaycastHit hit;
		private float range = 200f;
		private Transform m_transform;

		// Use this for initialization
		void Start () {
			SetInitialReferences ();
		}

		// Update is called once per frame
		void Update () {
			CheckForInput ();
		}

		void SetInitialReferences(){
			m_transform = transform;
		}

		void CheckForInput(){
			
			// GetKeyDown accepts a KeyCode
//			if(Input.GetKeyDown (KeyCode.Mouse0) && Time.time > nextFire){
//				nextFire = Time.time + fireRate;
//				Debug.Log ("Key Pressed");
//			}

			// GetButton uses the Input axis name assigned to that button
			if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
				//Debug.DrawRay (m_transform.TransformPoint (0,0,1f), m_transform.forward, Color.yellow, 3f);
				if(Physics.Raycast (m_transform.TransformPoint (0,0,1f), m_transform.forward, out hit, range)){
					if(hit.transform.CompareTag ("Enemy")){
						Debug.Log ("Enemy " + hit.transform.name);
					}
				}
				nextFire = Time.time + fireRate;

			}
		}
	}
}

