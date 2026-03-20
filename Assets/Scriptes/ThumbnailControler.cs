using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailController : MonoBehaviour {
    
    [SerializeField] private ThumbnailData _firstThumbnail;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _itemPanelTransform;
    
    
    [SerializeField] private Image _thumbnail;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Transform _choicePanelTransform;

    public List<ItemData> Inventory = new();

    private void Start() {
        DisplayThumbnail(_firstThumbnail);
    }

    
    private void DisplayThumbnail(ThumbnailData data) {
        _thumbnail.sprite = data.ThumbnailImage;
        _description.text = data.Description;
        
        // Clear choices
        foreach (Transform child in _choicePanelTransform) {
            Destroy(child.gameObject);
        }
        
        // Instantiate choices
        foreach (ChoiceData choiceData in data.ChoiceData) {
            GameObject instantiate = Instantiate(_buttonPrefab, _choicePanelTransform);
            instantiate.GetComponentInChildren<TextMeshProUGUI>().text = choiceData.Choice;
            instantiate.GetComponent<Button>().onClick.AddListener(() => {
                DisplayThumbnail(choiceData.LinkedThumbnail);
            });
        }
    }

    public void AddItem(ItemData GivenItem)
    {
        Inventory.Add(GivenItem);
    }
}