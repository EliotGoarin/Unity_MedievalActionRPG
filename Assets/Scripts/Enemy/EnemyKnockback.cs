using UnityEngine;
using System.Collections;

public class EnemyKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private Ennemy_Moving enemyMoving;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMoving = GetComponent<Ennemy_Moving>();
    }
    public void Knockback(Transform player, float force, float knockbackTime, float stunTime)
    {
        enemyMoving.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - player.position).normalized;
        rb.linearVelocity = direction * force;
    }

    IEnumerator StunTimer(float knockbackTime,float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMoving.ChangeState(EnemyState.Idle);
    }

}
