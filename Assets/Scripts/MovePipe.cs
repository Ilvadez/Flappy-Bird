using UnityEngine;

public class MovePipes : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject[] m_pipe;
    private float m_endCameraSize;
    void Start()
    {
        m_endCameraSize = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * m_speed);
        if (transform.position.x <= -m_endCameraSize - 2f)
        {
            Destroy(this.gameObject);
        }
    }

    public void InitMaterial(Material material)
    {
        foreach (var i in m_pipe)
        {
            Material[] mat = i.GetComponent<MeshRenderer>().materials;
            mat[0] = material;
            i.GetComponent<MeshRenderer>().materials = mat;
        }
        
    }
}
