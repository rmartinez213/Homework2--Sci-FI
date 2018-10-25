using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour {

    //In a static method
	public Animator _animator;
	private bool key; 

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other){
		key = Key_Pickup.key;

		Debug.Log("My key is: " + key);

		if ((other.tag == "Player") && key)
		{
			_animator.SetBool("open", true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
	public void DoorReset(){
		_animator.SetBool("open", false);
		Debug.Log("door is closed");
	}
}