using UnityEngine;
using UnityEngine.EventSystems;
public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    [SerializeField] solucion_correcta correcta;
    [SerializeField] string ObjectTag;

    public void Start()
    {
        ObjectTag = gameObject.tag;
        correcta = GameObject.FindGameObjectWithTag("correcta").GetComponent<solucion_correcta>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;

            if (item.tag == ObjectTag)
            {
                correcta.contador++;
                DragHandler itemHandler = item.GetComponent<DragHandler>();
                itemHandler.enabled=false;
            }



        }
    }
    void Update()
    {

        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }

    }
}
