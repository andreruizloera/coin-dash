using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public int coinsToWin = 5;
    public TextMeshProUGUI messageText;
    int coins;
    bool gameOver;

    void Update()
    {
        if (gameOver) return;
        var k = Keyboard.current;
        Vector3 dir = Vector3.zero;
        if (k.wKey.isPressed) dir.z += 1;
        if (k.sKey.isPressed) dir.z -= 1;
        if (k.aKey.isPressed) dir.x -= 1;
        if (k.dKey.isPressed) dir.x += 1;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameOver) return;
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            messageText.text = "Coins: " + coins + "/" + coinsToWin;
            if (coins >= coinsToWin) End("You Win!");
        }
        else if (other.CompareTag("Enemy"))
        {
            End("You Lose!");
        }
    }

    void End(string msg)
    {
        gameOver = true;
        messageText.text = msg;
    }
}

