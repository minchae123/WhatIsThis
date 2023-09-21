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
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ColliderCheck)
        {
            int collisionSize = collision.gameObject.GetComponent<Crab>().crabData.Number;
            if (collision.tag == "Crab" && collisionSize == this.crabData.Number)
            {
                //
                CrabManager.Instance.MergeCrab(collisionSize + 1, transform.position);
                StartCoroutine(delayCoroutine(10f, collision));
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.tag == "Crab" && collisionSize != this.crabData.Number)
            {
                Debug.Log("사이즈 다른 게");
            }
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
