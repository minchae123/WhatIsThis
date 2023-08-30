using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Vector3 MousePosition;
    public Camera _camera;


    //public static Camera Camera
    //{
    //    get
    //    {
    //        if (_camera == null) _camera = Camera.main;
    //        return _camera;
    //    }
    //}

    private void Start()
    {
        //_camera = GetComponent<Camera>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        MousePosition = eventData.position;
        MousePosition = _camera.ScreenToWorldPoint(MousePosition);

        RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 10);
        Debug.DrawRay(MousePosition, transform.forward * 10, Color.red, 1f);
        //hit.transform.GetComponent<CrabSO>
        if (hit.collider != null)
        {
            int collisionNumber = hit.transform.GetComponent<Crab>().crabData.Number;
            int myNumber = this.gameObject.GetComponent<Crab>().crabData.Number;
            if (hit.transform.tag == "Crab" && collisionNumber == myNumber)
            {
                Debug.Log("사이즈 같은 게");
            }
            else if (hit.transform.tag == "Crab" && collisionNumber != myNumber)
            {
                Debug.Log("사이즈 다른 게");
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    //private void OnMouseDrag()
    //{
    //    transform.position = GetMousePos();
    //}
    //Vector3 GetMousePos()
    //{
    //    var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mousePos.z = 0;
    //    return mousePos;
    //}
}
