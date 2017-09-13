using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class GameManager_References : MonoBehaviour {

		public string playerTag;
		public static string _playerTag;

		public string enemyTag;
		public static string _enemyTag;

		public static GameObject _player;

		void OnEnable(){
			if(playerTag == ""){
				Debug.LogWarning ("Enter the name of the player tag in the GameManager_References " +
					"slot in the inspector or the GTGD S3 systems will not work.");
			}

			if(enemyTag == ""){
				Debug.LogWarning ("Enter the name of the enemy tag in the GameManager_References " +
					"slot in the inspector or the GTGD S3 systems will not work.");
			}

			_playerTag = playerTag;
			_enemyTag = enemyTag;

			_player = GameObject.FindGameObjectWithTag (_playerTag);
		}

		void OnDisable(){
			
		}

		void Start () {
			
		}

		void Update () {
			
		}
		
		void SetInitialReferences() {
			
		}
	}
}