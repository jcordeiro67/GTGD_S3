using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework.Interfaces;

namespace S3 {

	public class Player_Health : MonoBehaviour {

		public int playerHealth = 100;
		public Text healthText;
		[SerializeField] private int currentHealth;
		private GameManager_Master gameManagerMaster;
		private Player_Master playerMaster;

		void OnEnable(){
			SetInitialReferences ();
			SetUI ();
			playerMaster.EventPlayerHealthDeduction += DeductHealth;
			playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
		}

		void OnDisable(){
			playerMaster.EventPlayerHealthDeduction -= DeductHealth;
			playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
		}

		void Update () {
			if(Input.GetKeyUp (KeyCode.O)){
				playerMaster.CallEventPlayerHealthDeduction (10);
			}
		}
		
		void SetInitialReferences() {
			gameManagerMaster = GameObject.FindObjectOfType <GameManager> ().GetComponent <GameManager_Master> ();
			playerMaster = GetComponent <Player_Master> ();

			currentHealth = playerHealth;
		}

//		IEnumerator TestHealthDeduction(){
//			yield return new WaitForSeconds (4f);
//			DeductHealth (100);
//		}

		void DeductHealth(int healthChange){
			currentHealth -= healthChange;
			if(currentHealth <= 0){
				currentHealth = 0;
				gameManagerMaster.CallEventGameOver ();
			}

			SetUI ();
		}

		void IncreaseHealth(int healthChange){
			currentHealth += healthChange;
			if(currentHealth >= playerHealth){
				currentHealth = playerHealth;
			}
			SetUI ();
		}

		void SetUI(){

			if(healthText != null){
				healthText.text = currentHealth.ToString () + "%";
			}
		}
	}
}