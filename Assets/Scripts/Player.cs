using System;
using System.Collections;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_strengthClick;
    [SerializeField] private Sprite[] m_animSprite;
    [SerializeField] private float m_delayAnimation;
    [SerializeField] private SpriteRenderer m_renderer;
    private Rigidbody m_rigidBody;
    private InputSystem_Actions m_actions;
    void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_renderer.sprite = m_animSprite[0];
        m_actions = new InputSystem_Actions();
    }
    void OnEnable()
    {
        m_actions.Enable();
        m_actions.Player.Jump.performed += ctx => Click();
    }
    void Update()
    {
        float angle = math.clamp(Vector3.Angle(Vector3.right, m_rigidBody.linearVelocity), -45, 45);//Vector3.Angle(Vector3.right, m_rigidBody.linearVelocity);
        if (m_rigidBody.linearVelocity.y < 0)
        {
            angle = -angle;
        }
        //transform.eulerAngles = new Vector3(0, 0, angle);
        m_renderer.transform.eulerAngles = new Vector3(0, 0, angle);
        m_renderer.transform.position = transform.position;
    }
    private void Click()
    {
        m_rigidBody.linearVelocity = Vector3.zero;
        m_rigidBody.AddForce(transform.up * m_strengthClick, ForceMode.Force);
        StartCoroutine(Animation(m_delayAnimation));
    }
    IEnumerator Animation(float delay)
    {
        for (int i = 1; i < m_animSprite.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            m_renderer.sprite = m_animSprite[i];
        }
        yield return new WaitForSeconds(delay);
        m_renderer.sprite = m_animSprite[0];
    }
    public void OnDisable()
    {
        m_actions.Player.Jump.performed -= ctx => Click();
        m_actions.Disable();
           
    }
}
