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

    //������ ������
    public void BobberThrow()
    {
        _rb.gravityScale = 1;
        _rb.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
    }
    //������ �߷� 0����
    public void ResetGravity() => _rb.gravityScale = 0;

    //���� ������ ����
    public void BiteCrab() => transform.DOShakePosition(3.5f);

    //�������� ���� ��°�
    public void BobberUp()
    {
        transform.position = new Vector3(transform.position.x + .5f, transform.position.y + 3, transform.position.z);
    }
}
