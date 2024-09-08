using UnityEngine;
using UnityEngine.UI;

public class ReactionPlayer : MonoBehaviour
{
    [SerializeField] private Slider _gameSlider;
    [SerializeField] private Interaction _interaction;
    private float[] _points;
    private bool toRight;

    public void StartGame()
    {
        _gameSlider.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var value = _gameSlider.value;
            if (value >= 45 && value <= 55)
            {
                _interaction.SliderInteract(SliderValues.Great);
            }
            else if (value < 45)
            {
                _interaction.SliderInteract(SliderValues.Great);
            }
            else
            {
                _interaction.SliderInteract(SliderValues.Bad);
            }

            _gameSlider.gameObject.SetActive(false);
        }
    }
}

public enum SliderValues
{
    Bad,
    Normal,
    Great
}
