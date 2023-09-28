using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public static int bulletDamage = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    public static void bullletDamageUp()
    {
        bulletDamage++;
    }

    void OnCollisionEnter2D(Collision2D collision)
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
