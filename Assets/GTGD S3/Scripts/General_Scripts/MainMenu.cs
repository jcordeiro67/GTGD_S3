using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3 {

	public class MainMenu : MonoBehaviour {

		private int activeScene;
		private int nextScene;

		void Start(){
			SetInitialReferences ();

		}

		public void PlayGame(){
			nextScene = activeScene + 1;
			SceneManager.LoadScene (nextScene);
		}

		public void ExitGame(){
			Application.Quit ();
		}
		
		void SetInitialReferences() {
			activeScene = SceneManager.GetActiveScene ().buildIndex;
		}
	}
}