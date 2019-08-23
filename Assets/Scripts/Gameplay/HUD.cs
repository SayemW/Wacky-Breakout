using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text remainingBallsText;

    static float ballsNum, score;
    LastBallLost lastBallLost;

    public float getScore
    {
        get { return score; }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        ballsNum = ConfigurationUtils.BallsRemaining;
        remainingBallsText.text = ballsNum.ToString();
        EventManager.addAddPointsListener(addScore);
        EventManager.addBallLostListener(removeBall);

        // Game over events
        lastBallLost = new LastBallLost();
        EventManager.addLastBallLostInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        remainingBallsText.text = ballsNum.ToString();
        scoreText.text = score.ToString();
        if (ballsNum <= 0 && Time.timeScale != 0)
        {
            lastBallLost.Invoke();
        }
    }

    public void addScore (float scr)
    {
        score += scr;
    }

    public static void removeBall ()
    {
        ballsNum--;
    }

    public void addLastBallLostListener(UnityAction listener)
    {
        lastBallLost.AddListener(listener);
    }
}
