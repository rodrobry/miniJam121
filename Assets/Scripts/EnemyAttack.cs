using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float missileSpeed = 7f;
    public float attackSpeed = 2f;
    public GameObject plateObject;
    public GameObject player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("Attack", 2f, attackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        if(player == null) return;
        animator.Play("MageAttack");
        Invoke("Fire", 0.1f);
        Invoke("ResetAnim", 0.3f);
    }

    private void ResetAnim()
    {
        animator.Play("MageIdle");
    }

    private void Fire()
    {
        //Give rotation matching player position
        Vector2 enemyPos = transform.position;
        Vector2 playerPos = player.transform.position;
        Vector2 targetDirection = (playerPos - enemyPos).normalized;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        var plate = Object.Instantiate(plateObject, transform.position, rotation);
        var plateRb = plate.GetComponent<Rigidbody2D>();
        plateRb.AddForce(targetDirection * missileSpeed, ForceMode2D.Impulse);
    }
}
