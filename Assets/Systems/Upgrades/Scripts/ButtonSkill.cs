using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ButtonSkillData _data;
    [SerializeField] private ButtonSkill[] _openningSkills;
    [SerializeField] private LineRenderer _rayPrefab;

    [Header("Components")]
    [SerializeField] private Image _infoPanel;
    [SerializeField] private Image _levelPanel;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _currentLevel;

    [Header("Settings")]
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _header;
    [SerializeField] private TMP_Text _description;

    private int _currentSkillLevel = 0;
    private int _maxLevel;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void Start()
    {
        _icon.sprite = _data.Icon;
        _header.text = _data.Header;
        _description.text = _data.Description;
        _maxLevel = _data.MaxLevel;

        _currentLevel.text = _currentSkillLevel.ToString();
        _infoPanel.gameObject.SetActive(false);
    }

    private void OnButtonClicked()
    {
        _currentSkillLevel++;

        if (_currentSkillLevel == _maxLevel)
        {
            foreach (var skill in _openningSkills)
            {
                skill.Activate();
                CreateRay(skill.transform.position);
            }

            _button.interactable = false;
        }

        _currentLevel.text = _currentSkillLevel.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _infoPanel.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _infoPanel.gameObject.SetActive(false);
    }

    public void Activate()
    {
        _button.interactable = true;
        _icon.color = Color.white;
        _levelPanel.gameObject.SetActive(true);
    }

    private void CreateRay(Vector3 target)
    {
        StartCoroutine(LineRendering(target));
    }

    private IEnumerator LineRendering(Vector3 target)
    {
        var line = Instantiate(_rayPrefab, transform);
        line.widthMultiplier = 0.2f;
        line.SetPosition(0, transform.position);

        Vector3 currentPoint = transform.position;
        float speed = 10;

        while  (currentPoint != target)
        {
            currentPoint = Vector3.MoveTowards(currentPoint, target, Time.deltaTime * speed);
            line.SetPosition(1, currentPoint);

            yield return null;
        }
    }
}
