using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered into water");
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.canfly = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited water");
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.canfly = false;
        }
    }
}