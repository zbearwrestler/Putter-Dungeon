using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {
    public string holename;
    public static int stroke;
    Text text;

    void Start()
    {
        holename = ScoreCard.holenames[ScoreCard.currenthole -1];
        stroke = 0;
        text = GetComponent<Text>();

    }

    public static void Hit()
    {
        stroke++;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Hole: " + holename + "\t\tStrokes: " + stroke;
    }
}
