using UnityEngine;

public class SatisfactionManager : Singleton<SatisfactionManager>
{
    private int _satisfaction = 10;

    public int Satisfaction { get => _satisfaction; set => _satisfaction = value; }

    public void AddSatisfaction(int addValue)
    {
        Debug.Log($"[SatisfactionManager] 만족도 {addValue} 상승");
        _satisfaction += addValue;
    }

    public void SubSatisfaction(int subValue)
    {
        if(_satisfaction <= 0 )
        {
            _satisfaction = 0;
        }
        Debug.Log($"[SatisfactionManager] 만족도 {subValue} 하락");
        _satisfaction -= subValue;
    }
}
