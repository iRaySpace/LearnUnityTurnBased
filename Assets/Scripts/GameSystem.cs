using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{
    public TMP_Text turnText;

    private bool playerTurn;

    // Start is called before the first frame update
    private void Start()
    {
        SetTurn("PLAYER");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp("space") && playerTurn)
        {
            SetTurn("ENEMY");
        }
    }

    private void SetTurn(string turn)
    {
        if (turn == "PLAYER")
        {
            playerTurn = true;
            turnText.text = "YOUR TURN";
        }

        if (turn == "ENEMY")
        {
            playerTurn = false;
            turnText.text = "ENEMY TURN";
            StartCoroutine(EnemyCoroutine());
        }
    }

    IEnumerator EnemyCoroutine()
    {
        int seconds = Random.Range(3, 5);
        yield return new WaitForSeconds(seconds);
        SetTurn("PLAYER");
    }
}
