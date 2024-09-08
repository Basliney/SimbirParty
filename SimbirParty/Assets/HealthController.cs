using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] Slider _foodSlider;
    [SerializeField] Slider _alkoSlider;

    void Start()
    {
        var food = PlayerPrefs.GetInt("food", 100);
        var alko = PlayerPrefs.GetInt("alko", 100);
    }


}
