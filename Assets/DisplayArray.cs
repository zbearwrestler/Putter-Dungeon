using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayArray : MonoBehaviour {

    public int[] Hole = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
    public int[] Record = new int[] { 2, 2, 3, 3, 2, 3, 2, 5, 2};
    public int[] par;
    public int[] strokes;
    public int[] plusminus;
    public Text[] txtHolenum = new Text[9];
    public Text[] txtPar = new Text[9];
    public Text[] txtStroke = new Text[9];
    public Text[] txtPlusMinus = new Text[9];
    public Text[] txtRecord = new Text[9];
    public int currenthole;

    // Use this for initialization
    void Start () {
        par = ScoreCard.par;
        strokes = ScoreCard.strokes;
        plusminus = ScoreCard.plusminus;
        currenthole = ScoreCard.currenthole;


        for (int i = 0; i < Hole.Length; i++)
        {
            txtHolenum[i].text = "" + Hole[i];
            txtPar[i].text = "" + par[i];
            txtRecord[i].text = "" + Record[i];
            if (i > currenthole)
            {

                txtStroke[i].text = "";
                txtPlusMinus[i].text = "";
            }
            else
            {
                txtStroke[i].text = "" + strokes[i];
                txtPlusMinus[i].text = "" + plusminus[i];
            }
        }

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoreCard.Next();
        }
    }
}
