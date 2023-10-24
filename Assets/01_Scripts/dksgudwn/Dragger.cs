using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour
{
    Vector3 MousePosition;
    Crab _crab;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _crab = GetComponent<Crab>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //this.enabled = true;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
        transform.parent = null;
        _spriteRenderer.sortingOrder = 10;
    }
    private void OnMouseUp()
    {
        _spriteRenderer.sortingOrder = 1;
        StartCoroutine(MouseUp());
    }
    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    IEnumerator MouseUp()
    {
        _crab.ColliderCheck = true;
        yield return new WaitForSeconds(0.05f);
        //Debug.Log(_crab.ColliderCheck);
        _crab.ColliderCheck = false;
    }
}
