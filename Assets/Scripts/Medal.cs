using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite stoneMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver)
        {
            updateMedal();
        }
    }

    void updateMedal()
    {
        int gameScore = GameManager.gameScore;

        if (gameScore >= 0 && gameScore < 5)
        {
            img.sprite = stoneMedal;
        }
        else if (gameScore >= 5 && gameScore < 10)
        {
            img.sprite = bronzeMedal;
        }
        else if (gameScore >= 10 && gameScore < 25)
        {
            img.sprite = silverMedal;
        }
        else if (gameScore >= 25)
        {
            img.sprite = goldMedal;
        }
    }
}
