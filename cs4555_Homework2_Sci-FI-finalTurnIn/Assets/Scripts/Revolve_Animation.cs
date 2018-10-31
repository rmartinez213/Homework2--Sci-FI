using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolve_Animation : MonoBehaviour {

	private int number = 0;
	private Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		      
		if(Input.GetKeyDown(KeyCode.R)){
			_animator.Play("Reload");
		}

		if(Input.GetMouseButtonDown(0)){
			
			_animator.Play("Fire");
			_animator.StopPlayback();
		}
	}
}
