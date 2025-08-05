using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_strengthClick;
    private Rigidbody m_rigidBody;
    private InputSystem_Actions m_actions;
    void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_actions = new InputSystem_Actions();
    }
    void OnEnable()
    {
        m_actions.Enable();
        m_actions.Player.Jump.performed += ctx => Click();
    }

    private void Click()
    {
        m_rigidBody.linearVelocity = Vector3.zero;
        m_rigidBody.AddForce(transform.up * m_strengthClick, ForceMode.Force);
    }

    void OnDisable()
    {
        m_actions.Player.Jump.performed -= ctx => Click();
        m_actions.Disable();        
    }
}
