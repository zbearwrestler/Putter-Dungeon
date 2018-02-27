using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public int force = 20;
    public int dir = 1;
    public int frametime = 0;
    public int framemax = 180;
    public int waittime = 30;
    public bool moving = true;
    public Animator anim;
    public Rigidbody2D rb2D;
    public bool random = false;

	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Movement()
    {
        if (frametime > framemax)
        {
            rb2D.velocity = Vector2.zero;
            dir++;
            if (dir > 4)
                dir = 1;
            anim.SetInteger("Dir", dir);
            if (dir == 1)
            {
                rb2D.velocity = (Vector2.up * force);
            }
            else if (dir == 2)
            {
                rb2D.velocity = (Vector2.right * force);
            }
            else if (dir == 3)
            {
                rb2D.velocity = (Vector2.down * force);
            }
            else
            {
                rb2D.velocity = (Vector2.left * force);
            }
            frametime = 0;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Movement();
        
        Debug.Log(rb2D.velocity);

        frametime++;
	}
}
