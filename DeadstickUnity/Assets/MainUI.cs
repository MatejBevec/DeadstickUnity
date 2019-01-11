using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{

    public float time;
    public Text timeText;

    public int progress;
    public int length;
    public Text progressText;

    public float lead;
    public Text leadText;

    private void Start()
    {
        time = 0f;
        progress = 0; length = 0;
        lead = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        timeText.text = time.ToString("0.0") + " s";
        progressText.text = progress + "/" + length;
        if (lead > 0)
        {
            leadText.text = "+ " + lead.ToString("0.0") + " s";
            leadText.color = Color.red;
        }
        else
        {
            leadText.text = lead.ToString("0.0") + " s";
            leadText.color = Color.green;
        }
    }
}
