using System.Collections;
using UnityEngine;

public class PlayerAnimation
{
    [SerializeField] private Sprite[] m_animSprite;
    [SerializeField] private float m_delayAnimation;
    [SerializeField] private SpriteRenderer m_renderer;

    public PlayerAnimation(Sprite[] animSprite, float delay, SpriteRenderer renderer)
    {
        m_animSprite = animSprite;
        m_delayAnimation = delay;
        m_renderer = renderer;
        m_renderer.sprite = m_animSprite[0];
    }

    public void RotateSprite(float angle, Transform parent)
    {
        m_renderer.transform.eulerAngles = new Vector3(0, 0, angle);
        m_renderer.transform.position = parent.transform.position;
    }

    public IEnumerator Animation()
    {
        for (int i = 1; i < m_animSprite.Length; i++)
        {
            yield return new WaitForSeconds(m_delayAnimation);
            m_renderer.sprite = m_animSprite[i];
        }
        yield return new WaitForSeconds(m_delayAnimation);
        m_renderer.sprite = m_animSprite[0];
    }
}
