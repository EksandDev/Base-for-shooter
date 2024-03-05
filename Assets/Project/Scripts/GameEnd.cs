using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private void Awake()
    {
        EventBus.Instance().PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        SceneManager.LoadScene(0);
    }
}
