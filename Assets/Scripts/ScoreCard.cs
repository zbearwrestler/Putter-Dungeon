using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreCard : MonoBehaviour {

    public static ScoreCard control;
    public static int courselength = 9;
    public static int[] par = new int[] { 3, 3, 5, 5, 3, 5, 3, 8, 3};
    //                                  { 2, 2, 3, 3, 2, 3, 2, 5, 2};
    public static int[] strokes = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public static int[] plusminus = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0};
    public static string[] holenames = new string[] { "1 - Dungeon Entrance", "2 - Switches Galore", "3 - Not So Empty After All", "4 - Locked Doors", "5 - Waterworks", "6 - Turret Trouble", "7 - Final Hallway", "8 - Around The Bend", "9 - Locked Up"};
    public static int currenthole = 1;
    public static int currentstroke = 0;



    // Use this for initialization
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

        //If Arrays are empty initilize them.
        if (strokes.Length < 1)
        {
            strokes = new int[courselength];
            plusminus = new int[courselength];

        }
        //currenthole = SceneManager.GetActiveScene().buildIndex;
    }

    public static void UpdateScore()
    {
        strokes[currenthole] = currentstroke;
        plusminus[currenthole] = par[currenthole] - currentstroke;

        currentstroke = 0;
    }

    public static void Hit()
    {
        currentstroke++;
        DisplayScore.Hit();
    }

    public static void Finish()
    {
        Debug.Log(currenthole);
        currenthole++;
        Debug.Log(currenthole);
        SceneManager.LoadScene(11);
    }

    public static void Next()
    {
        Debug.Log("Going to " + currenthole);
        SceneManager.LoadScene(currenthole);
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(5);
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            SceneManager.LoadScene(6);
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            SceneManager.LoadScene(7);
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            SceneManager.LoadScene(8);
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            SceneManager.LoadScene(9);
        }
    }


}
