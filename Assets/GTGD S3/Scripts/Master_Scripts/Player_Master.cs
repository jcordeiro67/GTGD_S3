﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 {

	public class Player_Master : MonoBehaviour {

		public delegate void GeneralEventHandler();
		public event GeneralEventHandler EventInventoryChanged;
		public event GeneralEventHandler EventHandsEmpty;
		public event GeneralEventHandler EventAmmoChanged;

		public delegate void AmmoPickupEventHandler(string ammoName, int quantity);
		public event AmmoPickupEventHandler EventPickedUpAmmo;

		public delegate void PlayerHealthHandler(int healthChange);
		public event PlayerHealthHandler EventPlayerHealthDeduction;
		public event PlayerHealthHandler EventPlayerHealthIncrease;

		public void CallEventInventoryChanged(){
			if(EventInventoryChanged != null){
				EventInventoryChanged ();
			}
		}

		public void CallEventHandsEmpty(){
			if(EventHandsEmpty != null){
				EventHandsEmpty ();
			}
		}

		public void CallEventAmmoChanged(){
			if(EventAmmoChanged != null){
				EventAmmoChanged ();
			}
		}

		public void CallEventPickedUpAmmo(string ammoName, int quantity){
			if(EventPickedUpAmmo != null){
				EventPickedUpAmmo (ammoName, quantity);
			}
		}

		public void CallEventPlayerHealthDeduction(int damage){
			if(EventPlayerHealthDeduction != null){
				EventPlayerHealthDeduction(damage);
			}
		}

		public void CallEventPlayerHealthIncrease(int increase){
			if(EventPlayerHealthIncrease != null){
				EventPlayerHealthIncrease(increase);
			}
		}
	}
}