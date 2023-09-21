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
    private GameObject visual;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [SerializeField] private float speed = 0.05f;

    public Vector2 targetPos;
    public Vector2 spawnPos;

    private Collider2D col;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        col = GetComponentInChildren<Collider2D>();
        visual = transform.Find("Visual").gameObject;
        WhaleSpawn();
    }

    public void WhaleSpawn()
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
            WhaleSpawn();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
    }

    public void Flip()
    {
        //spriteRenderer.flipX = !isRight;
        int flipx = isRight == true ? 1 : -1;
        visual.transform.localScale = new Vector3(flipx, 1,1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Crab"))
        {
            print("°í·¡°¡ ¸Ô¾î¹ö·ö");
            spriteRenderer.sprite = yam;
            col.enabled = false;
        }

    }
}
