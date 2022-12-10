using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int plateAmo = 0;
    public float plateSpeed = 7.5f;
    public GameObject plateObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        //Give the plate a rotation matching the mouse position so the plate knows where to go
        Vector2 playerPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetDirection = (mousePos - playerPos).normalized;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        var plate = Object.Instantiate(plateObject, transform.position, rotation);
        var plateRb = plate.GetComponent<Rigidbody2D>();
        plateRb.AddForce(targetDirection * plateSpeed, ForceMode2D.Impulse);
    }
}
