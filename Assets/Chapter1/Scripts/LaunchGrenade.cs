using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1 {

	public class LaunchGrenade : MonoBehaviour {

		public float fireRate = 0.3f;
		public GameObject grenadePrefab;
		public Transform spawnPoint;
		public float propellForce = 30f;

		private float nextFire;
		private Transform m_transform;


		// Use this for initialization
		void Start () {

			SetInitialReferences ();

		}

		// Update is called once per frame
		void Update () {
			if(Input.GetButtonDown ("Fire1") && Time.time > nextFire){
				SpawnGrenade ();
				nextFire = Time.time + fireRate;
			}
		}

		void SpawnGrenade(){
			GameObject grenade;
			grenade = Instantiate (grenadePrefab, spawnPoint.position, m_transform.rotation);
			grenade.GetComponent <Rigidbody>().AddForce (m_transform.forward * propellForce, ForceMode.Impulse);
			Destroy (grenade, 12f);

		}

		void SetInitialReferences(){

			m_transform = transform;

		}
	}
}

