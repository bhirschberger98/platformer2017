using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingbooster : MonoBehaviour {

    float timestarted=0;
    Player player;

    public float lastsforseconds = 10;

    void OnCollisionEnter2D(Collision2D coll)
    {
        player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.canfly = true;
            gameObject.GetComponent<Collider2D>().enabled=false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            timestarted = Time.time;

            player.Powerup();
        }
    }
    private void Update()
    {
        if (timestarted != 0&&timestarted+ lastsforseconds > Time.time)
        {
            timestarted = 0;
            player.canfly = false;
        }
    }
}