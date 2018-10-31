using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour
{

    //on collision
    void OnTriggerEnter(Collider col)
    {
        print("It is coliding with this platform");
        col.transform.parent = gameObject.transform;
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }

    //-100, 5, -20 (at platform)
    //-102, 4.05, -19.55
}