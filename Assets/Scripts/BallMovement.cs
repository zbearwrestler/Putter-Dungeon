using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {

    private Vector2 releasePosition;
    private Vector2 startPosition;
    private bool clickStart;
    private float forceMultiplier = 100;
    private float slopeForce = 1;
    public Vector2 forcehit;
    public float magnitude;
    public Rigidbody2D rb2D;
    public int strokes;
    public Slider aimSlider;
    public Canvas slidercanvas;
    public GameObject aimer;
    public SpriteRenderer seeStick;
    public GameObject[] switchfloor;

    // Use this for initialization
    void Start() {
        clickStart = false;
        rb2D = GetComponent<Rigidbody2D>();
        strokes = 0;
        aimer = GameObject.Find("AimingStick");
        if (switchfloor == null)
        {
            switchfloor = GameObject.FindGameObjectsWithTag("Switch Blocks");
        }
    }


    void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            startPosition= gameObject.transform.position;
            clickStart = true;
        }

    }

    void OnMouseUp()
    {
        if (clickStart)
        {
            forcehit = (gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)) *forceMultiplier;
            magnitude = forcehit.magnitude;
            rb2D.AddForce((gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)) * forceMultiplier);
            strokes++;
            ScoreCard.Hit();
            aimSlider.value = 0;
            clickStart = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            Destroy(coll.gameObject);
            ScoreCard.UpdateScore();
            ScoreCard.Finish();
        }
        if (coll.gameObject.tag == "Water")
        {
            strokes++;
            ScoreCard.Hit();
            gameObject.transform.position = startPosition;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (coll.gameObject.tag == "Switch")
        {
            Switches.Switch();
        }
        if (coll.gameObject.tag == "Enemy")
        {
            rb2D.AddForce((coll.transform.position - rb2D.transform.position) * forceMultiplier);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Key")
        {
            Destroy(coll.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Gate"));
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Slope Right")
        {
            rb2D.AddForce(Vector2.right * slopeForce);
        }
        if(coll.gameObject.tag == "Slope Left")
        {
            rb2D.AddForce(Vector2.right * -slopeForce);
        }
        if(coll.gameObject.tag == "Slope Up")
        {
            rb2D.AddForce(Vector2.up * slopeForce);
        }
        if(coll.gameObject.tag == "Slope Down")
        {
            rb2D.AddForce(Vector2.up * -slopeForce);
        }
    }
    // Update is called once per frame
    void Update () {
	    if(clickStart)
        {
            Vector2 farpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 temp = (startPosition - farpoint);
            magnitude = temp.magnitude;
            aimSlider.value = magnitude;
            float diffx = farpoint.x - gameObject.transform.position.x;
            float diffy = farpoint.y - gameObject.transform.position.y;
            float angle = Mathf.Rad2Deg * Mathf.Atan(diffy / diffx);
            if (diffx > 0)
            {
                angle = 180 + angle;
            }
            aimSlider.transform.eulerAngles = new Vector3(0, 0, angle);
           // slidercanvas.transform.eulerAngles = new Vector3 (0, 0, angle);
            
        }
    }
}
