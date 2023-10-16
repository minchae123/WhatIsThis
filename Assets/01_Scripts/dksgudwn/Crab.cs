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

            // Crab 컴포넌트가 null인 경우 처리
            if (crab == null)
            {
                Debug.Log("Crab 컴포넌트를 찾을 수 없습니다.");
                return; // 이후 코드를 실행하지 않고 메서드를 빠져나갑니다.
            }

            int collisionSize = crab.crabData.Number;
            if (collision.tag == "Crab" && collisionSize == this.crabData.Number)
            {
                int crabIndex = crabData.Number;

                Crab nextCrab = PoolManager.Instance.Pop(GameManager.Instance.poolingListSO.list[++crabIndex].prefab.name) as Crab;
                nextCrab.transform.position = transform.position;
                StartCoroutine(delayCoroutine(10f, collision));
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

    private void MergeCrab(int v, Vector3 pos)
    {
        Crab crab = PoolManager.Instance.Pop("MainCrab") as Crab;
        print(v);
        crab.transform.position = pos;
    }

    IEnumerator delayCoroutine(float delay, Collider2D collision)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        Destroy(collision.gameObject);
        Debug.Log("anjsi");
        //gameObject.GetComponent<Renderer>().enabled = false;
        //collision.gameObject.GetComponent<Renderer>().enabled = false;
    }

    public override void Init()
    {
        //초기화
        //crabData = crabList[0];
    }
}
