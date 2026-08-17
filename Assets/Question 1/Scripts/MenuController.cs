using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PositionController positionController;
    [SerializeField] ScoreManager scoreManager;
    bool isMenuActive = false;
    public void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        pauseMenu.SetActive(isMenuActive);
        if (isMenuActive)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        ToggleMenu();
        positionController.ResetPositions();
        scoreManager.ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
