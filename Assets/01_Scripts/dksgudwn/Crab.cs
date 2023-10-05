using System.Collections;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField]
    public CrabSO crabData;
    public bool ColliderCheck = false;

    private SpriteRenderer _spriteRenderer;
    private Crab _crabPrefab;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _crabPrefab = GetComponent<Crab>();
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
                CrabManager.Instance.MergeCrab(collisionSize + 1, transform.position);
                StartCoroutine(delayCoroutine(10f, collision));
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            //else if (collision.tag == "Crab" && collisionSize != this.crabData.Number)
            //{
            //    Debug.Log("사이즈 다른 게");
            //}
            else if (collision.tag == "Obstacle")
            {
                Debug.Log("Obstacle");
            }
            ColliderCheck = false;
        }
    }

    IEnumerator delayCoroutine(float delay, Collider2D collision)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        Destroy(collision.gameObject);
        //gameObject.GetComponent<Renderer>().enabled = false;
        //collision.gameObject.GetComponent<Renderer>().enabled = false;
    }
}
