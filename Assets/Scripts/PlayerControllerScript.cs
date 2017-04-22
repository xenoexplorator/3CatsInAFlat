using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;               // Condition for whether the player should jump.
    
    public float moveForce = 10f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 3f;             // The fastest the player can travel in the x axis.
    public AudioClip[] jumpClips;           // Array of clips for when the player jumps.
    public float jumpForce = 30f;         // Amount of force added when the player jumps.

    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;
    private bool Grounded
    {
        get { return grounded;}
        set {
            if ((value == true) && value != grounded)
            {
                if (anim != null)
                    if((rb != null) && rb.velocity.y < 0)
                        anim.SetTrigger("FallStop");
            }
            grounded = value;
            }
    }
    private Animator anim;                  // Reference to the player's animator component.
    private List<CollectableType> inventory = new List<CollectableType>();
	 private Transform inventoryDisplay;
    private Rigidbody2D rb;


    private bool search = false;
    

    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
		  inventoryDisplay = transform.Find("ItemList");
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        Grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Grounded)
        {
            if (Input.GetKeyDown("space"))
            {
                
                jump = true;
            }
        }
        if (rb.velocity.y == 0)
        {
            anim.ResetTrigger("FallStop");
        }
    }


    void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(h));

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            // ... add a force to the player.
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();

        // If the player should jump...
        if (jump)
        {
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("Jump");

            // Play a random jump audio clip.
            //int i = Random.Range(0, jumpClips.Length);
            //AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }
        if (search)
        {

            search = false;
        }
    }



    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

		  // Save inventory display position
		  Vector3 inventoryPosition = inventoryDisplay.position;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

		  // Restore inventory display position
		  inventoryDisplay.position = inventoryPosition;
		  inventoryDisplay.localScale = theScale * 16.0f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (collision.gameObject.tag == "Collectible")
            {
                anim.SetTrigger("Search");
                collision.gameObject.SendMessage("TakeItem", this, SendMessageOptions.RequireReceiver);
            }
            else if (collision.gameObject.tag == "Objective")
            {
                anim.SetTrigger("Search");
                collision.gameObject.SendMessage("Interact", this, SendMessageOptions.RequireReceiver);
            }
            else if (collision.gameObject.tag == "Door")
            {
                collision.gameObject.SendMessage("Interact", this, SendMessageOptions.RequireReceiver);
            }
        }
		  else if (Input.GetKeyDown(KeyCode.LeftControl))
		  {
			   collision.gameObject.SendMessage("Examine", SendMessageOptions.RequireReceiver);
		  }
    }

    public void AddItem(CollectableType item)
    {
        Debug.Log("take this");
        if (!this.inventory.Contains(item)) {
            this.inventory.Add(item);
		  }
    }

    public void RemoveItem(CollectableType item)
    {
        this.inventory.Remove(item);
    }

    public bool HasItem(CollectableType item)
    {
        return this.inventory.Contains(item);
    }
}
