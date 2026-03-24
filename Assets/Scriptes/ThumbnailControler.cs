using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailController : MonoBehaviour
{

    [SerializeField] private ThumbnailData _firstThumbnail;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _itemPanelTransform;
    [SerializeField] private InventoryUpdate inventoryUpdate;
    [SerializeField] private GameObject restartButton;
    
    
    [SerializeField] private Image _thumbnail;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Transform _choicePanelTransform;
    
    private void Start()
    {
        DisplayThumbnail(_firstThumbnail);
    }


    private void DisplayThumbnail(ThumbnailData data)
    {
        _thumbnail.sprite = data.ThumbnailImage;
        _description.text = data.Description;

         if (data.GivenItem != null)
         {
             inventoryUpdate.AddItem(data.GivenItem);
         } 

        // Clear choices
        foreach (Transform child in _choicePanelTransform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate choices
        foreach (ChoiceData choiceData in data.ChoiceData)
        {
             bool hasItem = choiceData.NeededItem == null || InventoryUpdate.Inventory.Contains(choiceData.NeededItem);

             if (!hasItem && choiceData.HideIfMissingItem)
             {
                 continue;
             }
             /*if (choiceData.LinkedThumbnail.GivenItem != null &&
                 InventoryUpdate.Inventory.Contains(choiceData.LinkedThumbnail.GivenItem))
             {
                 continue;
             }*/
             GameObject instantiate = Instantiate(_buttonPrefab, _choicePanelTransform);
             instantiate.GetComponentInChildren<TextMeshProUGUI>().text = choiceData.Choice;
             instantiate.GetComponent<Button>().onClick.AddListener(() =>
             {
                 DisplayThumbnail(choiceData.LinkedThumbnail);
             });

             if (!hasItem)
             {
                 Button btn = instantiate.GetComponent<Button>();
                 btn.interactable = false;
                 
                 var text = instantiate.GetComponentInChildren<TextMeshProUGUI>();
                 text.color = Color.gray;
             }
             
             
        }

        if (data.isBadEnding)
        {
            restartButton.SetActive(true);
        }
        else
        {
            restartButton.SetActive(false);
        }
    }
    
    public void RestartGame()
    {
        InventoryUpdate.Inventory.Clear();
        inventoryUpdate.RenderInventory();
        DisplayThumbnail(_firstThumbnail);
    }
}  
   
  
