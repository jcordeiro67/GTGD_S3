using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3 {

	public class GameManager_RestartLevel : MonoBehaviour {

		private GameManager_Master gameManagerMaster;
		private int currentLevel;

		void OnEnable(){
			SetInitialReferences ();
			gameManagerMaster.RestartLevelEvent += RestartLevel;
		}

		void OnDisable(){
			gameManagerMaster.RestartLevelEvent -= RestartLevel;
		}

		void SetInitialReferences() {
			gameManagerMaster = GetComponent <GameManager_Master> ();
			currentLevel = SceneManager.GetActiveScene ().buildIndex;
		}

		void RestartLevel(){
			SceneManager.LoadScene (currentLevel);
		}
	}
}