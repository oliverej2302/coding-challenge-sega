using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool isMenuActive = false;
    public void ToggleMenu(InputAction.CallbackContext context)
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
}
