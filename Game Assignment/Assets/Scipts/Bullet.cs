using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public static float bulletDamage = 1f;

    // Update is called once per frame
    private void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    public static void UpdateDamage()
    {
        bulletDamage++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(this.gameObject);
        /// enemies to take damage
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyCompenent))
        {
            enemyCompenent.TakeDamage(bulletDamage);
        }
    }
}
