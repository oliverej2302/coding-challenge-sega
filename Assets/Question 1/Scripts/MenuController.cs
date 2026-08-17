using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PositionController positionController;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] MaterialSyncer materialSyncer;
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

    public void OnPlayerOneDropdownChange(int colorDropdownIndex)
    {
        ChangeTeamColour(Team.One, colorDropdownIndex);
    }

    public void OnPlayerTwoDropdownChange(int colorDropdownIndex)
    {
        ChangeTeamColour(Team.Two, colorDropdownIndex);
    }

    public void ChangeTeamColour(Team teamColourToChange, int colorDropdownIndex)
    {
        Color newColor = Color.white;

        Debug.Log("Called! " + colorDropdownIndex + " = " + (DropdownColours)colorDropdownIndex);

        switch ((DropdownColours)colorDropdownIndex)
        {
            case DropdownColours.Red:
                newColor = Color.red;
                break;
            case DropdownColours.Orange:
                newColor = Color.orange;
                break;
            case DropdownColours.Yellow:
                newColor = Color.yellow;
                break;
            case DropdownColours.Green:
                newColor = Color.green;
                break;
            case DropdownColours.Blue:
                newColor = Color.blue;
                break;
            case DropdownColours.Purple:
                newColor = Color.rebeccaPurple;
                break;
            case DropdownColours.Pink:
                newColor = Color.pink;
                break;
            case DropdownColours.Black:
                newColor = Color.black;
                break;
            case DropdownColours.White:
                newColor = Color.white;
                break;
            default:
                break;
        }

        materialSyncer.ChangeMaterialColour(teamColourToChange, newColor);
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

public enum DropdownColours
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple,
    Pink,
    Black,
    White
}
