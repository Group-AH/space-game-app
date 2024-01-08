using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissingPiece : MonoBehaviour
{
    public TMP_Text missingPieceText;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5.0f * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameManager.Instance.addItemToInventory("missing_piece");
            missingPieceText.text = "yes!";

            Destroy(gameObject);
        }
    }
}
