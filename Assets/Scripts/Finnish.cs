using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Finnish : MonoBehaviour {
    public string holename;
    public static int stroke = 0;
    Text text;

    void Awake()
    {
        holename = ScoreCard.holenames[ScoreCard.currenthole - 1];
        text = GetComponent<Text>();
        foreach (int i in ScoreCard.strokes)
        {
            stroke += i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "It took you " + stroke + " strokes to finish the course";
    }
}
