using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public bool isOpen;
    private float interactRange = 1.5f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var player = GameObject.FindWithTag("Player");
            var distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= interactRange)
            {
                if(isOpen)
                {
                    gameObject.tag = "Untagged";
                    animator.Play("WindowClose");
                }
                else
                {
                    animator.Play("WindowOpen");
                    gameObject.tag = "Window";
                }
                isOpen = !isOpen;
            }
        }
    }
}
