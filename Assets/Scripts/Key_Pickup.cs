//Game Programming HW1 
//=======================================================================================
// Name        : Health_Pickup.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to crates where player can walk to it and heal up
//========================================================================================

using UnityEngine;
using System.Collections;
public class Key_Pickup : MonoBehaviour
{
    public Transform other;
    public float closeDistance = 0.5F;
	public static bool key = false;


    void Update()
    {
        if (other)
        {
            Vector3 offset = other.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen < closeDistance * closeDistance)
            {
                //Set Active to false, so it can be set to true when restarting game
                this.gameObject.SetActive(false);

                //Set key value to true, so it can open door
				key = true;
				Debug.Log("You obtained the key");
            }

        }
    }

    public void KeyReset()
    {
		key = false;
        this.gameObject.SetActive(true);
    }
}