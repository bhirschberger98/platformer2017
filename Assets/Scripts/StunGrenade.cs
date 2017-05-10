using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGrenade : Throwable {

    public float blastRadius = 5;
    private Animator goomba; 
    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (isActive && player == null)
        {
            Explode();
        }
    }

    public void Explode() {
        //  Get a reference to all enemies
        goomba = GetComponent<Animator>();
        var enemies = FindObjectsOfType<enemy>();

        //  Loop through each enemy in the list
        foreach (var e in enemies) {

            if (Vector3.Distance(this.transform.position, e.transform.position) < blastRadius)
            {
               StartCoroutine(stun(e));
            }
        }
        collider2D.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

   IEnumerator stun(enemy e)
    {
        var renderer = e.GetComponent<SpriteRenderer>();
        //goomba.enabled = false;
        e.enabled = false;
        renderer.color = new Color(1, 1, 1, .4f);
        yield return new WaitForSeconds(5);
        e.enabled = true;
        renderer.color = new Color(1, 1, 1, 1);
        //goomba.enabled = true;
    }
}