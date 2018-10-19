using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	private int EnemyHealth = 2;

	public void ReactToHit(int damage) {
		WanderingAI behavior = GetComponent<WanderingAI>();
        HidingAI hiding = GetComponent<HidingAI>();
        RunAwayAI running = GetComponent<RunAwayAI>();
//        SceneController enemies = GetComponent<SceneController>();
//        if (enemies == null) {
//            Debug.LogError("Cant find SceneController ");
//        }
		EnemyHealth = EnemyHealth - damage;

		if (EnemyHealth == 0){
			if (behavior != null)
			{
				behavior.SetAlive(false);
				StartCoroutine(Die());
			}
		}
        if (hiding != null) {
            hiding.SetAlive(false);
			StartCoroutine(Die());
        }
        if (running != null) {
            running.SetAlive(false);
			StartCoroutine(Die());
        }


        


	}

	private IEnumerator Die() {

		this.transform.Rotate(-90, 0, 0);
        //What I added
		//Vector3 pos = transform.position;
		//pos.y = -1.25f;
		//this.transform.position = pos;

		yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }


}
