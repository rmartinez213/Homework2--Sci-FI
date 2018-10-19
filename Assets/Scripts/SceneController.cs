using UnityEngine;
using System.Collections;
//control k+c == comment
//control k+f == format
public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemy2Prefab;
    [SerializeField] private GameObject enemy3Prefab;
    //private GameObject _enemy; //dont need
    //private GameObject _enemy3; //Enemy that doesnt attack

    //Spawn player at construction?
    //Set enemy 1 at phase3 (Xrange: (-24, 10) Zrange:(21, -10))
    //Set enemy 2 at concrete objects (X= -8.5, Z=-7 ) (X= -11.5, Z=-10.5 ) (X= -9, Z=4 ) (X= 35, Z=-9 )
    //Set enemy 3 at phase2 (Z = -28, 14) X = (35, 44)

    public GameObject[] listOfEnemies;
    public bool _isKilled;

    public int randomInitialEnemies; //Can probably set as public for faster testing?
    public int currentEnemies;
    private int randomEnemyType;
    private int Xrange;
    private int Yrange;
    private int Zrange;


    // for 2nd enemy
    Vector3[] randomPos = new Vector3[4];

    //init fnc, set up the scene with a random # of enemy of 3 random types
    void Start() {
        _isKilled = false;  //boolean that states if an enemy has been killed
        randomInitialEnemies = Random.Range(1, 6); //Spawn 1-5 enemies in the beginning
        currentEnemies = randomInitialEnemies; //Set the current enemies on the field
        randomEnemyType = Random.Range(1, 4);     // 1==enemy1, 2==enemy2, 3==enemy3
        Debug.Log("Spawning in the beginning: " + randomInitialEnemies);
        listOfEnemies = new GameObject[10]; //size of 10, since there can only be max of 10 enemies on the field

        randomPos[0] = new Vector3(-8.5f, -0.737f, -7f);
        randomPos[1] = new Vector3(-11.5f, -0.737f, -10.5f);
        randomPos[2] = new Vector3(-9f, -0.737f, 4f);
        randomPos[3] = new Vector3(35f, -0.737f, -9f);

        for (int i = 0; i < randomInitialEnemies; i++){ //instantiate the number of ran enemies as GameObjects 
            randomEnemyType = Random.Range(1, 4);

            if (randomEnemyType == 1){
                //listOfEnemies[i] = Instantiate(enemyPrefab) as GameObject;
                //Xrange = Random.Range(-24,11);
                //Zrange = Random.Range(-10, 22);
                //listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                //float angle = Random.Range(0, 360);
                //listOfEnemies[i].transform.Rotate(0, angle, 0);

                Xrange = Random.Range(-22, -13);
                Zrange = Random.Range(-38, -20);
                listOfEnemies[i] = Instantiate(enemyPrefab) as GameObject;
                listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                float angle = Random.Range(0, 360);
                listOfEnemies[i].transform.Rotate(0, angle, 0);
            }
            else if (randomEnemyType == 2)
            {
                int randomEnemy2location = Random.Range(0,4);
                listOfEnemies[i] = Instantiate(enemy2Prefab) as GameObject;
                listOfEnemies[i].transform.position = new Vector3(randomPos[randomEnemy2location].x, -0.737f, randomPos[randomEnemy2location].z);
                float angle = Random.Range(0, 360);
                listOfEnemies[i].transform.Rotate(0, angle, 0);
            }
            else if (randomEnemyType == 3)
            {
                Xrange = Random.Range(35, 44);
                Zrange = Random.Range(-28, 14);
                listOfEnemies[i] = Instantiate(enemy3Prefab) as GameObject;
                listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                float angle = Random.Range(0, 360);
                listOfEnemies[i].transform.Rotate(0, angle, 0);
            }

        }
    }



    //called every frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Debug.ClearDeveloperConsole();
            Debug.Log("THIS IS INSIDE SCENECONTROLLER.CS");

            for (int i = 0; i < listOfEnemies.Length; i++) {
                Object.Destroy(listOfEnemies[i]);
            }

            _isKilled = false;  //boolean that states if an enemy has been killed
            randomInitialEnemies = Random.Range(1, 6); //Spawn 1-5 enemies in the beginning
            currentEnemies = randomInitialEnemies; //Set the current enemies on the field
            randomEnemyType = Random.Range(1, 4);     // 1==enemy1, 2==enemy2, 3==enemy3
            Debug.Log("Spawning after reseting: " + randomInitialEnemies);
            listOfEnemies = new GameObject[10]; //size of 10, since there can only be max of 10 enemies on the field

            for (int i = 0; i < randomInitialEnemies; i++)
            { //instantiate the number of ran enemies as GameObjects 
                randomEnemyType = Random.Range(1, 4);

                if (randomEnemyType == 1)
                {
                    Xrange = Random.Range(-22, -13);
                    Zrange = Random.Range(-38, -20);
                    listOfEnemies[i] = Instantiate(enemyPrefab) as GameObject;
                    listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                    float angle = Random.Range(0, 360);
                    listOfEnemies[i].transform.Rotate(0, angle, 0);
                }
                else if (randomEnemyType == 2)
                {
                    int randomEnemy2location = Random.Range(0, 4);
                    listOfEnemies[i] = Instantiate(enemy2Prefab) as GameObject;
                    listOfEnemies[i].transform.position = new Vector3(randomPos[randomEnemy2location].x, -0.737f, randomPos[randomEnemy2location].z);
                    float angle = Random.Range(0, 360);
                    listOfEnemies[i].transform.Rotate(0, angle, 0);
                }
                else if (randomEnemyType == 3)
                {
                    Xrange = Random.Range(35, 44);
                    Zrange = Random.Range(-28, 14);
                    listOfEnemies[i] = Instantiate(enemy3Prefab) as GameObject;
                    listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                    float angle = Random.Range(0, 360);
                    listOfEnemies[i].transform.Rotate(0, angle, 0);
                }
            }
        }
        for (int i = 0; i < currentEnemies; i++){ //iterate up to the new amount of possible enemies in the field
            if (listOfEnemies[i] == null)
            { //This enemy has been killed or hasnt been assigned an instance yet
                _isKilled = true;
                UpdateEnemies();
            }
        }
    }

    public void UpdateEnemies(){  //will be called UpdateEnemies
        randomEnemyType = Random.Range(1, 4);  // 1==enemy1, 2==enemy2, 3==enemy3
        currentEnemies--; //1 enemy is killed 
        int newEnemies = Random.Range(1, 4); //Spawn 1-3 enemies after 1 is killed

        while (newEnemies + currentEnemies > 10)
        { //If >= 10 reroll since we dont want more than 10 enemies on the field
            newEnemies = Random.Range(1, 4);
        }
        currentEnemies = currentEnemies + newEnemies; //new enemies that can be on the field

        for (int i = 0; i < currentEnemies; i++)
        { //iterate up to the new amount of possible enemies in the field
            if (listOfEnemies[i] == null)
            { //This enemy has been killed or hasnt been assigned an instance yet
                if (randomEnemyType == 1)
                {
                    //listOfEnemies[i] = Instantiate(enemyPrefab) as GameObject;
                    //Xrange = Random.Range(-24, 11);
                    //Zrange = Random.Range(-10, 22);
                    //listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                    //float angle = Random.Range(0, 360);
                    //listOfEnemies[i].transform.Rotate(0, angle, 0);

                    Xrange = Random.Range(-22, -13);
                    Zrange = Random.Range(-38, -20);
                    listOfEnemies[i] = Instantiate(enemyPrefab) as GameObject;
                    listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                    float angle = Random.Range(0, 360);
                    listOfEnemies[i].transform.Rotate(0, angle, 0);
                }
                else if (randomEnemyType == 2)
                {
                    int randomEnemy2location = Random.Range(0, 4);
                    listOfEnemies[i] = Instantiate(enemy2Prefab) as GameObject;
                    listOfEnemies[i].transform.position = new Vector3(randomPos[randomEnemy2location].x, -0.737f, randomPos[randomEnemy2location].z);
                    float angle = Random.Range(0, 360);
                    listOfEnemies[i].transform.Rotate(0, angle, 0);
                }
                else if (randomEnemyType == 3)
                {
                    Xrange = Random.Range(35, 44);
                    Zrange = Random.Range(-28, 14);
                    listOfEnemies[i] = Instantiate(enemy3Prefab) as GameObject;
                    listOfEnemies[i].transform.position = new Vector3(Xrange, -0.737f, Zrange);
                    float angle = Random.Range(0, 360);
                    listOfEnemies[i].transform.Rotate(0, angle, 0);
                }
            }
        }
        _isKilled = false;
    }

    //not used, can get rid of
    public void SetIsKilled(bool killed)
    {
        _isKilled = killed;
    }
}
