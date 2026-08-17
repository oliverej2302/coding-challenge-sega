using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text teamOneScoreCard;
    [SerializeField] TMP_Text teamTwoScoreCard;
    int teamOneGoalCount = 0;
    int teamTwoGoalCount = 0;

    void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        teamOneGoalCount = 0;
        teamTwoGoalCount = 0;

        teamOneScoreCard.text = teamOneGoalCount.ToString();
        teamTwoScoreCard.text = teamTwoGoalCount.ToString();
    }

    public void IncreaseScore(int value, Team teamToIncreaseScore)
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
    }
}

public enum Team
{
    One,
    Two
}