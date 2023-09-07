using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public Vector2 targetPos;
    public Vector2 spawnPos;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        isRight = Random.Range(0, 2) == 0 ? false : true;
        Flip();

        if (isRight)
        {
            float randomY = Random.Range(minY, maxY);
            spawnPos = new Vector2(maxX, randomY);
            randomY = Random.Range(minY, maxY);
            targetPos = new Vector2(minX, randomY);
        }
        else
        {
            float randomY = Random.Range(minY, maxY);
            spawnPos = new Vector2(minX, randomY);
            randomY = Random.Range(minY, maxY);
            targetPos = new Vector2(maxX, randomY);
        }

        transform.position = spawnPos;

    }

    private void Start()
    {

        SwimSea();
    }

    private void Update()
    {

    }

    public void SwimSea()
    {
        float ranx = Random.Range(5, 7);
        transform.DOMove(targetPos, ranx);
    }

    public void Flip()
    {
        spriteRenderer.flipX = !isRight;
    }
}
