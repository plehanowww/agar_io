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
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        //rb.AddForce(new Vector2(xInput, yInput) * speed * Time.deltaTime, ForceMode2D.Impulse);
        rb.velocity = new Vector2(xInput, yInput) * speed * Time.deltaTime;
    }
}
