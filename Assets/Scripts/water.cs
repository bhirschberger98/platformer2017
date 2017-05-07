using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {
    public int water_drag = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered into water");
        var player = collision.gameObject.GetComponent<Player>();
        player.inwater = true;
        player.speed = player.speed - water_drag;
        if (player != null)
        {
            player.canfly = true;
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited water");     
        var player = collision.gameObject.GetComponent<Player>();
        player.inwater = false;
        player.speed = player.speed + water_drag;
        if (player != null)
        {
            player.canfly = false;            
        }
    }
}