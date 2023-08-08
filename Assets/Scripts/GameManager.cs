using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _startText;

    public void Start()
    {
        StopGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _startText.gameObject.SetActive(false);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    private void OnJump()
    {
        StartGame();
    }
}
