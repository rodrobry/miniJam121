using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int plateAmmu = 0;
    public float plateSpeed = 7.5f;
    public GameObject plateObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            var plate = GameObject.Find("Plate" + i);
            var plateImage = plate.GetComponent<UnityEngine.UI.Image>();
            plateImage.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && plateAmmu > 0)
        {
            Attack();
        }

        if (Input.GetButtonDown("Jump"))
        {
            GetPlates();
        }
    }

    private void Attack()
    {
        //Give the plate a rotation matching the mouse position
        Vector2 playerPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetDirection = (mousePos - playerPos).normalized;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        var plate = Object.Instantiate(plateObject, transform.position, rotation);
        var plateRb = plate.GetComponent<Rigidbody2D>();
        plateRb.AddForce(targetDirection * plateSpeed, ForceMode2D.Impulse);

        plateAmmu--;
        UpdatePlateUI(false);
    }

    private void GetPlates()
    {
        var chest = GameObject.Find("PlateChest");
        var distance = Vector2.Distance(transform.position, chest.transform.position);
        if (distance <= 1)
        {
            plateAmmu = 5;
            UpdatePlateUI(true);
        }

    }

    private void UpdatePlateUI(bool refil)
    {
        if (refil)
        {
            for (int i = 1; i < 6; i++)
            {
                var plate = GameObject.Find("Plate" + i);
                var plateImage = plate.GetComponent<UnityEngine.UI.Image>();
                plateImage.enabled = true;
            }
        }
        else
        {
            var num = plateAmmu + 1;
            var plate = GameObject.Find("Plate" + num);
            var plateImage = plate.GetComponent<UnityEngine.UI.Image>();
            plateImage.enabled = false;
        }
    }
}
