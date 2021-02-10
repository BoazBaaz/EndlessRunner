using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float m_MovementInput; //the raw movement input
    [Range(0f, 10f)]
    public float m_VelocityDecrease = 5.0f; //the decrease value used to decrease the velocity
    public float m_MovementForce = 10.0f; //the movement force of the player
    public float m_JumpForce = 8.0f; //the jump force of the player
    public Transform jumpCheckA; //point A for the ground check collider
    public Transform jumpCheckB; //point B for the ground check collider

    //private
    private Rigidbody2D rb2D; //the 2D rigidbody

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_MovementInput = Input.GetAxisRaw("Horizontal");

        //decrease the velocity if you are going the other way.
        if (m_MovementInput < 0 && rb2D.velocity.x > 0 || m_MovementInput > 0 && rb2D.velocity.x < 0)
            rb2D.velocity += new Vector2(-(rb2D.velocity.x / m_VelocityDecrease), 0f);

        //make a jump check
        Collider2D groundCheck = Physics2D.OverlapArea(jumpCheckA.position, jumpCheckB.position);

        //add force upward * m_jumpforce, if groundcheck != null and is the ground
        if (Input.GetButtonDown("Jump") && groundCheck != null)
            if (groundCheck.gameObject.layer == LayerMask.NameToLayer("Ground"))
                rb2D.AddForce(Vector3.up * m_JumpForce, ForceMode2D.Impulse);

        if (transform.position.y <= -7.0f)
        {
            GameManager.instance.ShowDeathScreen();
        }
    }

    void FixedUpdate()
    {
        //move the player on the x axis
        rb2D.AddForce(Vector2.right * m_MovementInput * m_MovementForce, ForceMode2D.Force);
    }

}
