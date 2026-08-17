using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] GameObject playerOne, playerTwo;
    [SerializeField] GameObject ball;
    Rigidbody ballrb;
    public Vector3 playerOneSpawnPosition, playerTwoSpawnPosition;
    public Vector3 ballSpawnPosition;

    void Start()
    {
        ballrb = ball.GetComponent<Rigidbody>();
    }

    public void ResetPositions()
    {
        playerOne.transform.position = playerOneSpawnPosition;
        playerTwo.transform.position = playerTwoSpawnPosition;


        ballrb.linearVelocity = Vector3.zero;
        ballrb.angularVelocity = Vector3.zero;
        ballrb.position = ballSpawnPosition;
        ball.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
