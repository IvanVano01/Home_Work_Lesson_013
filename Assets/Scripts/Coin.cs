using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _value = 1;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();

        if (player != null)
        {
            player.AddCoins(_value);
            
            gameObject.SetActive(false);

        }
    }
}
