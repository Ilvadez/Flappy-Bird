using System;

public class ChangeBackground : IChangeIndex
{
    public int Index { get; private set; } = 0;

    public void IncreaseIndexSprite(int length)
    {
        if(length <= 0)
        {
           return; 
        }
        Index = (Index + 1) % length;
    }
    public void DecreaseIndexSprite(int length)
    {
        if(length <= 0)
        {
            return;
        }
        Index = (Index - 1 + length) % length;
    }
}