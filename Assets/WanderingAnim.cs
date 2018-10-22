using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class WanderingAnim : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 2.0f;
    public float closeDistance = 15.0F; //distance between player and enemy

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    public Transform target;
    private bool _aliveAnim;
    private Animator _animator;

    private NavMeshAgent agent;

    //positions of where to patrol
    Vector3[] patrolPositions = { new Vector3 { x = -34.0f, y = 1.0f, z = -25.0f },
                         new Vector3 { x = -34.0f, y = 1.0f, z = -12.0f },
                         new Vector3 { x = -34.0f, y = 1.0f, z = 3.0f },
                         new Vector3 { x = -100.0f, y = 1.0f, z = 3.0f },
                         new Vector3 { x = -100.0f, y = 1.0f, z = -25.0f },
                         new Vector3 { x = -90.0f, y = 1.0f, z = -12.0f },
                         new Vector3 { x = -100.0f, y = 4.2f, z = -27.0f },
                         new Vector3 { x = -100.0f, y = 4.2f, z = 4.5f },
                         new Vector3 { x = -26.0f, y = 1.0f, z = -12.0f },
                         new Vector3 { x = -100.0f, y = 1.0f, z = -12.0f } };
    void GotoNextPoint()
    {
        int randomPost = Random.Range(0, 10);
        // Returns if no points have been set up
        if (patrolPositions.Length == 0)
            return;
        // Set the agent to go to the currently selected destination.
        agent.destination = patrolPositions[randomPost];
        // Choose the next point in the array as the destination, cycling to the start if necessary.
        //destPoint = ( + 1) % patrolPositions.Length;
    }

    void Start()
    {
        _aliveAnim = true;
        agent = GetComponent<NavMeshAgent>();        GotoNextPoint();
    }




    void Update()
    {
        if (_aliveAnim)
        {
            _animator = GetComponent<Animator>();
            //transform.Translate(0, 0, speed * Time.deltaTime); //move forward

            if (GameObject.Find("Player") && GameObject.Find("Player").GetComponent<PlayerCharacter>()._health >= 0)
            {
                Vector3 offset = GameObject.Find("Player").transform.position - transform.position;
                float sqrLen = offset.sqrMagnitude;
                if (sqrLen < closeDistance * closeDistance)
                {
                    //print("The other transform is close to me!");
                    //Debug.Log("THE PLAYERS Y VALUE: " + transform.position);
                    transform.LookAt(GameObject.Find("Player").transform.position);
                    agent.destination = GameObject.Find("Player").transform.position;
                }
                //has not seen me so just patrol
                else
                {
                    //int randomPost = Random.Range(0,10);
                    if (agent.remainingDistance < 0.5f)
                        GotoNextPoint();
                }

            }

        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>() && hitObject.GetComponent<PlayerCharacter>()._health >= 0)
            {
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
                    _fireball.transform.position = transform.TransformPoint(0, 1, 1 * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                //transform.Rotate(0, angle, 0);
            }
        }

        else
        {
            Debug.Log("The enemy 1 is DEAD");
            _animator.SetBool("isDead", true);
        }
    }


    public void SetAlive(bool alive)
    {
        _aliveAnim = alive;
    }



}


