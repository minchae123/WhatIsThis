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
        if(Input.GetKeyDown(KeyCode.W)) // ����׿�
        {
            ChangingBackGround(test);
            test++;
        }
    }

    public void ChangingBackGround(int num) // �� ��° ���
    {
        if (num >= background.Count) return; // ����Ʈ �Ѿ�� ����
        sr.sprite = background[num];
    }
}
