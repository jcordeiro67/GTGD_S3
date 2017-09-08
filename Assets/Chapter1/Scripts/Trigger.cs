/*
 * Trigger.cs
 * 
 * Example of using a trigger and accessing a script
 * on another gameObject.
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1 {
	
	public class Trigger : MonoBehaviour {

		private GameManager_EventMaster eventManagerScript;

		void Start(){
			
			SetInitialReferences ();
		}

		void OnTriggerEnter (Collider col){
			
			eventManagerScript.CallGeneralEvent ();
			Destroy (gameObject); 

		}

		void SetInitialReferences(){
			
			eventManagerScript = GameObject.Find ("GameManagers").GetComponent <GameManager_EventMaster> ();

		}
	}
}

