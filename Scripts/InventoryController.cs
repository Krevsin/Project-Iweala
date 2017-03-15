using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	public PlayerWeaponController playerWeaponController;
	public Item sword;
	public Item staff;

	void Start(){
		playerWeaponController = GetComponent<PlayerWeaponController> ();
		List<BaseStat> swordStats = new List<BaseStat> ();
		List<BaseStat> staffStats = new List<BaseStat> ();

		swordStats.Add (new BaseStat (6, "Power", "Your power level."));
		sword = new Item (swordStats, "sword");

		staffStats.Add (new BaseStat (3, "Power", "Your power level."));
		staff = new Item (swordStats, "staff");

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			playerWeaponController.EquipWeapon (sword);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			playerWeaponController.EquipWeapon (staff);
		}

	}
}
