using UnityEngine;
using UnityEngine.SceneManagement;
public class Obstancles : MonoBehaviour
{

    private AudioSource m_source;
    private BoxCollider m_collider;
    private float m_cameraWidth;
    void Awake()
    {
        m_collider = GetComponent<BoxCollider>();
        m_source = GetComponent<AudioSource>();
        m_cameraWidth = Camera.main.orthographicSize * Camera.main.aspect * 2f;
    }
    void Start()
    {
        if (m_collider.CompareTag("Floor"))
        {
            m_collider.size = new Vector3(m_cameraWidth, 1f, 1f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ScoreSingleton.Instance.ShowEndScore();
            ScoreSingleton.Instance.SaveScore();
            m_source.Play();
            Time.timeScale = 0f;   
        }
    }
}
