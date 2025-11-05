using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public float cooldown = 1;
    private float timer;

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

    public void EndAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
