using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class GameManager_GameOver : MonoBehaviour {

		public GameObject gameOverPanel;
		private GameManager_Master gameManagerMaster;

		void OnEnable(){
			SetInitialReferences ();
			gameManagerMaster.GameOverEvent += TurnOnGameOverPanel;
		}

		void OnDisable(){
			gameManagerMaster.GameOverEvent -= TurnOnGameOverPanel;
		}

		void SetInitialReferences() {
			gameManagerMaster = GetComponent <GameManager_Master> ();
		}

		void TurnOnGameOverPanel(){
			if(gameOverPanel != null){
				gameOverPanel.SetActive (!gameOverPanel.activeSelf);
			}
		}
	}
}