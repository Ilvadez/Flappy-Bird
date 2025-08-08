using UnityEngine;

public class SaveScore
{
    public void Save(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
