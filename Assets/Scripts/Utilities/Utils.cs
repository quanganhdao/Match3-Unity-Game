using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }
    /// <summary>
    /// Get the type of item that has the least in the board
    /// </summary>
    /// <returns></returns>
    public static NormalItem.eNormalType GetDifferentTypeWithSurrounded(Cell[,] cells, Cell cellToSpawnItem)
    {
        Dictionary<NormalItem.eNormalType, int> countOfType = new Dictionary<NormalItem.eNormalType, int>();
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (cells[i, j].Item == null  || !(cells[i,j].Item is NormalItem)  ) continue;
                var item = cells[i, j].Item as NormalItem;
                if (!countOfType.ContainsKey(item.ItemType))
                {
                    countOfType[item.ItemType] = 1;
                    continue;
                }
                countOfType[item.ItemType] += 1;
            }

        }
        if (cellToSpawnItem.NeighbourUp != null && cellToSpawnItem.NeighbourUp.Item != null && countOfType.ContainsKey((cellToSpawnItem.NeighbourUp.Item as NormalItem).ItemType))
            countOfType.Remove((cellToSpawnItem.NeighbourUp.Item as NormalItem).ItemType);
        if (cellToSpawnItem.NeighbourBottom != null && cellToSpawnItem.NeighbourBottom.Item != null && countOfType.ContainsKey((cellToSpawnItem.NeighbourBottom.Item as NormalItem).ItemType))

            countOfType.Remove((cellToSpawnItem.NeighbourBottom.Item as NormalItem).ItemType);
        if (cellToSpawnItem.NeighbourLeft != null && cellToSpawnItem.NeighbourLeft.Item != null && countOfType.ContainsKey((cellToSpawnItem.NeighbourLeft.Item as NormalItem).ItemType))

            countOfType.Remove((cellToSpawnItem.NeighbourLeft.Item as NormalItem).ItemType);
        if (cellToSpawnItem.NeighbourRight != null && cellToSpawnItem.NeighbourRight.Item !=null && countOfType.ContainsKey((cellToSpawnItem.NeighbourRight.Item as NormalItem).ItemType))

            countOfType.Remove((cellToSpawnItem.NeighbourRight.Item as NormalItem).ItemType);
        var minKey = countOfType.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
        Debug.Log(minKey.ToString() + " " + countOfType[minKey]);


        return minKey;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }
}
