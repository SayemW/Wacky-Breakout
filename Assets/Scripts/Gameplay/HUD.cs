using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text remainingBallsText;

    static float ballsNum, score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        ballsNum = ConfigurationUtils.BallsRemaining;
        remainingBallsText.text = ballsNum.ToString();
        EventManager.addAddPointsListener(addScore);
    }

    // Update is called once per frame
    void Update()
    {
        remainingBallsText.text = ballsNum.ToString();
        scoreText.text = score.ToString();
    }

    public void addScore (float scr)
    {
        score += scr;
    }

    public static void removeBall ()
    {
        ballsNum--;
    }
}
