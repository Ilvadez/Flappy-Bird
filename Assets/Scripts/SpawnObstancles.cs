using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnObstancles : MonoBehaviour
{
    private float m_sizeCamera;
    [SerializeField] private GameObject m_prefabWall;
    [SerializeField] private GameObject m_prefabObstancle;
    [SerializeField] private float m_startDelaySpawn;
    [SerializeField] private float m_spawnDelay;
    [SerializeField] private float m_offsetX;
    [SerializeField] private float m_offsetY;

    public bool Condition;
    void Awake()
    {
        m_sizeCamera = Camera.main.orthographicSize;
        Condition = true;
    }
    void Start()
    {
        Spawn(m_prefabWall, 0, m_sizeCamera + 0.5f);
        Spawn(m_prefabWall, 0, -m_sizeCamera - 0.5f);
        StartCoroutine(StartSpawn(m_startDelaySpawn));

    }

    IEnumerator StartSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (Condition)
        {
            Spawn(m_prefabObstancle, m_sizeCamera * Camera.main.aspect + m_offsetX, Random.Range(-m_offsetY, m_offsetY));
            yield return new WaitForSeconds(m_spawnDelay);
        }

    }
    private void Spawn(GameObject gameObject, float xPosition, float yPosition)
    {
        Instantiate(gameObject, new Vector2(xPosition, yPosition), Quaternion.identity);
    }
}
