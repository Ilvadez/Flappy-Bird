using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSingleton : MonoBehaviour
{
    public static ScoreSingleton Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI m_ScoreUI;
    [SerializeField] private TextMeshProUGUI m_ScoreEndUI;
    public UnityEvent EndGame = new UnityEvent();
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
    public void SaveScore()
    {
        SaveScore save = new SaveScore();
        int savedScore = PlayerPrefs.GetInt("Score");
        if (savedScore < m_score)
        {
            save.Save(m_score);
        }
    }
    public void ShowEndScore()
    {
        EndGame.Invoke();
        m_ScoreEndUI.text = $"Score: {m_score}";
    }
}
