using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1 {
	
	public class EnemySpawner : MonoBehaviour {

		public int totalEnemies;
		public GameObject enemyPrefab;
		public Transform enemyParent;
		public float spawnRadius = 5f;

		private Vector3 spawnPosition;
		private GameManager_EventMaster eventMasterScript;

		void OnDrawGizmos(){
			
			Gizmos.color = new Color(1, 0f, 0.5f, 0.75F);
			Gizmos.DrawWireSphere(transform.position, spawnRadius);
		}

		void OnEnable(){
			SetInitialReferences ();
			eventMasterScript.m_GeneralEvent += SpawnEnemies;

		}

		void OnDisable(){

			eventMasterScript.m_GeneralEvent -= SpawnEnemies;
		}
			
		void SpawnEnemies(){

			for(int i=0; i<totalEnemies; i++){
				spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
				Vector3 adjustedSpawnPos = new Vector3 (spawnPosition.x, 0f, spawnPosition.z);
				Instantiate (enemyPrefab, adjustedSpawnPos, Quaternion.identity, enemyParent);
			}
		}

		void SetInitialReferences(){

			eventMasterScript = GameObject.Find ("GameManagers").GetComponent <GameManager_EventMaster> ();
		}
	}
}

