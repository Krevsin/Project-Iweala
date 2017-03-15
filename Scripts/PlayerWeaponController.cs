using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
	public GameObject playerHand;
	public GameObject EquippedWeapon {get; set;}

	Transform spawnProjectile;

	IWeapon equipIWeapon;
	CharacterStats characterStats;

	void Start(){
		spawnProjectile = transform.FindChild ("ProjectileSpawn");
		characterStats = GetComponent<CharacterStats> ();
	}

	//the following can also work for non-weapons but it's only doing weapons for now, 
	//just change the bone it attaches to
	public void EquipWeapon(Item itemToEquip){
		if (EquippedWeapon != null) {
			characterStats.RemoveStatBonus (EquippedWeapon.GetComponent<IWeapon>().Stats);
			Destroy (playerHand.transform.GetChild(0).gameObject);
		}
		//if doing stuff other than weapons, go Resources.Load<GameObject>(ItemType/), 
		//you'd check the itemType and see if there's a folder that matches the ItemType name
		EquippedWeapon = (GameObject) Instantiate (Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position+ new Vector3(0, 0.3f), playerHand.transform.rotation);

		equipIWeapon = EquippedWeapon.GetComponent<IWeapon> ();
		if (EquippedWeapon.GetComponent<IProjectileWeapon> () != null)
			EquippedWeapon.GetComponent<IProjectileWeapon> ().ProjectileSpawn = spawnProjectile;


		equipIWeapon.Stats = itemToEquip.Stats;

		EquippedWeapon.transform.SetParent (playerHand.transform);
		characterStats.AddStatBonus (itemToEquip.Stats);
		Debug.Log (equipIWeapon.Stats [0].GetCalculatedStatValue());
	}



	void Update(){
		if (Input.GetKeyDown (KeyCode.A))
			PerformWeaponAttack ();
		if (Input.GetKeyDown (KeyCode.S))
			PerformWeaponSpecialAttack ();
	}

	public void PerformWeaponAttack(){
		equipIWeapon.PerformAttack ();
	}


	public void PerformWeaponSpecialAttack(){
		equipIWeapon.PerformSpecialAttack ();
	}
}
