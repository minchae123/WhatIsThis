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

            // Crab ������Ʈ�� null�� ��� ó��
            if (crab == null)
            {
                Debug.Log("Crab ������Ʈ�� ã�� �� �����ϴ�.");
                return; // ���� �ڵ带 �������� �ʰ� �޼��带 ���������ϴ�.
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
            //    Debug.Log("������ �ٸ� ��");
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
