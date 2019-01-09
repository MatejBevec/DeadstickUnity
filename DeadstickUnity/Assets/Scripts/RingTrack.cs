using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrack : MonoBehaviour
{

    public List<Transform> transformList;
    public GameObject ringPrefab;
    public List<GameObject> ringList;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateTrack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //creates and stores the rings based on the track created in the editor
    private void InstantiateTrack()
    {
        foreach (Transform child in transform)
        {
            Debug.Log(child);
            //copy the transform of the placeholder ring and then destroy it
            Transform newTrans = Instantiate(child);
            Destroy(child.gameObject);
            //create new ring at that transform from prefab
            //newTrans.SetParent(transform);
            Instantiate(ringPrefab, newTrans);

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

    //return the length of this race track
    public int Length()
    {
        return ringList.Count;
    }
}
