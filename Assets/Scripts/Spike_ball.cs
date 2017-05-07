using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_ball : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        player.Getout();
    }
}
