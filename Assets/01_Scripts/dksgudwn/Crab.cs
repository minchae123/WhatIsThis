using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField]
    public CrabSO crabData;
    public bool ColliderCheck = false;

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
                Debug.Log("합침");
            }
            else if (collision.tag == "Crab" && collisionSize != this.crabData.Number)
            {
                Debug.Log("사이즈 다른 게");
            }
        }
    }
}
