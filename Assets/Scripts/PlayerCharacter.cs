using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
	public int _health = 150;

	//Attach all game objects
    public GameObject spawn;
    public GameObject HealthObject;
    public GameObject HealthObject2;
	public GameObject KeyObject;


    public Image currentHealthBar;
    public Text ratioText;


    void Start()
    {
        _health = 100;

    }

    public void StartAgain()
    {
        _health = 100;

        this.gameObject.transform.rotation = spawn.transform.rotation;
        this.gameObject.transform.position = spawn.transform.position;
        GetComponent<FPSInput>().enabled = true;
        

        Health_Pickup Obj = HealthObject.GetComponent<Health_Pickup>();
        Obj.HealthReset();
        Health_Pickup Obj2 = HealthObject2.GetComponent<Health_Pickup>();
        Obj2.HealthReset();
		Key_Pickup keyObj = KeyObject.GetComponent<Key_Pickup>();
		keyObj.KeyReset();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Debug.ClearDeveloperConsole();
            Debug.Log("Game Restart!");

			StartAgain();
        }
    }



    public void Hurt(int damage)
    {
        
        _health -= damage;
        float ratio = _health / 100.0f;
        print("The ratio when taking damage: "+ ratio);
        currentHealthBar.rectTransform.localScale = new Vector3(ratio,1,1);
        ratioText.text = (_health).ToString();

        if (_health <= 0)
        {
            Debug.Log("You are dead!");
            GetComponent<FPSInput>().enabled = false;
            //this.gameObject.SetActive(false);

        }
        else
        {
            GetComponent<FPSInput>().enabled = true;
        }

        Debug.Log("Health: " + _health);

    }

    public void IncreaseHealth(int healthIncrease)
    {
        _health += healthIncrease;
		float ratio = _health / 100.0f;
        print("The ratio when taking damage: " + ratio);
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (_health).ToString();
        Debug.Log("Your health has increased by: " + healthIncrease + ". New health is: " + _health);
    }
}