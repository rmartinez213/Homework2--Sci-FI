using UnityEngine;
using System.Collections;

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

    void Start()
    {
        _aliveAnim = true;
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
        }
        else {
            Debug.Log("The enemy 1 is DEAD");
            _animator.SetBool("isDead", true);
        }

    }

    public void SetAlive(bool alive)
    {
        _aliveAnim = alive;
    }
}
