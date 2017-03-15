using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRing : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButtonDown (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
			Destroy (gameObject);
		}
	}

}
