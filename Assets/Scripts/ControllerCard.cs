using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCard : MonoBehaviour
{
    [SerializeField] GameObject panelForCardEven;
    [SerializeField] RectTransform[] slotForCardEvens;
    [SerializeField] GameObject panelForCardOdd;
    [SerializeField] RectTransform[] slotForCardOdds;
    [SerializeField] GameObject prefabCard;

    public List<GameObject> listAllCard;

    public int indexChaingeValue;

    private int beginIndexSetCard;
    private int countCard;
    private float timeMoveCard;
    private float delayExitCard;

    void Start()
    {
        SetCountCard();
        indexChaingeValue = 0;
        timeMoveCard = 1.5f;
        delayExitCard = 1;
    }

    private void SetCountCard()
    {
        countCard = Random.Range(4, 7);

        if (countCard % 2 == 0)
        {
            SetCountCardEven();
            StartCoroutine(SetCardInSlot(slotForCardEvens));
        }
        else
        {
            SetCountCardOdd();
            StartCoroutine(SetCardInSlot(slotForCardOdds));
        }
    }

    private void SetCountCardOdd()
    {
        panelForCardOdd.SetActive(true);
        if (countCard == 5)
        {
            beginIndexSetCard = 0;
        }
        else if (countCard == 3)
        {
            beginIndexSetCard = 1;
        }
        else if (countCard == 1)
        {
            beginIndexSetCard = 2;
        }
    }

    private void SetCountCardEven()
    {
        panelForCardEven.SetActive(true);
        if (countCard == 6)
        {
            beginIndexSetCard = 0;
        }
        else if (countCard == 4)
        {
            beginIndexSetCard = 1;
        }
        else if (countCard == 2)
        {
            beginIndexSetCard = 2;
        }
    }

    IEnumerator SetCardInSlot(RectTransform[] arraySlots)
    {
        for (int i = beginIndexSetCard; i < countCard + beginIndexSetCard; i++)
        {
            GameObject newCard = Instantiate(prefabCard);
            newCard.transform.parent = arraySlots[i];
            newCard.GetComponent<RectTransform>().DOAnchorPos(Vector3.zero, timeMoveCard);
            newCard.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
            listAllCard.Add(newCard);

            yield return new WaitForSeconds(delayExitCard);
        }
    }

    public void ChaingeValueCard()
    {
        if (indexChaingeValue <= listAllCard.Count - 1)
        {
            int randChaingeValue = Random.Range(-2, 10);
            listAllCard[indexChaingeValue].GetComponent<Card>().SetRandomParameters(randChaingeValue);//ограничение сделать
            indexChaingeValue++;
        }
    }

    public void UpdatePositionCard()
    {
        panelForCardEven.SetActive(false);
        panelForCardOdd.SetActive(false);

        countCard = listAllCard.Count;

        if (countCard % 2 == 0)
        {
            SetCountCardEven();
            StartCoroutine(UpdateCardInSlot(slotForCardEvens));
        }
        else
        {
            SetCountCardOdd();
            StartCoroutine(UpdateCardInSlot(slotForCardOdds));
        }
    }

    IEnumerator UpdateCardInSlot(RectTransform[] arraySlots)
    {
        for (int i = beginIndexSetCard; i < countCard + beginIndexSetCard; i++)
        {
            var newCard = listAllCard[i - beginIndexSetCard];
            newCard.transform.parent = arraySlots[i];
            newCard.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, timeMoveCard);
            newCard.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
            yield return new WaitForSeconds(delayExitCard);
        }
    }
}
