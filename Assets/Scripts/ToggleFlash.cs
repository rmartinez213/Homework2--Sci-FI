using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFlash : MonoBehaviour {

    public ParticleSystem muzzleFlash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (muzzleFlash.gameObject.activeSelf == false)
            {
                muzzleFlash.gameObject.SetActive(true);
                
                StartCoroutine(Toggle());
            }
            else
            {
                //StartCoroutine(Toggle());
            }
            //else
            //{
            //    muzzleFlash.gameObject.SetActive(false);
            //}
        }
    }


    private IEnumerator Toggle()
    {

        //this.transform.Rotate(-90, 0, 0);
        //What I added
        //Vector3 pos = transform.position;
        //pos.y = -1.25f;
        //this.transform.position = pos;

        //     _animator.SetBool("isDead", true);
        

        yield return new WaitForSeconds(0.2f);
        muzzleFlash.gameObject.SetActive(false);
    }
}
