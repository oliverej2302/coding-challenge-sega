using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    public int goalsToAward;
    public Team teamToAwardGoalTo;
    public bool resetPositionsOnGoal;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ball") return;
        scoreManager.IncreaseScore(goalsToAward, teamToAwardGoalTo, resetPositionsOnGoal);
    }
}
