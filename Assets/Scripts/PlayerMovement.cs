using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
            var dirX = Input.GetAxisRaw("Horizontal");
            var dirY = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
    }
}
