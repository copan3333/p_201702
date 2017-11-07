using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHp : MonoBehaviour {

    public Image lifeGage;
    public Image lifeRedGage;

    // Use this for initialization
    void Start () {

        lifeRedGage.fillAmount = Player.Instance.HP * 0.1f;
    }
	
	// Update is called once per frame
	void Update () {

        lifeGage.fillAmount = Player.Instance.HP * 0.1f;


    }

    public void downLifeRedGage(float damagePower)
    {
        lifeRedGage.fillAmount = damagePower ;
    }
}
