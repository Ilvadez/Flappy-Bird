using UnityEngine;

public interface IChangeIndex
{
    public int Index {get;}

    public void IncreaseIndexSprite(int length);
    
    public void DecreaseIndexSprite(int length);
} 
