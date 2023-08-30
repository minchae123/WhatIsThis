using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhalePattern : MonoBehaviour
{
    [SerializeField] private Sprite smile;
    [SerializeField] private Sprite yam;

    private bool isRight;

    private SpriteRenderer spriteRenderer;

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }

    public void SwimSea()
    { 
        
    }

    public void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
