using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour
{

       
    public Animator _animator;
    private bool key;
    private bool isOpen = false;
    private bool isInsideTrigger = false;


    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        isInsideTrigger = true;

        //Seek if key is true 
        key = Key_Pickup.key;
        Debug.Log("My key is: " + key);

        if ((other.tag == "Player"))
        {
            //  _animator.SetBool("open", false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        isInsideTrigger = false;


        if ((other.tag == "Player"))
        {

            _animator.SetBool("open", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTrigger && key)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                _animator.SetBool("open", isOpen);
            }
        }
    }


}