using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour {
	UnityEngine.AI.NavMeshAgent  playerAgent;
	public Animator animator;
	private Rigidbody rBody;
	private Transform Selection;
	SelectionRing ring;


	void Awake(){
		playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		rBody = GetComponent<Rigidbody> ();
		ring = Resources.Load<SelectionRing> ("Misc/Ring");
	}


	void Update () {
		if (Input.GetMouseButtonDown (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject () ) {
			GetInteraction ();
		}

		float speed = playerAgent.remainingDistance - playerAgent.stoppingDistance;
		animator.SetFloat ("Speed", speed);

	}

	void GetInteraction(){
		Ray interactionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit interactionInfo;

		if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)){
			GameObject interactedObject = interactionInfo.collider.gameObject;
			if (interactedObject.tag == "Interactable Object" || interactedObject.tag == "Enemy") {
				interactedObject.GetComponent<Interactable> ().MoveToInteraction (playerAgent);
				Selection = interactedObject.GetComponent<Transform> ();

				SelectionRing ringInstance =(SelectionRing) Instantiate(ring, Selection.position, Selection.rotation);

				if (interactedObject.tag == "Enemy"){
					ringInstance.GetComponent<Renderer>().material.color = Color.red;
				}
			} 

			else {
				playerAgent.stoppingDistance = 0f;
				playerAgent.destination = interactionInfo.point;

			}
		}
	}


}
