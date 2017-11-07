using UnityEngine;
using System.Collections;

public class Const {

	public enum Scenename
    {
        Title = 0,
        Quest,
        Battle,

    };

    public enum TYPE
    {
        g,
        p,
        c
    }

    public static bool Janken(GameObject myCard, GameObject enemCard)
    {
        int jankenType = myCard.GetComponent<CardParam>().JankenType;
        int EnemJankenType = enemCard.GetComponent<CardParam>().JankenType;
        Debug.Log("ENEM"+ jankenType);
        if (jankenType == 0)
        {
            if (EnemJankenType == 1 || EnemJankenType == 2)
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }
        else if (jankenType == 1)
        {
            if (EnemJankenType == 2 || EnemJankenType == 0)
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }
        else if (jankenType == 2)
        {
            if (EnemJankenType == 0 || EnemJankenType == 1)
            {
                
                return true;
            }
            else
            {
                
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static string GetSceneName(Scenename name)
    {
        string[] names =
        {
                "Title",
                "Quest",
                "Battle"
        };

        return names[(int)name];
    }


}
