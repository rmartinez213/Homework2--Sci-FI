using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    public int _health;
    public GameObject spawn;
    public GameObject HealthObj;
    public GameObject HealthObj2;


    void Start()
    {
        _health = 5;

    }

    public void StartAgain()
    {
        _health = 5;

        this.gameObject.transform.rotation = spawn.transform.rotation;
        this.gameObject.transform.position = spawn.transform.position;
        GetComponent<FPSInput>().enabled = true;


        Health_Pickup Obj = HealthObj.GetComponent<Health_Pickup>();
        Obj.HealthReset();
        Health_Pickup Obj2 = HealthObj2.GetComponent<Health_Pickup>();
        Obj2.HealthReset();

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

        if (_health <= 0) 
        {
            Debug.Log("You are dead!");
            GetComponent<FPSInput>().enabled = false;
            //this.gameObject.SetActive(false);

        }
        else {
            GetComponent<FPSInput>().enabled = true;
        }

        Debug.Log("Health: " + _health);

    }

    public void IncreaseHealth(int healthIncrease)
    {
        _health += healthIncrease;
        Debug.Log("Your health has increased by: " + healthIncrease + ". New health is: " + _health);
    }
}
