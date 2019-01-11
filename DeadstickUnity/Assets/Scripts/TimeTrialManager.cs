using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialManager : GameModeManager
{

    public GameObject spawnPoint;
    public RingManager ringManager;
    public GameObject player;
    private RecordGhost recordGhost;
    //score manager object
    public ScoreManager scoreManager;

    private int state; // 0-start line 1-mid race 2-completed

    //metrics
    private float currentLead; //delta time between the player and the fastest ghost? at the prev. ring
    private int currentProgress;

    public float timeElapsed;

    //UI
    public MainUI UI;

    //ghosts (maybe)
    public GameObject ghostPrefab1;
    public GameObject ghostPrefab2;


    // Start is called before the first frame update
    void Start()
    {
        ringManager.myManager = this;
        recordGhost = player.GetComponent<RecordGhost>();
        SetupRace();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate lead compared to ghost at prev. ring
        if (ringManager.progress > currentProgress)
        {
            currentProgress++;
            Score s = scoreManager.GetScore(false, 0); //very temporary
            if (s != null) { currentLead = ringManager.timeList[currentProgress - 1] - s.timeList[currentProgress - 1]; } //temporary - get ghost and timeList from same object!!!!
            Debug.Log("lead:" + currentLead);
        }

        //timer
        if (state == 1) { timeElapsed = Time.fixedTime - ringManager.startTime; } // grdo


        bool anyKeyPressed = Input.GetKey(KeyCode.Space) ||
                Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        //start the game if player presses a key that controls the plane
        if (anyKeyPressed && state == 0) { StartRun(); };

        //update UI
        UI.time = timeElapsed;
        UI.progress = ringManager.progress;
        UI.length = ringManager.length;
        UI.lead = currentLead;
    }

    public void SetupRace()
    {
        //reset this object's variables
        state = 0;
        currentLead = 0;
        currentProgress = 0;
        timeElapsed = 0;
        //teleport the player object to the start of the track
        player.transform.position = spawnPoint.transform.position;
        //reset RingManager
        ringManager.ResetTrack();

    }
    
    public void StartRun()
    {
        state = 1;
        ringManager.StartRun();

        //start tracking run
        if (recordGhost != null) { recordGhost.Begin(); }

        //spawn ghost - TODO
        //some temporary testing
        Score s = scoreManager.GetScore(false, 0);
        if (s != null && ghostPrefab1 != null)
        {
            GameObject g = Instantiate(ghostPrefab1);
            g.GetComponent<Ghost>().record = s.ghostRecord;
        }
    }

    public override void RunCompleted(float runDuration, List<float> timeList, GameObject player)
    {
        Debug.Log("TimeTrialManager: Run completed. duration: " + runDuration);
        state = 2;
        //stop tracking
        if (recordGhost != null){ recordGhost.Stop(); }
        //store data about past run
        StoreRun(runDuration, timeList);
        //reset race
        SetupRace();

    }

    //respawn the player at the last tagged ring
    public void ResetCheckpoint()
    {
        player.transform.position = ringManager.CurrentRing().transform.position;
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

        Record record = null;
        if (recordGhost != null)
        {
            record = recordGhost.record;
        }

        Score thisRun = (Score)ScriptableObject.CreateInstance("Score");
        thisRun.Construct(runDuration, Score.cloneFloatList(timeList), record); //for now
        thisRun.trackName = ringManager.trackRoot.name;
        thisRun.nickname = player.name;
        if (scoreManager)
        {
            scoreManager.AddScore(thisRun);
        }
        
    }

    //called when a ring is tagged
    public override void RingTagged()
    {

    }

}
