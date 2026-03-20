using System;
using TMPro;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "newItem", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public Sprite ItemImage;
    public string Description;
    
}
