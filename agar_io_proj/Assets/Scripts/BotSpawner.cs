using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    // спавнер врагов. —павнит иногда не ровно врагов, хотел использовать эту конструкцию, но кажетс€ лучше было заново сделать

    [SerializeField] GameObject botObject;
    [SerializeField] int maxBots;
    BoxCollider2D collider;

    float radius;
    float minX, maxX, minY, maxY;

    //в начале игры измер€ем коллайдер, чтобы понимать где можно спавнить
    void Start()
    {
        radius = botObject.GetComponent<CircleCollider2D>().radius;
        collider = GameObject.Find("Backround_grid").GetComponent<BoxCollider2D>();
        minX = collider.bounds.min.x; maxX = collider.bounds.max.x;
        minY = collider.bounds.min.y; maxY = collider.bounds.max.y;

        Invoke("MassSpawn", 1);//скрипт с едой тоже работает с background и удал€ет его. ј так как новые штуки не могут заспавниттс€ в 
        //коллайдерах, то ждем врем€ чтобы его удалили и уже потом ставим врагов

    }

    //функци€ массового спавна нужного количества врагов
    void MassSpawn()
    {
        for (int i = 0; i <= maxBots; i++)
        {
            Spawn();
        }
    }


    Vector2 randomPos;
    public void Spawn()
    {
        do
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 randomPos = new Vector2(randomX, randomY);


            if (Physics2D.OverlapCircle(randomPos, radius) == null)
            {
                GameObject obj = Instantiate(botObject, randomPos, botObject.transform.rotation, gameObject.transform);
                print(obj);
                RandomColor(obj);
                break;
            }
        } while (Physics2D.OverlapCircle(randomPos, radius) == null);
    }


    void RandomColor(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }
}
