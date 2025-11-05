using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public float cooldown = 1;
    private float timer;
    public Transform attackPoint;
    public LayerMask enemyLayer;


    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking", true);

            timer = cooldown;
        }
    }    

    public void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.weaponRange, enemyLayer);

        if (hitEnemies.Length >0)
        {
            EnnemyHealth ennemyHealth = hitEnemies[0].GetComponent<EnnemyHealth>();
            if (ennemyHealth != null)
            {
                ennemyHealth.ChangeHealth(-StatsManager.Instance.damage);
            }
            hitEnemies[0].GetComponent<EnemyKnockback>().Knockback(transform, StatsManager.Instance.knockbackForce,StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime);
        }
    }

    public void EndAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, StatsManager.Instance.weaponRange);
    }
}
