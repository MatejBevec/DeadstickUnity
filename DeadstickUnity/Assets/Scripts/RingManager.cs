using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{

    public GameObject trackRoot;
    public GameObject ringPrefab;
    public List<GameObject> ringList;
    private int length;
    private int progress;

    // Start is called before the first frame update
    void Start()
    {   
        //instanciate a new track from the rings attached to this opject
        //trackRoot = gameObject;
        InstantiateTrack(trackRoot);
        length = ringList.Count;
        progress = 0;
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

    //return pointer to the ring at given index
    public GameObject FindRing(int index)
    {
        return ringList[index];
    }

    //return index of the given ring
    public int FindIndex(GameObject ring)
    {
        return ringList.IndexOf(ring);
    }

    public void TagAll()
    {
        foreach (GameObject ring in ringList){
            ring.GetComponent<Ring>().Tag();
        }
    }

    public void UntagAll()
    {
        foreach (GameObject ring in ringList)
        {
            ring.GetComponent<Ring>().Untag();
        }
    }

    //is called when a ring collision happens (to be improved)
    public void RingCollided(GameObject ring, Collider other)
    {
        Debug.Log("RingCollided called " + FindIndex(ring) + " " + progress);
        if (CheckColValidity(ring, other))
        {
            HandleValidCol(ring);
        }
    }

    private bool CheckColValidity(GameObject ring, Collider other)
    {
        if (FindIndex(ring) == progress)
        {
            return true;
        }
        else {return false;}
    }

    private void HandleValidCol(GameObject ring)
    {
        Debug.Log(ring.GetComponent<Ring>());
        ring.GetComponent<Ring>().Tag();
        if (progress >= length - 1)
        {
            HandleCompletedTrack();
        }
        else
        {
            progress++;
        }
    }

    private void HandleCompletedTrack()
    {

    }
}
