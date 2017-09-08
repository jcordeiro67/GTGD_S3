using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1{

	public class GameManager_EventMaster : MonoBehaviour {

		public delegate void GeneralEvent ();
		public event GeneralEvent m_GeneralEvent; 

		public void CallGeneralEvent(){

			if(m_GeneralEvent !=null){
				m_GeneralEvent ();
			}
		}
	}
}


