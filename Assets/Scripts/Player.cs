using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coins;

    public int Coins => _coins;

    public void AddCoins(int value)
    {
        _coins += value;
    }

    public void SetCoinsValueZero()
    {
        _coins = 0;
    }
}
