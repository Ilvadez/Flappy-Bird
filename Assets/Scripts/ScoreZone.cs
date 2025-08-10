using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int m_value;
    private AudioSource m_source;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_source = GetComponent<AudioSource>();
            m_source.Play();
            ScoreSingleton.Instance.AddScore(m_value);
        }
    }
}
