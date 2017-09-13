/// <summary>
/// Game manager toggle menu.
/// Toggles the main menu on and off when the player hit escape.
/// Add the main menu canvas to the inspector for this script.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel.Design;

namespace S3 {

	public class GameManager_ToggleMenu : MonoBehaviour {

		private GameManager_Master gameManagerMaster;
		public GameObject menu;

		void OnEnable(){
			SetInitialReferences ();
			gameManagerMaster.GameOverEvent += ToggleMenu;
		}

		void OnDisable(){
			gameManagerMaster.GameOverEvent -= ToggleMenu;
		}

		void Start () {
			ToggleMenu ();
		}

		void Update () {
			CheckForMenuToggleRequest ();
		}
		
		void SetInitialReferences() {
			gameManagerMaster = GetComponent <GameManager_Master> ();
		}

		void CheckForMenuToggleRequest(){
			if(Input.GetKeyUp (KeyCode.Escape) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn){
				ToggleMenu ();
			}
		}

		void ToggleMenu(){
			if(menu != null){
				menu.SetActive (!menu.activeSelf);
				gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
				gameManagerMaster.CallEventMenuToggle ();
			}
			else{
				Debug.LogWarning ("GameManager_ToggleMenu: No reference to menu in the inspector");
			}
		}
	}
}