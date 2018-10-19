//Game Programming HW1 
//=================================================================================
// Name        : Fireball.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to enemy prefabs and allows them to shoot
//=================================================================================

using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;
	public float range = 100f;

	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(damage);
		}
		Destroy(this.gameObject);
	}
}
