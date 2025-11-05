using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    [Header("Combat Stats")]
    public int damage;
    public int weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public float speed;
    
    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
