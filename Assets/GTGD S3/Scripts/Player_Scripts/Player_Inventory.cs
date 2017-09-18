using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace S3 {

	public class Player_Inventory : MonoBehaviour {

		public Transform inventoryPlayerParent;
		public Transform inventoryUIParent;
		public GameObject uiButton;
		public string itemTag;

		private Player_Master playerMaster;
		private GameManager_ToggleInventoryUI inventoryUIScript;
		private float timeToPlaceInHands = 0.1f;
		private Transform currentlyHeldItem;
		private int counter;
		private string buttonText;
		private List<Transform> listInventory = new List<Transform>();

		void OnEnable()
		{
			SetInitialReferences();
			DeactivateAllInventoryItems();
			UpdateInventoryListAndUI();
			CheckIfHandsEmpty();

			playerMaster.EventInventoryChanged += UpdateInventoryListAndUI;
			playerMaster.EventInventoryChanged += CheckIfHandsEmpty;
			playerMaster.EventHandsEmpty += ClearHands;
		}

		void OnDisable()
		{
			playerMaster.EventInventoryChanged -= UpdateInventoryListAndUI;
			playerMaster.EventInventoryChanged -= CheckIfHandsEmpty;
			playerMaster.EventHandsEmpty -= ClearHands;
		}

		void SetInitialReferences()
		{
			inventoryUIScript = GameObject.FindObjectOfType<GameManager> ().GetComponent<GameManager_ToggleInventoryUI>();
			playerMaster = GetComponent<Player_Master>();
			if (itemTag == "") {
				Debug.LogWarning ("Enter the name of the tag used for items in the Player_Inventory > Item Tag field in the inspector");
				return;
			}
		}

		void UpdateInventoryListAndUI()
		{
			//Debug.Log("ran");
			counter = 0;
			listInventory.Clear();
			listInventory.TrimExcess();

			ClearInventoryUI();

			foreach (Transform child in inventoryPlayerParent)
			{
				if (child.CompareTag(itemTag))
				{
					listInventory.Add(child);
					GameObject go = Instantiate(uiButton) as GameObject;
					buttonText = child.name;
					go.GetComponentInChildren<Text>().text = buttonText;
					int index = counter;
					go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
					go.GetComponent<Button>().onClick.AddListener(inventoryUIScript.ToggleInventoryUI);
					go.transform.SetParent(inventoryUIParent, false);
					counter++;
				}
			}
		}

		void CheckIfHandsEmpty()

		{
			if (currentlyHeldItem == null && listInventory.Count > 0)
			{
				StartCoroutine(PlaceItemInHands(listInventory[listInventory.Count - 1]));
			}
		}

		void ClearHands()
		{
			currentlyHeldItem = null;
		}

		void ClearInventoryUI()
		{
			foreach (Transform child in inventoryUIParent)
			{
				Destroy(child.gameObject);
			}
		}

		public void ActivateInventoryItem(int inventoryIndex)
		{
			DeactivateAllInventoryItems();
			StartCoroutine(PlaceItemInHands(listInventory[inventoryIndex]));
		}

		void DeactivateAllInventoryItems()
		{
			foreach (Transform child in inventoryPlayerParent)
			{
				if (child.CompareTag(itemTag))
				{
					child.gameObject.SetActive(false);
				}
			}
		}

		IEnumerator PlaceItemInHands(Transform itemTransform)
		{
			yield return new WaitForSeconds(timeToPlaceInHands);
			currentlyHeldItem = itemTransform;
			currentlyHeldItem.gameObject.SetActive(true);
		}
	}
}