/// <summary>
/// Game manager toggle pause.
/// Toggles the time.timescale when the player hit the escape key.
/// Sets bool isPaused in the GameManager_Master.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class GameManager_TogglePause : MonoBehaviour {

		private GameManager_Master gameManagerMaster;
		private bool isPaused;

		void OnEnable(){
			SetInitialReferences ();
			gameManagerMaster.MenuToggleEvent += TogglePause;
			gameManagerMaster.InventoryUIToggleEvent += TogglePause;
		}

		void OnDisable(){
			gameManagerMaster.MenuToggleEvent -= TogglePause;
			gameManagerMaster.InventoryUIToggleEvent -= TogglePause;
		}
		
		void SetInitialReferences() {
			gameManagerMaster = GetComponent <GameManager_Master> ();
		}

		void TogglePause() {
			if(isPaused){
				Time.timeScale = 1;
				isPaused = false;
			}
			else{
				Time.timeScale = 0;
				isPaused = true;
			}
		}
	}
}