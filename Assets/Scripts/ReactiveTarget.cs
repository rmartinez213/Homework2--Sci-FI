using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour
{
    private Animator _animator;


    private int EnemyHealth = 2;

    public void ReactToHit(int damage)
    {
        _animator = GetComponent<Animator>();
        WanderingAnim aliveanim = GetComponent<WanderingAnim>(); // for enemy1 anim
        WanderingAI behavior = GetComponent<WanderingAI>();
        HidingAI hiding = GetComponent<HidingAI>();
        RunAwayAI running = GetComponent<RunAwayAI>();
        //        SceneController enemies = GetComponent<SceneController>();
        //        if (enemies == null) {
        //            Debug.LogError("Cant find SceneController ");
        //        }
        EnemyHealth = EnemyHealth - damage;
        Debug.Log("Someone got hit");

        if (EnemyHealth == 0)
        {

            if (behavior != null)
            {
                behavior.SetAlive(false);
                StartCoroutine(Die());
            }
            if (aliveanim != null)
            {
                aliveanim.SetAlive(false);
                StartCoroutine(Die());
            }
        }
        if (hiding != null)
        {
            hiding.SetAlive(false);
            StartCoroutine(Die());
        }
        if (running != null)
        {
            running.SetAlive(false);
            StartCoroutine(Die());
        }





    }

    private IEnumerator Die()
    {

        //this.transform.Rotate(-90, 0, 0);
        //What I added
        //Vector3 pos = transform.position;
        //pos.y = -1.25f;
        //this.transform.position = pos;

        //     _animator.SetBool("isDead", true);


        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }


}