using UnityEngine;
using System.Collections;

public class TowerFire : MonoBehaviour {

    public Vector3 rotationspeed;
    public int firerate;
    public GameObject projectile;
    public float fireforce;
    public int timer = 0;


    // Use this for initialization
    void Start()
    {

    } 

	void FixedUpdate () {
        transform.Rotate(rotationspeed);
        timer++;
        if(timer > firerate)
        {
            timer = 0;
            GameObject obj = Instantiate(projectile, transform.localPosition, transform.rotation) as GameObject;
            Destroy(obj, 0.7f);
        }
	}
}
