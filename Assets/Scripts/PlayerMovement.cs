using System;
using System.Collections;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_strengthClick;
    [SerializeField] private Sprite[] m_animSprite;
    [SerializeField] private float m_delayAnimation;
    [SerializeField] private SpriteRenderer m_renderer;
    private Rigidbody m_rigidBody;
    private InputSystem_Actions m_actions;
    private PlayerAnimation m_anim;
    void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_anim = new PlayerAnimation(m_animSprite, m_delayAnimation, m_renderer);
        m_actions = new InputSystem_Actions();
    }
    void OnEnable()
    {
        m_actions.Enable();
        m_actions.Player.Jump.performed += ctx => Click();
    }
    void Update()
    {
        float angle = math.clamp(Vector3.Angle(Vector3.right, m_rigidBody.linearVelocity), -45, 45);
        if (m_rigidBody.linearVelocity.y < 0)
        {
            angle = -angle;
        }
        m_anim.RotateSprite(angle,transform);
    }
    private void Click()
    {
        m_rigidBody.linearVelocity = Vector3.zero;
        m_rigidBody.AddForce(transform.up * m_strengthClick, ForceMode.Force);
        StartCoroutine(m_anim.Animation());
    }
    public void OnDisable()
    {
        m_actions.Player.Jump.performed -= ctx => Click();
        m_actions.Disable();
           
    }
}
