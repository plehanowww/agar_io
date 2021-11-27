using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;

    [Range(0, 5f)]
    float mouseSpeedModifier = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float xInput;
    float yInput;
    Vector2 mousePos;

    void Update()
    {
        ChangeSpeedByMouse();
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {    
        rb.position = Vector3.MoveTowards(transform.position, mousePos, speed * mouseSpeedModifier * Time.deltaTime);
    }
    void ChangeSpeedByMouse()
    {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
        mouseSpeedModifier = distance / 10;
    }
}
