using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temptest : MonoBehaviour
{
    public GameObject player;
    private GameObject[] balls;
    public float playerSize = 0f;
    public float distance = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("pickable");
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        foreach (var ball in balls)
        {
            Vector2 ballPos = new Vector2(ball.transform.position.x, ball.transform.position.y);
            float distance = Vector2.Distance(ballPos, playerPos);
            if (distance <= 2f)
            {
                ball.GetComponent<SpriteRenderer>().color = Color.green;
                ball.GetComponent<ObjectController>().inRange = true;
            }
            else
            {
                ball.GetComponent<SpriteRenderer>().color = Color.red;
                ball.GetComponent<ObjectController>().inRange = false;
            }
        }
        /*distance = Vector2.Distance(player.transform.position, ball.transform.position);
        playerSize = player.transform.localScale.x;
        Debug.Log(distance);
        Debug.Log(playerSize);*/
    }
}
