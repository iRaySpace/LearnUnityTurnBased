using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{
    public enum Result : int {
        PlayerWin = 1,
        EnemyWin = 2
    }

    public TMP_Text turnText;

    public Health playerHealth;
    public Health enemyHealth;

    private bool playerTurn;
    private int result;

    // Start is called before the first frame update
    private void Start()
    {
        SetTurn("PLAYER");
    }

    // Update is called once per frame
    // private void Update() {}

    private void SetTurn(string turn)
    {
        if (playerHealth.IsDead())
        {
            result = (int) Result.EnemyWin;
        } else if (enemyHealth.IsDead())
        {
            result = (int) Result.PlayerWin;
        }

        if (result == (int) Result.PlayerWin)
        {
            turnText.text = "PLAYER WIN";
        } else if (result == (int) Result.EnemyWin)
        {
            turnText.text = "ENEMY WIN";
        }

        if (result > 0)
        {
            return;
        }

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

        int damage = Random.Range(5, 15);
        playerHealth.TakeDamage(damage);
        SetTurn("PLAYER");
    }

    public void HandleSkip()
    {
        if (!playerTurn)
        {
            return;
        }

        SetTurn("ENEMY");
    }

    public void HandleAttack()
    {
        if (!playerTurn)
        {
            return;
        }

        int damage = Random.Range(10, 20);
        enemyHealth.TakeDamage(damage);
        SetTurn("ENEMY");
    }
}
