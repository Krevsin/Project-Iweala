using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	public UnityEngine.AI.NavMeshAgent  playerAgent;
	private bool hasInteracted;
	public Animator animator;


	public virtual void MoveToInteraction(UnityEngine.AI.NavMeshAgent playerAgent){
		hasInteracted = false;
		this.playerAgent = playerAgent;
		playerAgent.stoppingDistance = 2.0f;
		playerAgent.destination = transform.position;

	}


	void Update(){
		if(!hasInteracted && playerAgent != null && !playerAgent.pathPending){						
			float distance = Vector3.Distance(playerAgent.destination, transform.position);
			if (distance > 0.8f) hasInteracted = true;

			else if (!playerAgent.pathPending) {
				if (playerAgent.remainingDistance < playerAgent.stoppingDistance) {	
					Interact ();
					hasInteracted = true;
				}		
			}
		}
	}


	public virtual void Interact(){
		Debug.Log ("Interacting with base class.");
	}

}
