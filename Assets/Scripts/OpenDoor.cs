using UnityEngine;
using System.Collections;
public class OpenDoor : MonoBehaviour
{
    public Transform other;
    public float closeDistance = 0.5F;
	private Animator _animator;


	void Start(){
		_animator = GetComponent<Animator>();
	}

    void Update()
    {
        if (other)
        {
            Vector3 offset = other.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen < closeDistance * closeDistance)
            {
				_animator.SetBool("character_nearby", true);
            }

        }
		else
        {
            _animator.SetBool("character_nearby", false);
        }
    }
}