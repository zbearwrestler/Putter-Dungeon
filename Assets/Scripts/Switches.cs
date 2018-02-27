using UnityEngine;
using System.Collections;

public class Switches : MonoBehaviour {

    public static Animator anim;
    public static bool uppered;
    public static BoxCollider2D hitme;
    public static GameObject[] blocks;
    public static Animator[] blockanims;
    public static BoxCollider2D[] blockcollids;


	// Use this for initialization
	void Start () {
        if (blocks == null)
        {
            blocks = GameObject.FindGameObjectsWithTag("Switch Blocks");
            blockanims = new Animator[blocks.Length];
            blockcollids = new BoxCollider2D[blocks.Length];
            for (int i = 0; i < blocks.Length; i++)
            {
                blockanims[i] = blocks[i].GetComponent<Animator>();
                blockcollids[i] = blocks[i].GetComponent<BoxCollider2D>();
                blockanims[i].SetBool("Up?", blockcollids[i].enabled);
            }
        }
        /*
        anim = gameObject.GetComponent<Animator>();
        uppered = gameObject.GetComponent<BoxCollider2D>().enabled;
        if(uppered)
        {
            anim.SetBool("Up?", uppered);
        }
        hitme = gameObject.GetComponent<BoxCollider2D>();*/
	}

    public static void Switch()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blockanims[i].GetBool("Up?"))
            {
                blockanims[i].SetBool("Up?", false);
                blockcollids[i].enabled = false;
            }
            else
            {
                blockanims[i].SetBool("Up?", true);
                blockcollids[i].enabled = true;
            }
        }
    }
        /*
        if(uppered)
        {
            anim.SetBool("Up?", false);
            hitme.enabled = false;
            uppered = false;
        }
        else
        {
            anim.SetBool("Up?", true);
            hitme.enabled = true;
            uppered = true;
        }*/
}
