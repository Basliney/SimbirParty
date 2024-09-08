using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] Slider _foodSlider;
    [SerializeField] Slider _alkoSlider;
    [SerializeField] GameObject _failureScreen;
    [SerializeField] public int step;
    public bool canChange = true;

    private float _food;
    private float _alko;

    void Start()
    {
        _food = PlayerPrefs.GetInt("food", 50);
        _alko = PlayerPrefs.GetInt("alko", 50);

        _foodSlider.value = _food;
        _alkoSlider.value = _alko;

        StartCoroutine(HealthRoutine());
    }

    private IEnumerator HealthRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (canChange)
            {
                _food -= step;
                _alko -= step;
                _foodSlider.value = Mathf.Clamp(_food, 0 ,100);
                _alkoSlider.value = Mathf.Clamp(_alko, 0, 100);

                if (_food <=0 || _food > 100 || _alko <=0 || _alko > 100)
                {
                    GameFailed();
                }
            }
        }
    }

    public void Add(TypeTarget typeTarget)
    {
        switch (typeTarget)
        {
            case TypeTarget.Food:
                _food += 20;
                break;

            case TypeTarget.Alko:
                _alko += 20;
                break;

            case TypeTarget.Quest:
                // вызов другой сцены и сохранения
                break;
        }
        _foodSlider.value = Mathf.Clamp(_food, 0, 100);
        _alkoSlider.value = Mathf.Clamp(_alko, 0, 100);
    }

    private void GameFailed()
    {
        _failureScreen.SetActive(true);
    }
}
