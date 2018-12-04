using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {
    
	private Animator _animator;
	private float speed = 6.0f;
	private bool crouch;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //Crouch Toggle
		if (Input.GetKeyUp(KeyCode.C))
        {
			_animator.SetBool("isCrouch", !_animator.GetBool("isCrouch"));

			if(_animator.GetBool("isCrouch")){
				Camera.main.transform.Translate(0.1f, -0.9f, 0.15f);
                //GameObject.FindGameObjectWithTag("MuzzleFlash").transform.Translate(0,-0.9f,0f);
			}
			else{
				Camera.main.transform.Translate(-0.1f, 0.9f, -0.15f);
			}
        }

        //Crouch Walking Forward
		if (_animator.GetBool("isCrouch") && Input.GetKey(KeyCode.W))
        {
			_animator.SetBool("isCrouchWalking", true);
        }
		else{
			_animator.SetBool("isCrouchWalking", false);
		}

        //Crouch Walking Back
		if (_animator.GetBool("isCrouch") && Input.GetKey(KeyCode.S))
        {
			_animator.SetBool("isCrouchWalkingBackward", true);
        }
        else
        {
			_animator.SetBool("isCrouchWalkingBackward", false);
        }


       
        //Animation for walking forwards and running
		if (Input.GetKey(KeyCode.W)){
			_animator.SetBool("isWalking", true);


			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)){
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isRunning", true);
            }
            
			else {
				_animator.SetBool("isRunning", false);
				_animator.SetBool("isWalking", true);
			}
            

        }

		else{
			_animator.SetBool("isWalking", false);
			_animator.SetBool("isRunning", false);
			_animator.SetBool("isIdle", true);
		}


        //Animation for walking back
		if (Input.GetKey(KeyCode.S) ){
            _animator.SetBool("isWalkingBack", true);
        }

		else{
			_animator.SetBool("isWalkingBack", false);
            _animator.SetBool("isIdle", true);
		}


        //Animation for right strafe
		if(Input.GetKey(KeyCode.D) && !Input.GetKeyUp(KeyCode.A) && !Input.GetKeyUp(KeyCode.W) && !Input.GetKeyUp(KeyCode.S)){
			_animator.SetBool("isStrafingRight", true);
		}
		else{
			_animator.SetBool("isStrafingRight", false);
		}
        

		//Animation for left strafe
		if (Input.GetKey(KeyCode.A) && !Input.GetKeyUp(KeyCode.D) && !Input.GetKeyUp(KeyCode.W) && !Input.GetKeyUp(KeyCode.S)){
 
            _animator.SetBool("isStrafingLeft", true);
        }
        else{
            _animator.SetBool("isStrafingLeft", false);
        }

		if(Input.GetMouseButton(0)){
			_animator.SetBool("isShooting", true);
		}
		else{
			_animator.SetBool("isShooting", false);
		}


	}
}
