using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialManager : GameModeManager
{

    public GameObject spawnPoint;
    public RingManager ringManager;
    public GameObject player;
    //score manager object
    public ScoreManager scoreManager;

    private int state; // 0-start line 1-mid race 2-completed

    //metrics
    private float currentLead; //delta time between the player and the fastest ghost? at the prev. ring

    //ghosts (maybe)
    private GameObject GhostThisGame; //fastest this game
    private GameObject GhostAllTime; //fastest of all time


    // Start is called before the first frame update
    void Start()
    {
        ringManager.myManager = this;
        SetupRace();
    }

    // Update is called once per frame
    void Update()
    {
        bool anyKeyPressed = Input.GetKey(KeyCode.Space) ||
                Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        //start the game if player presses a key that controls the plane
        if (anyKeyPressed && state == 0) { StartRun(); };
    }

    public void SetupRace()
    {
        //reset this object's variables
        state = 0;
        currentLead = 0;
        //teleport the player object to the start of the track
        player.transform.position = spawnPoint.transform.position;
        //reset RingManager (currently redundant)
        ringManager.ResetTrack();
        //spawn ghost - TODO

    }
    
    public void StartRun()
    {
        state = 1;
        ringManager.StartRun();
    }

    public override void RunCompleted(float runDuration, List<float> timeList)
    {
        Debug.Log("TimeTrialManager: Run completed. duration: " + runDuration);
        state = 2;
        //remove ghosts
        //reset RingManager
        //respawn player
        //wait at start
        StoreRun(runDuration, timeList);

        //reset race
        SetupRace();

    }

    //respawn the player at the last tagged ring
    public void ResetCheckpoint()
    {
        this.player.transform.position = ringManager.CurrentRing().transform.position;
    }

    //temporary
    public void displayTimes(List<float> timeList, Score prevRun)
    {
        if (prevRun != null && prevRun.timeList != null) { 

            for (int i = 0; i < timeList.Count; i++)
            {
                float thisT = timeList[i];
                float prevT = prevRun.timeList[i];
                Debug.Log("now: " + thisT + " before: " + prevT + " deltaTime: " + (thisT-prevT));
            }
        }
    }

    //store current run as a Score object in the ScoreManager
    public void StoreRun(float runDuration, List<float> timeList)
    {
        Score thisRun = (Score)ScriptableObject.CreateInstance("Score");
        thisRun.Construct(runDuration, Score.cloneFloatList(timeList), null, null); //for now
        thisRun.trackName = ringManager.trackRoot.name;
        if (scoreManager)
        {
            scoreManager.AddScore(thisRun);
        }
        
    }
}
