using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    private float interactRange = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetButtonDown("Jump"))
        {
            var windows = GameObject.FindGameObjectsWithTag("Window");
            foreach (var window in windows)
            {
                var distance = Vector2.Distance(transform.position, window.transform.position);
                if (distance <= interactRange)
                {
                    window.SetActive(!window.activeSelf);
                }
            }
        }
    }
}
