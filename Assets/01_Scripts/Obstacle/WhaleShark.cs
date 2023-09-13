using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WhaleShark : PoolableMono
{
    [SerializeField] private Sprite smile;
    [SerializeField] private Sprite yam;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private float speed = 0.01f;

    [SerializeField] private Vector2 targetPos;
    [SerializeField] private Vector2 spawnPos;

    private bool isRight;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        col = GetComponentInChildren<Collider2D>();
    }

    public void Spawn()
    {
        col.enabled = true;
        spriteRenderer.sprite = yam;
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Spawn();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
    }

    public void Flip()
    {
        spriteRenderer.flipX = !isRight;
    }

    public override void Reset()
    {
        Spawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Crab"))
        {
            spriteRenderer.sprite = smile;
            Destroy(collision.gameObject);
            col.enabled = false;
        }

    }
}
