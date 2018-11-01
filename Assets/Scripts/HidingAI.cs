//Game Programming HW1 
//===================================================================================================================
// Name        : HidingAI.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to Enemy2. Enemy 2 will turn and shoot player if within 15units.
//===================================================================================================================

using UnityEngine;
using System.Collections;

public class HidingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 0.1f;
    public float closeDistance = 15.0F; //distance between player and enemy

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    public Transform target;
    private bool _alive;
    private Animator _animator;

    void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive)
        {
            _animator = GetComponent<Animator>();
            //transform.Translate(0, 0, speed * Time.deltaTime); // since enemy hides, no need to move

            //If player is next to enemy2it shall lock on to them
            if (GameObject.Find("Player") && GameObject.Find("Player").GetComponent<PlayerCharacter>()._health >= 0)
            {
                Vector3 offset = GameObject.Find("Player").transform.position - transform.position;

                float sqrLen = offset.sqrMagnitude;
                //print("THE SQR LENGTH: " + sqrLen);

                //print("The other transform is close to me!");
                //transform.LookAt(GameObject.Find("Player").transform.position);
                if (sqrLen < closeDistance * closeDistance)
                {
                    //print("The other transform is close to me! BY THIS AMMOUNT " + sqrLen);
                    transform.LookAt(GameObject.Find("Player").transform.position);

                    //since enemy2 can see player, call for help
                    GameObject[] listEnemy1 = GameObject.FindGameObjectsWithTag("Target");
                    foreach (GameObject enemy1 in listEnemy1)
                    {
                        //Debug.Log("ENEMY 1::::: " + enemy1.transform.position);
                        float distFromE1toE3 = (enemy1.transform.position - transform.position).sqrMagnitude;
                        if (distFromE1toE3 < 200 * closeDistance)
                        {
                            Debug.Log("YO ENEMY 1. TO THE RESCUE!!! ");
                            enemy1.GetComponent<WanderingAnim>().agent.SetDestination(transform.position);
                        }
                    }

                    if (GameObject.Find("Player").transform.position != null)
                    {
                        //Debug.Log("The player position is " + GameObject.Find("Player").transform.position);
                    }
                    transform.LookAt(GameObject.Find("Player").transform.position);
                    //PlayerCharacter playerPosition = GetComponent<PlayerCharacter>();
                    if (_fireball == null)
                    {


                        transform.LookAt(GameObject.Find("Player").transform.position);
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(0, 1.2f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }

            }
            /* UNCOMMENT THIS FOR EXTREME MODE lol*/
            //      Ray ray = new Ray(transform.position, transform.forward);
            //      RaycastHit hit;
            //      GameObject hitObject;
            //          if (GameObject.Find("Player") && GameObject.Find("Player").GetComponent<PlayerCharacter>()._health >= 0)
            //          {
            ////              if (GameObject.Find("Player").transform.position != null)
            ////              {
            ////                  //Debug.Log("The player position is " + GameObject.Find("Player").transform.position);
            ////              }
            ////              transform.LookAt(GameObject.Find("Player").transform.position);
            ////              //PlayerCharacter playerPosition = GetComponent<PlayerCharacter>();
            ////              if (_fireball == null)
            ////              {


            ////                  transform.LookAt(GameObject.Find("Player").transform.position);
            ////                  _fireball = Instantiate(fireballPrefab) as GameObject;
            ////_fireball.transform.position = transform.TransformPoint(0, 1.2f, 1 * 1.5f);
            ////                  _fireball.transform.rotation = transform.rotation;
            ////              }
            //          }
            //  }
        }
        else
        {
            _animator.SetBool("isDeadCa", true);
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}