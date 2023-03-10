using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private Vector3 TileSize;
    [SerializeField] private GameObject Prefab;

    public void Generate()
    {
        DestroyAllChild();
        for (int i = 0; i < TileSize.x; i++)
        {
            for (int j = 0; j < TileSize.y; j++)
            {
                for (int k = 0; k < TileSize.z; k++)
                {
                    GameObject go = Instantiate(Prefab, transform);
                    go.transform.localPosition = new Vector3(
                        (-TileSize.x / 2) + i + (TileSize.x % 2 == 0 ? 0 :0.5f),
                        (-TileSize.y / 2) + j+ (TileSize.y % 2 == 0 ? 0 :0.5f),
                        (-TileSize.z / 2) + k+ (TileSize.z % 2 == 0 ? 0 :0.5f));
                }
            }
        }
    }

    public void DestroyAllChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
            i--;
        }
    }
}