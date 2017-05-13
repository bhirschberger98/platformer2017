using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
    public GameObject YouWin;

    public void OnTriggerEnter2D(Collider2D collisionwin)
    {
        var player = collisionwin.gameObject.GetComponent<Player>();
        YouWin.SetActive(true);
    }
}
