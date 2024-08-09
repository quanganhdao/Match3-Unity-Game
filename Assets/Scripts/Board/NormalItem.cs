using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }
    public override void SetView(ItemSkinSet skinSet)
    {

        GameObject prefab = Resources.Load<GameObject>(Constants.PREFAB_ITEM_BASE);
        if (prefab)
        {
            GameObject go = GameObject.Instantiate(prefab);
            View = go.transform;
            go.GetComponent<SpriteRenderer>().sprite = GetSkin(skinSet).skin;
        }
    }

    public ItemSkin GetSkin(ItemSkinSet skinSet)
    {
        ItemSkin skin = null;
        switch (ItemType)
        {
            case eNormalType.TYPE_ONE:
                skin = skinSet.itemSkins[0];
                break;
            case eNormalType.TYPE_TWO:
                skin = skinSet.itemSkins[1];
                break;
            case eNormalType.TYPE_THREE:
                skin = skinSet.itemSkins[2];
                break;
            case eNormalType.TYPE_FOUR:
                skin = skinSet.itemSkins[3];
                break;
            case eNormalType.TYPE_FIVE:
                skin = skinSet.itemSkins[4];
                break;
            case eNormalType.TYPE_SIX:
                skin = skinSet.itemSkins[5];
                break;
            case eNormalType.TYPE_SEVEN:
                skin = skinSet.itemSkins[6];
                break;
        }
        return skin;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
