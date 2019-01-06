using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public List<GameObject> Rings;
    public GameObject ringPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //for testing - generate some rings
        int numRings = 10;
        int offset = 10;
        for (int i = 0; i < numRings; i++)
        {
            int x = Random.Range(-offset,offset);
            int y = Random.Range(-offset, offset);
            GameObject newRing  = Instantiate(ringPrefab, new Vector3(x,y,(i+1)*50), Quaternion.identity);
            newRing.name = "Ring" + i;
            Rings.Add(newRing);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //return pointer to the ring at given index
    public GameObject FindRing(int index)
    {
        return Rings[index];
    }

}
