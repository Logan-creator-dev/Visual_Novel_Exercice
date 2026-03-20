using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newThumbnail", menuName = "Thumbnail")]
public class ThumbnailData : ScriptableObject
{
    public  Sprite ThumbnailImage;
    public  string Description;
    public List<ChoiceData> ChoiceData;
    public ItemData GivenItem;
    
    

}