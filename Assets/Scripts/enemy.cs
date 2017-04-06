using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll){
		var player = coll.gameObject.GetComponent<Player> ();
        if (player != null)
        {
            player.Getout();
        }
	}

}
