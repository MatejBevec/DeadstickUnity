using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{

    public GameObject trackRoot;
    public GameObject ringPrefab;
    public List<GameObject> ringList;
    public List<float> timeList; //time elapsed from the start of the run when a specific ring is tagged
    [HideInInspector]
    public int length;
    [HideInInspector]
    public int progress;
    private float startTime;
    private float runDuration;
    private bool started;

    public GameModeManager myManager;
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {   
        //instanciate a new track from the rings attached to this opject
        //trackRoot = gameObject;
        InstantiateTrack(trackRoot);
        length = ringList.Count;
        progress = 0;
        startTime = 0f;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //creates and stores the rings based on the track created in the editor
    private void InstantiateTrack(GameObject root)
    {
        foreach (Transform child in root.transform)
        {
            //create new ring at the transform of the placeholder
            GameObject newRing = Instantiate(ringPrefab, child);
            Destroy(child.gameObject);
            newRing.transform.SetParent(transform);
            newRing.GetComponent<Ring>().myManager = this;
            newRing.name = "ring" + ringList.Count; ;
            ringList.Add(newRing);
        }
    }

    //is called when the race starts
    public void StartRun()
    {
        startTime = Time.fixedTime;
        started = true;
        //perhaps implement a start flag
    }

    //return pointer to the ring at given index
    public GameObject FindRing(int index)
    {
        return ringList[index];
    }

    public GameObject CurrentRing()
    {
        return ringList[progress];
    }

    //return index of the given ring
    public int FindIndex(GameObject ring)
    {
        return ringList.IndexOf(ring);
    }

    //untags all rings and updates manager accordingly
    public void ResetTrack()
    {
        foreach (GameObject ring in ringList)
        {
            ring.GetComponent<Ring>().Untag();
        }
        progress = 0;
        startTime = Time.fixedTime;
        runDuration = 0;
        timeList.Clear();
        started = false;
    }

    //is called when a ring collision happens (to be improved)
    public void RingCollided(GameObject ring, Collider other)
    {
        if (CheckColValidity(ring, other))
        {
            HandleValidCol(ring);
        }
    }

    private bool CheckColValidity(GameObject ring, Collider other)
    {
        if (started && FindIndex(ring) == progress && (other.gameObject == myPlayer || myPlayer == null))
        {
            return true;
        }
        else {return false;}
    }

    private void HandleValidCol(GameObject ring)
    {
        ring.GetComponent<Ring>().Tag();
        timeList.Add(Time.fixedTime - startTime);
        progress++;
        Debug.Log("RingManager: Ring (" + FindIndex(ring) + ") tagged, progress: " + progress + "/" + length);
        if (progress >= length)
        {
            HandleCompletedTrack();
        }
        
    }

    private void HandleCompletedTrack()
    {
        runDuration = Time.fixedTime - startTime;
        if (myManager)
        {
            myManager.RunCompleted(runDuration, timeList, myPlayer);
        }
    }
}
