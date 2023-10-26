using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class SpellsBadgeButton : MonoBehaviour
{
    [SerializeField] private int _index;

    private Button _button;

    public static event UnityAction<int> BadgeClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        BadgeClicked?.Invoke(_index);
    }
}
