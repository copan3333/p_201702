using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCards : MonoBehaviour {


    [SerializeField]
    public Transform Panel;

    [SerializeField]
    public Battle battle;

    public List<GameObject> ShowCards = new List<GameObject>();
    public Dictionary<GameObject,GameObject> TouchCards = new Dictionary<GameObject,GameObject>();
    public bool isMove = false;

    // Use this for initialization
    void Start () {

        //transform.GetChild(0).GetComponent<MyCardEvent>().OnClickMyCard();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
