/*
 * WalkThroughWall.cs
 * 
 * Apply this script to any object you want to walk through.
 * 
 * Also changes the color and texture when trigger is entered
 * and changes color and texture back to starting values on trigger exit.
 * 
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Chapter1 {
	
	public class WalkThroughWall : MonoBehaviour {

		private int startingLayer;
		private Color startingColor;
		private Texture startingTexture;
		[SerializeField] private Color triggerActiveColor = new Color(0.5f, 1, 0.5f, 0.3f);
		[SerializeField] private Texture triggerActiveTexture = new Texture();
		private Renderer rend;
		private GameManager_EventMaster eventManagerScript;

		void OnEnable(){
			SetInitialReferences ();
			eventManagerScript.m_GeneralEvent += SetLayerToNotSolid;
			//eventManagerScript.m_GeneralEvent -= SetLayerToDefault;
		}

		void OnDisable(){
			//eventManagerScript.m_GeneralEvent += SetLayerToDefault;
			eventManagerScript.m_GeneralEvent -= SetLayerToNotSolid;
		}

		void SetLayerToNotSolid(){
			gameObject.layer = LayerMask.NameToLayer ("NotSolid");
			rend.material.SetTexture ("_MainTex", triggerActiveTexture);
			rend.material.SetColor ("_Color", triggerActiveColor);
		}

		void SetLayerToDefault(){
			gameObject.layer = startingLayer;
			rend.material.SetTexture ("_MainTex", startingTexture);
			rend.material.SetColor ("_Color", startingColor);
		}

		void SetInitialReferences(){
			eventManagerScript = GameObject.Find ("GameManagers").GetComponent <GameManager_EventMaster> ();
			rend = GetComponent <Renderer> ();
			startingLayer = gameObject.layer;
			startingTexture = rend.material.GetTexture ("_MainTex");
			startingColor = rend.material.GetColor ("_Color");
		}
	}
}

