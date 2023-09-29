using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Left : MonoBehaviour
{
    [Header("EnemyPhysicsElement")]
    [SerializeField] private Rigidbody2D rb;

    [Header("EnemyAttributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform targetPoint;
    private int movePointCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        targetPoint = EnemyManager.main.pointStraightLeft[movePointCount];

    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(targetPoint.position, transform.position) <= 0.1f)
        {
            movePointCount++;

            if (movePointCount != EnemyManager.main.pointStraightLeft.Length)
            {
                targetPoint = EnemyManager.main.pointStraightLeft[movePointCount];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 enemyDirection = (targetPoint.position - transform.position).normalized;
        rb.velocity = enemyDirection * moveSpeed;
    }
}
