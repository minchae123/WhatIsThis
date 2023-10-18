using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackGround : MonoBehaviour
{
    [SerializeField] private List<Sprite> background;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private int test = 0;
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.W)) // 디버그용
        {
            ChangingBackGround(test);
            test++;
        }
    }

    public void ChangingBackGround(int num) // 몇 번째 배경
    {
        if (num >= background.Count) return; // 리스트 넘어가면 리턴
        sr.sprite = background[num];
    }
}
