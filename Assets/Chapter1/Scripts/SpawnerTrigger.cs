using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1 {

	public class SpawnerTrigger : MonoBehaviour {

		private GameManager_EventMaster eventMasterScript;

		void OnDrawGizmos(){

			Gizmos.color = new Color(1, 0f, 0.5f, 0.75F);
			Gizmos.DrawWireCube (transform.TransformPoint (0f, 1f, 0f), new Vector3(2f,2f,2f));
		}
		void OnTriggerEnter(Collider col){
			
			SetInitialReferences ();
			if(col.gameObject.CompareTag ("Player")){
				eventMasterScript.CallGeneralEvent ();
				this.gameObject.SetActive (false);
			}
		}

		void SetInitialReferences(){

			eventMasterScript = GameObject.Find ("GameManagers").GetComponent <GameManager_EventMaster> ();
		}
	}
}

