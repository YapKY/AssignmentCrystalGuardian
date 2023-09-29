using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 3f;

    private float expAmount = 20;
    private float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; // 3-> 2 ->1 -> 0 = Enemy has died

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ExperienceManager.Instance.AddExperince(expAmount);
        EnemySpawner.onEnemyKilledOrDestroy.Invoke();
        Destroy(this.gameObject);
        EnemyKillCount.countKill++;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CrystalHealthBar>())
        {
            collision.gameObject.GetComponent<CrystalHealthBar>().CrystalTakeDamage(damage);
            EnemySpawner.onEnemyKilledOrDestroy.Invoke();
            Destroy(this.gameObject);
        }


    }

}
