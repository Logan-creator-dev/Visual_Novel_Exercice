using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
   [SerializeField] private TMP_Text _stuffName;
   
    List<string> stuffNames = new List<string>();

    public void AddStuff(string stuffName)
    {
        stuffNames.Add(stuffName);
    }
       
       
       
   
}
