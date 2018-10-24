//Game Programming HW1 
//==============================================================================================================================
// Name        : Portal.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to teleportation pads. When player is in range, teleports to random defined positions.
//==============================================================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public Transform[] portals;
	int Portal_index;

    //On trigger, so that when player enters colider, it teleports to 1 of 10 predifined spots
	void OnTriggerEnter(Collider Player){
		Portal_index = Random.Range(0, portals.Length);
		Player.transform.position = portals[Portal_index].position;
		Debug.Log(Portal_index);
	}
}
