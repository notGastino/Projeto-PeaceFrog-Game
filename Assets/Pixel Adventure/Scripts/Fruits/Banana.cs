using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;


    public GameObject collected;

    public int Score;

    void Start()
    {
        ;
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject);
        }
    }
}
