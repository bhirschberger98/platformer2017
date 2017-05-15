using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
    public BoxCollider2D coll2d;
    public float telex;
    public float teley;
    float time;
    float timestarted;
    // Use this for initialization
    void Start () {
        coll2d = GetComponent<BoxCollider2D>();
    }
	
    void OnCollisionStay2D(Collision2D coll)
    {
        float y = Input.GetAxisRaw("Vertical");
        var player = coll.gameObject.GetComponent<Player>();
        if (y < 0)
        {
            Debug.Log("Down");
            this.GetComponent<BoxCollider2D>().enabled = false;
            player.transform.position = new Vector3(telex, teley);
            this.GetComponent<BoxCollider2D>().enabled = true;

        }
    }

}