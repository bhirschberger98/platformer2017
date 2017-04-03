using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadzone=-3;

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()  {
        //movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if (Input.GetButtonDown("Jump"))
        {
            v.y = jumpSpeed;
        }

        rigidbody.velocity = v;

        if (transform.position.y < deadzone)
        {
            
            Getout();
        }
        
        //rigidbody.AddForce (new Vector2(x * speed, 0));
    }
    public void Getout()
    {
        _GM.Setlives(_GM.GetLives()- 1);
        transform.position = startingPosition;
        Debug.Log("You're out");
    }
}
