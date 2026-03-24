using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct ChoiceData
{
    public string Choice;
    public ThumbnailData LinkedThumbnail;
    public ItemData NeededItem;
    public bool HideIfMissingItem;

    private void OnEnable()
    {
        if (HideIfMissingItem) HideIfMissingItem = true;
    }
}
