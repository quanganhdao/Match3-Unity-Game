using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName ="ItemSkinSet", menuName ="Item Skin Set")]
public class ItemSkinSet : ScriptableObject
{
    public List<ItemSkin> itemSkins = new List<ItemSkin>();
}
