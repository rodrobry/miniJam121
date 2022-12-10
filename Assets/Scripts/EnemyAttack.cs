using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float missileSpeed = 7.5f;
    public GameObject plateObject;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Attack()
    {
        //Give rotation matching player position
        Vector2 enemyPos = transform.position;
        Vector2 playerPos = GameObject.FindWithTag("Player").transform.position;
        Vector2 targetDirection = (playerPos - enemyPos).normalized;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        var plate = Object.Instantiate(plateObject, transform.position, rotation);
        var plateRb = plate.GetComponent<Rigidbody2D>();
        plateRb.AddForce(targetDirection * missileSpeed, ForceMode2D.Impulse);
    }
}
