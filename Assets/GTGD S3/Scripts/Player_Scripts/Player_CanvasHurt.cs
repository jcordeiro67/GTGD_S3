using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class Player_CanvasHurt : MonoBehaviour {

		public GameObject hurtCanvas;
		public float secondsTillHide = 1f;

		private Player_Master playerMaster;

		void OnEnable(){
			SetInitialReferences ();
			playerMaster.EventPlayerHealthDeduction += TurnOnHurtEffect;
		}

		void OnDisable(){
			playerMaster.EventPlayerHealthDeduction -= TurnOnHurtEffect;
		}
		
		void SetInitialReferences() {
			playerMaster = GetComponent <Player_Master> ();
		}

		void TurnOnHurtEffect(int dummy){
			if(hurtCanvas != null){
				StopAllCoroutines ();
				hurtCanvas.SetActive (!hurtCanvas.activeSelf);
				StartCoroutine (ResetHurtCanvas ());
			}
		}

		IEnumerator ResetHurtCanvas(){
			yield return new WaitForSeconds (secondsTillHide);
			hurtCanvas.SetActive (!hurtCanvas.activeSelf);
		}
	}
}