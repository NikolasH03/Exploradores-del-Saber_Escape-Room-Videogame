using UnityEngine;
using UnityEngine.EventSystems;
public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public static GameObject itemDragging;

     Vector3 startPosition;
     Transform startParent;
     Transform dragParent;
    void Start()
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform; 
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        itemDragging = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(dragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        itemDragging = null;

        if (transform.parent == dragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    //public void ResetPosition()
    //{
    //    transform.position = startPosition;
    //    transform.SetParent(startParent);
    //}
}
