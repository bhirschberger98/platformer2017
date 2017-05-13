using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    GM _GM;

    new Rigidbody2D rigidbody;

    public float distance = 2f;
    public float speed = 1f;
    float actualspeed = 9f;
    float posx;
    float posy;
    public bool movex;
    public bool movey;
    private Animator goomba;
    public bool stun;
    private SpriteRenderer sr;

    void Start()
    {
        posy = transform.position.y;
        posx = transform.position.x;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
        actualspeed = -speed;
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (!enabled)
        {
            return;
        }
		var player = coll.gameObject.GetComponent<Player> ();
        if (player != null)
        {
            player.Getout();
        }
	}

    // Update is called once per frame
    public void Update()
    {
        if (movex == true)
        {
            if (posx - transform.position.x > distance)
            {
                actualspeed = speed;
                sr.flipX = true;
            }
            else if ((posx - transform.position.x < -distance))
            {
                actualspeed = -speed;
                sr.flipX = false;
            }
            transform.Translate(actualspeed * Time.deltaTime, 0, 0);
        }
        if (movey == true)
        {
            if (posy - transform.position.y > distance)
            {
                actualspeed = speed;


            }
            else if ((posy - transform.position.y < -distance))
            {
                actualspeed = -speed;

            }
            transform.Translate(0, actualspeed * Time.deltaTime, 0);
        }
    }
}