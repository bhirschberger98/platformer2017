using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadzone=-3;
    public bool canfly=false;

    public Weapon currentWeapon;
    private List<Weapon> weapons = new List<Weapon>();

    new Rigidbody2D rigidbody;
    GM _GM;
    public Vector3 startingPosition;

    private Animator anim;
    public bool air;
    public bool inwater=false;
    private SpriteRenderer sr;

    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();

        anim = GetComponent<Animator>();
        air = false;
        sr = GetComponent<SpriteRenderer>();
    }
    
	// Update is called once per frame
	void FixedUpdate ()  {
        // Apply Movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if ((v.x != 0)&&(air==false))
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (v.x > 0)
        {
            sr.flipX = false;
        }
        else if (v.x < 0)
        {
            sr.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && (v.y == 0 || canfly==true))
        {
            v.y = jumpSpeed;
        }

        if ((v.y != 0)&&(air==true))
        {
            anim.SetBool("Air", true);
        }
        else
        {
            anim.SetBool("Air", false);
        }
        if ((inwater==true)&& (v.y != 0))
        {
            anim.SetBool("inWater", true);
            
        }
        else
        {
            anim.SetBool("inWater", false);
        }

        rigidbody.velocity = v;

        // Attack with a weapon if you have one
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            int i=(weapons.IndexOf(currentWeapon)+1)%weapons.Count;
            SetCurrentWeapon(weapons[i]);
        }

        // Check for out
        if (transform.position.y < deadzone)
        {
            Debug.Log("Current Position " + transform.position.y + " is lower than " + deadzone);
            Getout();
        }

        //rigidbody.AddForce(new Vector2(x * speed, 0));
    }

    public void Getout()
    {
        _GM.Setlives(_GM.GetLives()- 1);
        inwater = false;
        transform.position = startingPosition;
        Debug.Log("You're out");
    }
    public void Powerup()
    {
        anim.SetTrigger("powered");
    }
    public void AddWeapon(Weapon W)
    {
        weapons.Add(W);
        SetCurrentWeapon(W);
    }
    public void SetCurrentWeapon(Weapon W)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = W;

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        air = false;
        var weapon = coll.gameObject.GetComponent<Weapon>();
        if (weapon != null)
        {
            weapon.GetPickedUp(this);
            
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        air = true;
    }
}