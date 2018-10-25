using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour {

    //on collision
    void OnTriggerEnter(Collider col)
    {
        col.transform.parent = gameObject.transform;    
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;   
    }


}
