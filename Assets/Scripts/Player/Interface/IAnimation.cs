using System.Collections;
using UnityEngine;

public interface IAnimationSprite
{
    public void RotateSprite(float angle, Transform parent);
    public IEnumerator Animation();
}
