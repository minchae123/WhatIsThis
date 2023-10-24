using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Crab"))
        {
            Crab crab = collision.GetComponent<Crab>();
            crab.GetComponent<Dragger>().enabled = true;
            crab.transform.parent = null;
            //Crab Data Number Check
            PoolManager.Instance.Push(crab);
        }
    }
}
