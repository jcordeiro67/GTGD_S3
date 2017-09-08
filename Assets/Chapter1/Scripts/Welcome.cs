using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

namespace Chapter1 {
	
	public class Welcome : MonoBehaviour {
		
		[Tooltip("Welcome message displayed when game starts")]
		public string welcomeText = "Welcome To GTGD S3";
		[Tooltip("The canvas to be hiden after the displayTime")]
		public GameObject welcomeCanvas;
		[Tooltip("Amount of time the welcome message is displayed")]
		[Range (0,6)] public int displayTime = 3;

		private Text UIWelcomeText;

		void Awake() {
			if(welcomeCanvas.activeSelf == false){
				welcomeCanvas.SetActive (true);
			}
		}

		// Use this for initialization
		void Start () {
			
			SetInitialReferences ();

			WelcomeMessage ();
			StartCoroutine (HideUIWelcomeCanvas ());
		}

		void WelcomeMessage(){
			if (UIWelcomeText != null){
				UIWelcomeText.text = welcomeText;
			}
			else{
				Debug.Log ("UIWelcomeText Not Assigned");
			}

		}

		void SetInitialReferences(){
			UIWelcomeText = GameObject.Find ("UIWelcomeText").GetComponent <Text> ();
		}

		IEnumerator HideUIWelcomeCanvas(){
			yield return new WaitForSeconds (displayTime);
			welcomeCanvas.SetActive (false);
		}
	}
}

