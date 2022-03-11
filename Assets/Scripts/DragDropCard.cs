using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private RectTransform rectTramsform;
    private Outline outline;
    private Vector2 widthOutline;

    private void Start()
    {
        rectTramsform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        outline = GetComponent<Outline>();
        widthOutline = Vector2.zero;
        outline.effectDistance = widthOutline;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        widthOutline = new Vector2(-4, -4);
        outline.effectDistance = widthOutline;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTramsform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
        widthOutline = Vector2.zero;
        outline.effectDistance = widthOutline;
    }
}
