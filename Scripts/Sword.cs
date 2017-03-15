using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : MonoBehaviour, IWeapon {

	private Animator animator;
	public List<BaseStat> Stats { get; set; }


	void Start(){
		animator = GetComponent<Animator> ();
	}

	public void PerformAttack (){
		
		animator.SetTrigger ("Base_Attack");
		Debug.Log (this.name + " attack!");
	}

	public void PerformSpecialAttack (){

		Debug.Log(this.name + " special attack!");
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("Hit: " + col.name);
		if (col.tag == "Enemy") {
			col.GetComponent<IEnemy> ().TakeDamage (Stats[0].GetCalculatedStatValue());
		}
	}

}
