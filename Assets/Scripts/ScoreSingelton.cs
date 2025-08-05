using TMPro;
using UnityEngine;

public class ScoreSingleton : MonoBehaviour
{
    public static ScoreSingleton Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI m_ScoreUI;
    private int m_score;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        m_score = 0;
        UpdateScore();
    }

    public void AddScore(int value)
    {
        m_score += value;
        UpdateScore();
    }
    private void UpdateScore()
    {
        m_ScoreUI.text = $"{m_score}";
    } 
}
