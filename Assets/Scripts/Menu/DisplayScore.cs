using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    static float score;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        score = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().getScore;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
