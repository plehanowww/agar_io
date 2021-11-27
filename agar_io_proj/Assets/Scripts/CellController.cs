using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float xInput;
    float yInput;
    Vector2 mousePos;
    // Update is called once per frame
    void Update()
    {
        //print(Physics2D.OverlapCircle(new Vector2(0, 0), 2));
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {    
        //rb.velocity = new Vector2(xInput, yInput) * speed * Time.deltaTime
        //rb.velocity = mousePos * speed * Time.deltaTime;
        rb.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);

    }
}
