//Game Programming HW1 
//===========================================================================================
// Name        : RunAwayAI.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Attached to Enemy 3. Will turn around and run if player gets in front of it.
//===========================================================================================

using UnityEngine;
using System.Collections;

public class RunAwayAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 1.0f;
    public float closeDistance = 15.0F; //distance between player and enemy

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    public Transform target;
    private bool _alive;
    private bool _isSeen;

    void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive)
        {
            if (_isSeen)
            {
                transform.Translate(0, 0, speed * Time.deltaTime); // will not move 
            }


            ////If player is next to enemy2it shall lock on to them
            //Vector3 offset = GameObject.Find("Player").transform.position - transform.position;
            //float sqrLen = offset.sqrMagnitude;
            //if (sqrLen < closeDistance * closeDistance)
            //{
            //    print("The other transform is close to me!");
            //    transform.LookAt(GameObject.Find("Player").transform.position);
            //}

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {

                    transform.Rotate(0, Random.Range(180, 360), 0);
                    //transform.Translate(0, 0, speed * Time.deltaTime);
                    _isSeen = true;
                    if (GameObject.Find("Player").transform.position != null)
                    {
                        Debug.Log("The player position is " + GameObject.Find("Player").transform.position);
                    }
                    //transform.LookAt(GameObject.Find("Player").transform.position);
                    //PlayerCharacter playerPosition = GetComponent<PlayerCharacter>();
                    if (_fireball == null)
                    {

                       
                       // transform.LookAt(GameObject.Find("Player").transform.position);
                       // _fireball = Instantiate(fireballPrefab) as GameObject;
                       // _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                       // _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(180, 360);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
