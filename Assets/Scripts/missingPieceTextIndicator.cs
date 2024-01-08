using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class missingPieceTextIndicator : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance.playerInventory.Contains("missing_piece")) {
            GetComponent<TMP_Text>().text = "yes!";
        } else {
            GetComponent<TMP_Text>().text = "no";
        }
    }

}
