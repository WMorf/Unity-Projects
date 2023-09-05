using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Missile_GameManager : MonoBehaviour
{
    public static Missile_GameManager Instance;

    private IEnumerator cityCount;

    public Missile_MenuController menu;

    //Score Handling
    public Missile_Score mScore;
    public int score;
    public int reward = 1000;
    public TMP_Text mCounter;
    public TMP_Text roundCounter;

    //Prefabs to be respawned once reward is met
    public GameObject cityPrefab;
    public GameObject rewardPrefab;

    //Object Tracking
    public List<Vector3> cityLocations = new List<Vector3>();
    public List<Vector3> craterLocations = new List<Vector3>();

    //Round Tracking
    public int missileMax = 35, missileCount; //Player
    private int curMCount;
    public int emissileMax= 25, emissileCount; //Enemy
    public float roundTimerMax = 10f, roundTimerCount;
    private int roundCount;

    public SceneLoader loader;

    public void LoadNextLevel()
    {
        loader.LoadSceneName("MissileEndScreen");
    }


    private void Start()
    {
        // Set the static instance to this instance of the GameManager
        Instance = this;

        roundCounter.text = string.Format("");
        roundCount = 1;

        // Start coroutine
        cityCount = CityTimer(); // Assign the coroutine to the variable
        StartCoroutine(cityCount); // Start the coroutine
    }

    private void FixedUpdate()
    {
        //Get current score from Scoreboard
        score = mScore.score;
        curMCount = missileMax - missileCount;
        mCounter.text = string.Format("" + curMCount);

        //Round Management
        if (emissileCount >= emissileMax)
        {
            roundCounter.text = string.Format("ROUND: " + (roundCount + 1));
            //Timer to pause between rounds
            roundTimerCount += Time.deltaTime;

            if(roundTimerCount >= roundTimerMax)
            {
                roundCounter.text = string.Format("");
                roundCount += 1;
                missileCount = 0;
                emissileCount = 0;
                roundTimerCount =0f;
            }
        }

    }

    // Coroutine to run code every 3 seconds
    IEnumerator CityTimer()
    {
        while (true) // Infinite loop to keep running the code
        {
            cityLocations.Clear();
            craterLocations.Clear();
            // Find all the city gameobjects in the scene
            GameObject[] cityObjects = GameObject.FindGameObjectsWithTag("Building");
            GameObject[] craterObjects = GameObject.FindGameObjectsWithTag("Gibs");

            // Add the positions of the city objects to the list of city locations
            foreach (GameObject cityObject in cityObjects)
            {
                cityLocations.Add(cityObject.transform.position);
            }
            foreach (GameObject craterObject in craterObjects)
            {
                craterLocations.Add(craterObject.transform.position);
            }

            // Wait for 2 seconds before running the code again
            yield return new WaitForSeconds(2f);

            if(cityLocations.Count <= 0)
            {
                //ends loop if city count reaches 0
                LoadNextLevel();
            }

            //If score meets requirement and there is a destroyed
            if(craterLocations.Count > 0 && score >= reward )
            {
                RespawnCity(craterObjects);
                reward += 1000;
            }

        }
    }

    //Respawns city based on location of crater that is spawned when city destroyed
    public void  RespawnCity(GameObject[] craterObjects)
    {
        int craterPick = Random.Range(0, craterLocations.Count);
        Vector3 craterSpot = craterLocations[craterPick];
        Instantiate(cityPrefab, craterSpot, transform.rotation);
        Instantiate(rewardPrefab, craterSpot, transform.rotation);
        Object.Destroy(craterObjects[craterPick]);
        
    }
}