using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhalePattern : MonoBehaviour
{
    [SerializeField] private Sprite smile;
    [SerializeField] private Sprite yam;

    private bool isRight;

    private SpriteRenderer spriteRenderer;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPos;
    private Vector2 spawnPos;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        isRight = Random.Range(0, 2) == 0 ? false : true;
        Flip();

        if (isRight)
        {
            float randomY = Random.Range(minY, maxY);
            spawnPos = new Vector2(maxX, randomY);
        }
        else
        {
            float randomY = Random.Range(minY, maxY);
            spawnPos = new Vector2(minX, randomY);
        }
    }

    private void Start()
    {
        if (isRight)
        {
            float randomY = Random.Range(minY, maxY);
            targetPos = new Vector2(minX, randomY);
        }
        else
        {
            float randomY = Random.Range(minY, maxY);
            targetPos = new Vector2(maxX, randomY);
        }
    }

    private void Update()
    {

    }

    public void SwimSea()
    { 
        
    }

    public void Flip()
    {
        spriteRenderer.flipX = isRight;
    }
}
