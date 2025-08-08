using TMPro;
using UnityEngine;

public class LoadBestScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_text;
    int m_bestScore;

    private void Awake()
    {
        ShowScore();    
    }
    public void ShowScore()
    {
        m_bestScore = PlayerPrefs.GetInt("Score");
        m_text.text = $"{m_bestScore}";
    }
}
