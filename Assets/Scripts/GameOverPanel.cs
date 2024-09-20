using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void Hide() => gameObject.SetActive(false);
    public void Swow() => gameObject.SetActive(true);
}
