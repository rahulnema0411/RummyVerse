using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObjects/ImageCollection")]
public class ImageCollection : ScriptableObject
{
    public List<Sprite> sprites; 
}
