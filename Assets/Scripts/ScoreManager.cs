using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore() {
        score += 100;
        ScoreText.text = "Score: " + score.ToString();
    }
}
