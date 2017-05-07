using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {
    GM _GM;
    private void Start()
    {
        _GM = FindObjectOfType<GM>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _GM.Setlives(_GM.GetLives() + 1);
        gameObject.SetActive(false);
    }
}
