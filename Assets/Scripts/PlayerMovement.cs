using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public Animator anim;
    public int facingDirection = 1; // 1 for right, -1 for left
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (moveX > 0 && transform.localScale.x < 0 || moveX < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        anim.SetFloat("moveX", Mathf.Abs(moveX));
        anim.SetFloat("moveY", Mathf.Abs(moveY));

        rb.linearVelocity = new Vector2(moveX, moveY) * speed;
    }
    
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
