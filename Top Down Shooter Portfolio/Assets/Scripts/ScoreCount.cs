using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance;

    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text highScoreText;

    public int currentScore;
    public int highScore;

    private void Awake()
    {
        instance = this;
      //  PlayerPrefs.DeleteAll();    //Clears the Highest Score, DELETE BEFORE RELEASE
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = ("Highest Score: " + highScore).ToString();
    }

    void Update()
    {
        currentScoreText.text = ("Score: " + currentScore).ToString();

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
        }
    }
}
