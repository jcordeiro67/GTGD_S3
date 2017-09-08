using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Chapter1 {

	[RequireComponent (typeof(Rigidbody))]

	public class GrenadeExplosion : MonoBehaviour {

		[Range(0f, 20f)]public float blastRadius = 6f;
		[Range(0f, 800f)] public float explosionPower = 10f;
		public LayerMask explosionLayers;
		public float enemyDisplayTime = 7f;
		[Range(0f,1f)] public float upwardForce = 1f;
		private Collider[] hitColliders;

		void OnCollisionEnter(Collision col){

			ExplosionWork (col.contacts[0].point);
			Destroy (gameObject);
		}

		void ExplosionWork(Vector3 explosionPoint){
			hitColliders = Physics.OverlapSphere (explosionPoint, blastRadius, explosionLayers);

			foreach(Collider hitCol in hitColliders){
				// Turn off navMeshAgent
				NavMeshAgent hitNavAgent = hitCol.GetComponent <NavMeshAgent> ();
				if(hitNavAgent != null){
					hitNavAgent.enabled = false;
				}
				// Set Rigidbody to noKinematic
				Rigidbody hitRB = hitCol.GetComponent <Rigidbody> ();
				if(hitRB != null){
					hitRB.isKinematic = false;
					hitRB.AddExplosionForce (explosionPower, explosionPoint, blastRadius, 1f, ForceMode.Impulse);
				}

				if(hitCol.CompareTag ("Enemy")){
					Destroy (hitCol.gameObject, enemyDisplayTime);
				}
			}
		}
	}
}

