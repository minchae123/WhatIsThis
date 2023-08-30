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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //int collisionSize = collision.gameObject.GetComponent<Crab>().crabData.Number;
        //if (collision.tag == "Crab" && collisionSize == this.crabData.Number)
        //{
        //    Debug.Log("사이즈 같은 게");
        //}
        //else if (collision.tag == "Crab" && collisionSize != this.crabData.Number)
        //{
        //    Debug.Log("사이즈 다른 게");
        //}
    }
}
