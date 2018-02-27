using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

    public float speed = 3;
    public Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Destroy()
    }
        // Update is called once per frame
        void Update () {
        rb2D.velocity = transform.up * speed;
	}
}
