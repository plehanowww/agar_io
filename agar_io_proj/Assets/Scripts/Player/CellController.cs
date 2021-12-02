using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    //скрипт управлени€ игроком

    Rigidbody2D rb;
    [SerializeField] float speed;
    public float speedBySize = 1;

    float mouseSpeedModifier = 1;
    //в начале игры перекрашиваем игрока в тот цвет, который задавали в настройках
    void Start()
    {
        speedBySize = 1;
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(PlayerPrefs.GetFloat("color"), 1, 1);
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

    //двигаем игрока туда, где находитс€ мышка. —корость определ€етс€ через generalModifier
    private void FixedUpdate()
    {
        float generalModifier = speed * mouseSpeedModifier * speedBySize;

        
        rb.position = Vector3.MoveTowards(transform.position, mousePos, generalModifier * Time.deltaTime);
        
        
    }
    //функци€ составлени€ дистанции от игрока до мышки. — каждым порогом размера скорость будет уменьшатьс€
    void ChangeSpeedByMouse()
    {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
        float size = GetComponent<PlayerStats>().size;
        if (size < 50)
        {
            mouseSpeedModifier = distance / 10;

        } else if (size >= 50 && size < 200)
        {
            mouseSpeedModifier = distance / 12;
        } else if (size >= 200 && size < 500)
        {
            mouseSpeedModifier = distance / 14;
        }
        else
        {
            mouseSpeedModifier = distance / 17;
        }
        
    }
}
