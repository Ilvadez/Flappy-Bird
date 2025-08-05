using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int m_value;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreSingleton.Instance.AddScore(m_value);
        }
    }
}
