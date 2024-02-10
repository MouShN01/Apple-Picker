using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public Text scoreLB;
    public Text levelLb;

    public int level = 1;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDirections = 0.1f;

    public float secondsBetweenAppleDrops = 1f;

    public bool isDifUpdated = false;
    private void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    private void Update()
    {
        //движение дерева
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //отталкивание от краев
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        if(secondsBetweenAppleDrops > 0.5)
        {
            UpDifficulty();
        }
        levelLb.text = "Level " + level;
    }

    void UpDifficulty()
    {
        int score = int.Parse(scoreLB.text);
        if (score != 0 && score % 600 == 0)
        {
            isDifUpdated = false;
        }
        if (score != 0 && score % 500 == 0 && !isDifUpdated)
        {
            secondsBetweenAppleDrops -= 0.1f;
            speed += 2f;
            level += 1;
            isDifUpdated = true;
        }
    }

    private void FixedUpdate()
    {
        //случайное изменение направления 
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
