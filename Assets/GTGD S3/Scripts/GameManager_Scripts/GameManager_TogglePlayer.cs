/// <summary>
/// Game manager toggle player.
/// Toggles the players firstperson controller when the
/// menu or inventory are activated.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace S3 {

	public class GameManager_TogglePlayer : MonoBehaviour {

		private FirstPersonController playerController;
		private GameManager_Master gameManagerMaster;

		void OnEnable(){
			SetInitialReferences ();
			gameManagerMaster.MenuToggleEvent += TogglePlayerController;
			gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
		}

		void OnDisable(){
			gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
			gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
		}
		
		void SetInitialReferences() {
			playerController = GameObject.FindObjectOfType<FirstPersonController> ().GetComponent <FirstPersonController> ();
			gameManagerMaster = GetComponent <GameManager_Master> ();
		}

		void TogglePlayerController(){
			if(playerController != null){
				playerController.enabled = !playerController.enabled;
			}
		}
	}
}