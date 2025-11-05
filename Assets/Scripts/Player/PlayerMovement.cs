using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private bool isKnockedBack = false;
    public int facingDirection = 1; // 1 for right, -1 for left

    public PlayerCombat playerCombat;


    void Update()
    {
        if (Input.GetButtonDown("Slash"))
        {
            playerCombat.Attack();
        }
        
        if (isKnockedBack == false)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            if (moveX > 0 && transform.localScale.x < 0 || moveX < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("moveX", Mathf.Abs(moveX));
            anim.SetFloat("moveY", Mathf.Abs(moveY));

            rb.linearVelocity = new Vector2(moveX, moveY) * StatsManager.Instance.speed;
        }

    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }
    
    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
