using UnityEngine;

public class Ennemy_Moving : MonoBehaviour
{
    private EnemyState enemyState, newState;
    public float speed = 1;
    private int facingDirection = 1;
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);

    }

    public void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {
            if (player.position.x > transform.position.x && facingDirection == -1 || player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            }
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            rb.linearVelocity = direction * speed;
        }
    }



    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
        
    }

    void ChangeState(EnemyState newState)
    {
        // Exit the current animation
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }
        // Update the new state
        enemyState = newState;

        // Update the new animation
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }

    }

}


public enum EnemyState
{
    Idle,
    Chasing,
    Attacking
}