//Game Programming HW1 
//=======================================================================================
// Name        : Health_Pickup.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to crates where player can walk to it and heal up
//========================================================================================

using UnityEngine;
using System.Collections;
public class Health_Pickup : MonoBehaviour
{
    public Transform other;
    public float closeDistance = 0.5F;


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

                //Create player object and call Increase function
                PlayerCharacter player = other.GetComponent<PlayerCharacter>();
                player.IncreaseHealth(3);
            }
        }
    }

    public void HealthReset()
    {
        this.gameObject.SetActive(true);
    }
}