using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : MonoBehaviour, IEnemy {

	public float maxHealth, power, toughness;
	private float currentHealth;

	void Start(){
		currentHealth = maxHealth;
	}

	public void PerformAttack(){
		throw new NotImplementedException ();
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;
		if (currentHealth <= 0)
			Die ();
	}

	void Die(){
		Destroy (gameObject);
	}

}
