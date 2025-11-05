using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public float cooldown = 1;
    private float timer;
    public Transform attackPoint;
    public float weaponRange = 1f;
    public LayerMask enemyLayer;
    public int damage = 1;


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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (hitEnemies.Length >0)
        {
            EnnemyHealth ennemyHealth = hitEnemies[0].GetComponent<EnnemyHealth>();
            if (ennemyHealth != null)
            {
                ennemyHealth.ChangeHealth(-damage);
            }
        }
    }

    public void EndAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
