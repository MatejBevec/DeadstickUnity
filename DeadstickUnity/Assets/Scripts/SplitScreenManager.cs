using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenManager : GameModeManager
{

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public RingManager ringManager1;
    public RingManager ringManager2;
    public GameObject player1;
    public GameObject player2;
    private RecordGhost recordGhost1;
    private RecordGhost recordGhost2;
    //might need this
    private bool finished1;
    private bool finished2;

    private Score run1;
    private Score run2;

    //score manager object
    public ScoreManager scoreManager;

    private int state; // 0-start line 1-mid race 2-completed
    private float setupTime; //time when the race is set up
    public float countdownTime;

    public float timeElapsed;

    //UI
    public MainUI UI1;
    public MainUI UI2;

    //metrics
    private float currentLead; //player1 - player 2
    private int sharedProgress; //min(progress1, progress2)

    //ghosts (maybe)
    /*
    public GameObject ghostPrefab1;
    public GameObject ghostPrefab2;
    */


    // Start is called before the first frame update
    void Start()
    {
        ringManager1.myManager = this;
        ringManager2.myManager = this;
        recordGhost1 = player1.GetComponent<RecordGhost>();
        recordGhost2 = player2.GetComponent<RecordGhost>();
        SetupRace();
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        if (state == 1) { timeElapsed = Time.fixedTime- ringManager1.startTime; } // grdo

        //start race when after countdown - TODO
        //temporary - do it with coroutines later
        if (state == 0)
        {
            if (Time.fixedTime - setupTime >= countdownTime)
            {
                //when countdown is finished, start the race
                StartRun();
            }
        }

        //end race when both players are finished - TODO
        if (finished1 && finished2 && state == 1)
        {
            RaceCompleted();
        }

        //player1 lead at prev. ring
        if (ringManager1.progress > sharedProgress && ringManager2.progress > sharedProgress)
        {
            sharedProgress++;
            currentLead = ringManager1.timeList[sharedProgress-1] - ringManager2.timeList[sharedProgress-1];
            Debug.Log("lead:" + currentLead);
        }

        //update UI
        if (UI1 != null)
        {
            UI1.time = timeElapsed;
            UI1.progress = ringManager1.progress;
            UI1.length = ringManager1.length;
            UI1.lead = currentLead;
        }
        if (UI2 != null)
        { 
            UI2.time = timeElapsed;
            UI2.progress = ringManager1.progress;
            UI2.length = ringManager1.length;
            UI2.lead = -currentLead;
        }

    }

    public void SetupRace()
    {
        //reset this object's variables
        state = 0;
        currentLead = 0;
        sharedProgress = 0;
        timeElapsed = 0;
        setupTime = Time.fixedTime;
        finished1 = false; finished2 = false;
        //teleport the player object to the start of the track
        player1.transform.position = spawnPoint1.transform.position;
        player2.transform.position = spawnPoint2.transform.position;
        //disable player controls - TODO
            /*
            player1.GetComponent<InputControl>().DisableInput();
            player1.GetComponent<InputControl>().DisableInput();
            */
        //reset RingManager
        ringManager1.ResetTrack();
        ringManager2.ResetTrack();
        
        //now wait for the timer to finish (to be updated)
    }

    public void StartRun()
    {
        state = 1;
        ringManager1.StartRun();
        ringManager2.StartRun();
        //enable player controls - TODO
        /*
        player1.GetComponent<InputControl>().EnableInput();
        player1.GetComponent<InputControl>().EnableInput();
        */
        //start tracking run
        Debug.Log("GO!");
        if (recordGhost1 != null) { recordGhost1.Begin(); }
        if (recordGhost2 != null) { recordGhost2.Begin(); }
    }

    public override void RunCompleted(float runDuration, List<float> timeList, GameObject player)
    {
        if (player == player1 || player == player2)
        {
            //set finished flags
            if (player == player1) { finished1 = true; Debug.Log("Player1 finished"); }
            if (player == player2) { finished2 = true; Debug.Log("Player2 finished"); }
            //stop tracking
            player.GetComponent<RecordGhost>().Stop();
            //store data about past run
            StoreRun(runDuration, timeList, player);
        }

    }

    public void RaceCompleted()
    {
        state = 2;
        //announce winner and other stuff - TODO
        Debug.Log(Winner() + " won !");
        //reset race
        SetupRace();
    }

    //temporary
    public string Winner()
    {
        if(run1.time < run2.time) { return player1.name; }
        else { return player2.name; }
    }

    //respawn the player at the last tagged ring
    public void ResetCheckpoint(GameObject player)
    {
        if(player == player1)
        {
            player1.transform.position = ringManager1.CurrentRing().transform.position;
        }
        if (player == player2)
        {
            player2.transform.position = ringManager2.CurrentRing().transform.position;
        }
    }

    //store current run as a Score object in the ScoreManager
    public void StoreRun(float runDuration, List<float> timeList, GameObject player)
    {

        Record record = player.GetComponent<RecordGhost>().record;

        Score thisRun = (Score)ScriptableObject.CreateInstance("Score");
        thisRun.Construct(runDuration, Score.cloneFloatList(timeList), record); //for now
        thisRun.nickname = player.name;
        if (scoreManager)
        {
            scoreManager.AddScore(thisRun);
        }

        if (player == player1) { run1 = thisRun; };
        if (player == player2) { run2 = thisRun; };

    }

    //called when a ring is tagged
    public override void RingTagged()
    {

    }

}
