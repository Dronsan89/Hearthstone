using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] Text textAttack;
    [SerializeField] Text textHealth;
    [SerializeField] Text textMana;

    //enum Parameters { attack, health, mana }
    //private Parameters currentParameters;

    private int attack;
    public int Attack
    {
        get { return attack; }
        set
        {
            int tempAttack = attack;
            attack = value;
            StartCoroutine(SetParameters(tempAttack, attack, textAttack));
        }
    }

    public int health;
    public int Health
    {
        get { return health; }
        set
        {
            int tempHealth = health;
            health = value;
            StartCoroutine(SetParameters(tempHealth, health, textHealth));
            if (health <= 0)
            {
                controllerCard.indexChaingeValue--;
                RemoveCardForList();
                Destroy(gameObject);
            }
        }
    }

    private int mana;
    public int Mana
    {
        get { return mana; }
        set
        {
            int tempMana = mana;
            mana = value;
            StartCoroutine(SetParameters(tempMana, mana, textMana));
        }
    }

    private ControllerCard controllerCard;

    void Awake()
    {
        SetBeginParameters();

        controllerCard = FindObjectOfType<ControllerCard>();
    }

    private IEnumerator Start()
    {
        WWW www = new WWW("https://picsum.photos/100/170");
        yield return www;
        Texture2D texture = www.texture;

        GetComponent<Image>().sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    public void RemoveCardForList()
    {
        controllerCard.listAllCard.Remove(gameObject);
        controllerCard.UpdatePositionCard();
    }

    private void SetBeginParameters()
    {
        int randAttack = Random.Range(2, 7);
        Attack = randAttack;
        int randHealth = Random.Range(2, 7);
        Health = randHealth;
        int randMana = Random.Range(2, 7);
        Mana = randMana;
    }
    IEnumerator SetParameters(int beginValue, int endValue, Text textParameters)
    {
        if (beginValue < endValue)
        {
            for (int i = beginValue; i < endValue + 1; i++)
            {
                textParameters.text = i.ToString();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (beginValue > endValue)
        {
            for (int i = beginValue; i > endValue - 1; i--)
            {
                textParameters.text = i.ToString();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SetRandomParameters(int value)
    {
        Health = value;

        //Значения меняются только у жизней. Ниже вариант изменения значения у трёх параметров
        /*int randParam = Random.Range(0, 3);
        currentParameters = (Parameters)randParam;

        switch (currentParameters)
        {
            case Parameters.attack:
                Attack = value;
                break;
            case Parameters.health:
                Health = value;
                break;
            case Parameters.mana:
                Mana = value;
                break;
            default:
                break;
        }*/
    }
}
