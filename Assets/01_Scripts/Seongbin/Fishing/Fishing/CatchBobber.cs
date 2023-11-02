using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CatchBobber : MonoBehaviour
{
    public static Action bobberThrow;
    public static Action resetGravity;
    public static Action crabBite;
    public static Action bobberUp;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        bobberThrow += BobberThrow;
        resetGravity += ResetGravity;
        crabBite += BiteCrab;
        bobberUp += BobberUp;
    }

    //³¬½ËÁÙ ´øÁö±â
    public void BobberThrow()
    {
        _rb.gravityScale = 1;
        _rb.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
    }
    //³¬½ÃÂî Áß·Â 0À¸·Î
    public void ResetGravity() => _rb.gravityScale = 0;

    //ÀÔÁú ¿ÔÀ»¶§ Èçµé±â
    public void BiteCrab() => transform.DOShakePosition(3.5f);

    //³¬¾ÒÀ»¶§ À§·Î µå´Â°Å
    public void BobberUp()
    {
        transform.position = new Vector3(transform.position.x + .5f, transform.position.y + 3, transform.position.z);
    }
}
