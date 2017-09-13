using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class GameManager_PanelInstructions : MonoBehaviour {

		public GameObject instructionPanel;
		private GameManager_Master gameManagerMaster;

		void OnEnable(){
			SetInitialReferences ();
			gameManagerMaster.GameOverEvent += DisablePanelInstructions;
		}

		void OnDisable(){
			gameManagerMaster.GameOverEvent -= DisablePanelInstructions;
		}
		
		void SetInitialReferences() {
			gameManagerMaster = GetComponent <GameManager_Master> ();
		}

		void DisablePanelInstructions(){
			instructionPanel.SetActive (!instructionPanel.activeSelf);

		}
	}
}