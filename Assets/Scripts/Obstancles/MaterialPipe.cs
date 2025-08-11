using UnityEngine;

public class MaterialPipe : MonoBehaviour, ISetMaterial
{
    [SerializeField] private GameObject[] m_pipe;

    public void SetMaterial(Material material)
    {
        foreach (var i in m_pipe)
        {
            Material[] mat = i.GetComponent<MeshRenderer>().materials;
            mat[0] = material;
            i.GetComponent<MeshRenderer>().materials = mat;
        }
        
    }
}
