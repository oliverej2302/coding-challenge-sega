using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] PositionController positionController;
    [SerializeField] TMP_Text teamOneScoreCard;
    [SerializeField] TMP_Text teamTwoScoreCard;
    int teamOneGoalCount = 0;
    int teamTwoGoalCount = 0;

    void Start()
    {
        ResetScore();
    }

    public void UpdateScore()
    {
        teamOneScoreCard.text = teamOneGoalCount.ToString();
        teamTwoScoreCard.text = teamTwoGoalCount.ToString();
    }

    public void ResetScore()
    {
        teamOneGoalCount = 0;
        teamTwoGoalCount = 0;

        UpdateScore();
    }

    public void IncreaseScore(int value, Team teamToIncreaseScore, bool resetPositionsOnGoal)
    {
        switch (teamToIncreaseScore)
        {
            case Team.One:
                teamOneGoalCount += value;
                break;
            case Team.Two:
                teamTwoGoalCount += value;
                break;
            default:
                return;
        }

        UpdateScore();
        if (resetPositionsOnGoal)
        {
            positionController.ResetPositions();
        }
    }
}

public enum Team
{
    One,
    Two
}