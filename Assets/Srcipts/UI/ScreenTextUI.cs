using TMPro;
using UnityEngine;

public class ScreenTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statText;


    void Update()
    {

        _statText.text = $"Rate : {SatisfactionManager.Instance.Satisfaction}\n" +
            $"Balane : {StoreBalanceManager.Instance.Balance}";
    }
}
