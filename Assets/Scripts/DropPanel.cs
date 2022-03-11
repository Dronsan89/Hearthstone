using UnityEngine;
using UnityEngine.EventSystems;

public class DropPanel : MonoBehaviour, IDropHandler
{
    private bool isDropCard = true;

    public void OnDrop(PointerEventData eventData)
    {
        if (isDropCard)
        {
            var otherCardTransform = eventData.pointerDrag.transform;
            otherCardTransform.SetParent(transform);
            otherCardTransform.localPosition = Vector3.zero;
            otherCardTransform.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);

            otherCardTransform.GetComponent<Card>().RemoveCardForList();

            isDropCard = false;
        }
    }
}
