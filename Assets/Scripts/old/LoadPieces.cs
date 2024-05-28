
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCreator : MonoBehaviour
{
    public GameObject puzzlePiecePrefab; // Assign your puzzle piece prefab in the inspector
    public Sprite[] images; // Assign your images in the inspector

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject piece = Instantiate(puzzlePiecePrefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            piece.GetComponent<SpriteRenderer>().sprite = images[i];
        }
    }
}

