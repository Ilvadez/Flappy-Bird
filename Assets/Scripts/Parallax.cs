using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject m_prefab;
    private GameObject[] m_objectBackground = new GameObject[2];

    public Sprite Sprite;
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            var j = Instantiate(m_prefab, transform);
            m_objectBackground[i] = j;
        }
        m_objectBackground[1].transform.position = new Vector3(18, 0, 0);
    }

    void Update()
    {
        MoveObject();
        ChangePosition();
    }

    void MoveObject()
    {
        for (int i = 0; i < m_objectBackground.Length; i++)
        {
            transform.Translate(Vector3.left * m_speed * Time.deltaTime);
        }
    }

    void ChangePosition()
    {
        foreach (var i in m_objectBackground)
        {
            if (i.transform.position.x <= -18)
            {
                i.transform.position = new Vector3(18, 0, 0);
            }
        }
    }
}
