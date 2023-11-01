using System.Collections;
using UnityEngine;

public class Crab : PoolableMono
{
    public CrabSO crabData;

    public bool ColliderCheck = false;

    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = crabData.Image;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ColliderCheck)
        {
            Crab crab = collision.gameObject.GetComponent<Crab>();

            // Crab ������Ʈ�� null�� ��� ó��
            if (crab == null)
            {
                Debug.Log("Crab ������Ʈ�� ã�� �� �����ϴ�.");
                return; // ���� �ڵ带 �������� �ʰ� �޼��带 ���������ϴ�.
            }

            int collisionSize = crab.crabData.Number;
            if (collision.tag == "Crab" && collisionSize == this.crabData.Number)
            {
                int crabIndex = crabData.Number;

                Crab nextCrab = PoolManager.Instance.Pop(GameManager.Instance.poolingListSO.list[++crabIndex].prefab.name) as Crab;
                nextCrab.transform.position = transform.position;
                PoolManager.Instance.Push(this);
                PoolManager.Instance.Push(crab);
            }

            else if (collision.tag == "Obstacle")
            {
                Debug.Log("Obstacle");
            }
            ColliderCheck = false;
        }
    }

    public override void Init()
    {
        //�ʱ�ȭ
        //crabData = crabList[0];
    }
}
