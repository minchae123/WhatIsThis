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

                _crabPrefab.crabData = CrabManager.Instance.CrabData[_crabPrefab.crabData.Number + 1];
                Debug.Log(_crabPrefab.crabData.Number + 1);
                Debug.Log(_crabPrefab.crabData);
                Instantiate(_crabPrefab, transform);

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (collision.tag == "Crab" && collisionSize != this.crabData.Number)
            {
                Debug.Log("사이즈 다른 게");
            }
        }
    }
}
