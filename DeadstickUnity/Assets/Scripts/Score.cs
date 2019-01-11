using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : ScriptableObject //maybe just go with a normal class ?
{
    public float time;
    public List<float> timeList;
    //public GameObject ghost;
    public Record ghostRecord;

    public string nickname;

    //maybe later
    public GameObject trackObject; //a pointer to the track on which this score was set
    public string trackName;
    public GameObject playerObject; //which player object / plane was this score achieved with

    //gamemode stuff
    public string gamemode;
    public static string TIMETRIAL = "TimeTrial";
    public static string SPLITSCREEN = "SplitScreen";

    //constructor
    /*
    public Score(float time, List<float> timeList)
    {
        this.time = time;
        this.timeList = timeList;
    }
    */

    public void Construct(float time, List<float> timeList, Record record)
    {
        this.time = time;
        this.timeList = timeList;
        this.ghostRecord = record;
    }

    public static int CompareScores(Score x, Score y)
    {
        return (int) Mathf.Sign(x.time - y.time);
    }

    //clone a list (here temporararily)
    public static List<float> cloneFloatList(List<float> list)
    {
        List<float> newList = new List<float>();
        foreach (float f in list)
        {
            newList.Add(f);
        }
        return newList;
    }

}
