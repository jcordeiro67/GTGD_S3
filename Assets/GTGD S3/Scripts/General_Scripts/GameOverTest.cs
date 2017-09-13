using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class GameOverTest : MonoBehaviour {
		
		void Update () {
			if(Input.GetKeyUp (KeyCode.O)){
				GetComponent <GameManager_Master>().CallEventGameOver ();
			}
		}

	}
}