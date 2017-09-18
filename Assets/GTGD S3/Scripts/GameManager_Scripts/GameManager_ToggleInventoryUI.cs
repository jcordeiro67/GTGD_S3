using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class GameManager_ToggleInventoryUI : MonoBehaviour {
		[Tooltip("Does this game mode have an inventory? Set to true if that is the case")]
		public bool hasInventory;
		public GameObject inventoryUI;
		public string toggleInventoryButton;
		private GameManager_Master gameManagerMaster;

		void Start () {
			SetInitialReferences ();
		}

		void Update () {
			CheckForInventoryRequest ();
		}
		
		void SetInitialReferences() {
			
			gameManagerMaster = GetComponent <GameManager_Master> ();

			if(hasInventory && toggleInventoryButton == ""){
				Debug.LogWarning ("Inventory is turned on but no Input button has been set. " +
					"Please set a button to toggle the inventory UI in the " +
					"GameManager_ToggleInventoryUI scripts inspector");
				
				this.enabled = false;
			}
		}

		void CheckForInventoryRequest(){
			if(Input.GetButtonUp (toggleInventoryButton)&& !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && hasInventory){
				ToggleInventoryUI ();
			}
		}

		public void ToggleInventoryUI(){
			if(inventoryUI != null){
				inventoryUI.SetActive (!inventoryUI.activeSelf);
				gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
				gameManagerMaster.CallEventInventoryUIToggle ();
			}
		}
	}
}