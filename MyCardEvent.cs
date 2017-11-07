using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MyCardEvent : MonoBehaviour {

    [SerializeField]
    public GameObject Black;

    [SerializeField]
    public Image[] PartsImage;

    private Transform BattlePanel;
    GameObject card;
    MyCards myc;
    float move;

    // Use this for initialization
    void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickMyCard()
    {
        myc = transform.parent.GetComponent<MyCards>();
        
        myc.battle.BattleStartButton.interactable = true;
        if (myc.Panel.childCount > 2 || myc.isMove)
        {
            return;
        }
        myc.isMove = true;
        Black.SetActive(true);
        GetComponent<Button>().interactable = false;
        myc.battle.playSound.PlaySE(2);
        card = Instantiate(this.gameObject);
        card.name = this.gameObject.name;
        card.transform.SetParent(myc.Panel);
        card.GetComponent<MyCardEvent>().Black.SetActive(false);
        card.transform.localScale = new Vector3(0f, 0f, 0f);
        
        Destroy(card.GetComponent<Button>());
        EventTrigger ev = card.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(ReturnCard);

        ev.triggers.Add(entry);
        myc.ShowCards.Add(card);
        myc.TouchCards.Add(card,this.gameObject);
        card.transform.position = myc.TouchCards[card].transform.position;

        switch(myc.ShowCards.Count)
        {
            case 1:
                move = 2;
                break;

            case 2:
                move = 1f;
                break;

            case 3:
                move = 0;
                break;
        }
        
        iTween.MoveBy(card, iTween.Hash(
            "y",card.transform.position.y - myc.Panel.position.y ,
            "x", card.transform.position.x - myc.Panel.position.x,
            "time", 0f,
            "oncomplete", "Move",
            "oncompletetarget", this.gameObject,
            "easeType", "linear"
        ));

    }

    private void Move()
    {
        
        iTween.ScaleTo(card, iTween.Hash(
         "scale", Vector3.one
         , "time", 0.3f
         ));

        iTween.MoveBy(card, iTween.Hash(
            "y", -(card.transform.position.y - myc.Panel.position.y),
            "x", -(card.transform.position.x - myc.Panel.position.x)-move,
            "time", 0.3f,
            "oncomplete","CompleteMove",
            "oncompletetarget", this.gameObject,
            "easeType", "linear"
        ));
    }

    private void CompleteMove()
    {
        myc.isMove = false;
    }

    private void ReturnCard(BaseEventData eventData)
    {

        myc.battle.playSound.PlaySE(3);
        iTween.ScaleTo(card, iTween.Hash(
         "scale", Vector3.zero
         , "time", 0.8f
         ));

        iTween.MoveBy(card, iTween.Hash(
            "y", myc.TouchCards[card].transform.position.y - card.transform.position.y,
            "x", myc.TouchCards[card].transform.position.x - card.transform.position.x,
            "time", 0.5f,
            "oncomplete", "ReturnCardEnd",
            "oncompletetarget", this.gameObject,
            "easeType", "linear"
        ));

    }

    private void ReturnCardEnd()
    {
        List<GameObject> cardList = new List<GameObject>();
        foreach (GameObject g in myc.ShowCards)
        {
            if(g != card)
            {
                cardList.Add(g);
            }

            g.SetActive(false);
        }
        Destroy(card);
        myc.ShowCards.Clear();

        foreach(GameObject g in cardList)
        {
            myc.ShowCards.Add(g);
        }

        cardList.Clear();

        for(int i = 0;i < myc.ShowCards.Count;i++)
        {
            myc.ShowCards[i].SetActive(true);
        }

        myc.TouchCards.Remove(card);

        GetComponent<Button>().interactable = true;
        Black.SetActive(false);

    }
}
