using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crab Name", menuName = "Crab So")]
public class CrabSO : ScriptableObject
{
    [SerializeField]
    private int number;
    public int Number { get { return number; } }

    [SerializeField]
    private Sprite image;
    public Sprite Image { get { return image; } }
}
