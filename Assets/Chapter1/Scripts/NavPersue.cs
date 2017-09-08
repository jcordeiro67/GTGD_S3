using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

namespace Chapter1 {

	public class NavPersue : MonoBehaviour {

		public LayerMask detectionLayer;
		public float detectionRadius = 20f;

		private Transform m_transform;
		private NavMeshAgent navAgent;
		private Collider[] hitColliders;
		private float checkRate;
		private float nextCheck;

		void OnDrawGizmosSelected(){
			
			Gizmos.color = new Color(1, 1, 0, 0.75F);
			Gizmos.DrawWireSphere(transform.position, detectionRadius);

		}

		// Use this for initialization
		void Start () {
			
			SetInitialReferences ();
		}

		// Update is called once per frame
		void Update () {
			CheckIfPlayerInRange ();
		}

		void SetInitialReferences(){

			m_transform = transform;
			navAgent = GetComponent <NavMeshAgent> ();
			checkRate = Random.Range (0.8f, 1.2f);
		}

		void CheckIfPlayerInRange(){
			// Setup interval for AI to look for player, uses a 
			// Random.Range for checkRate
			if(Time.time > nextCheck && navAgent.enabled == true){
				nextCheck = Time.time + checkRate;

				hitColliders = Physics.OverlapSphere (m_transform.position, detectionRadius, detectionLayer);

				if(hitColliders.Length > 0){
					// AI has found the player move to player
					navAgent.SetDestination (hitColliders[0].transform.position);
				}
			}
		}
	}
}

