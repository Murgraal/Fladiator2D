using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Text wintext;

	void Update ()
    {
        if (ManagerManager.player1won)
        {
            wintext.text = "Player 1 Won";
            wintext.enabled = true;
        }
        if (ManagerManager.player2won)
        {
            wintext.text = "Player 2 Won";
            wintext.enabled = true;
        }
    }
}

