using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Item : MonoBehaviour
{
    public float time = 5; // 지속 시간
    protected GameObject player; // 아이템이 종속되어 있는 player
    protected bool trigger = false; // 한번 만났는지 확인
    protected float currentTime = 0; // 아이템 시작 시간
    protected bool usingItem = false; // 아이템 사용 여부

    protected float blinkTime = 3;
    protected float spriteBlinkingTimer = 0.0f; // 작은 깜박임 단위 시작 시간
    protected float spriteBlinkingMiniDuration = 0.1f; // 깜박임 빈도 시간
    protected float spriteBlinkingTotalTimer = 0.0f; // 전체 깜박임 시간
    protected float spriteBlinkingTotalDuration = 1.0f; // 깜박임 지속 시간
    protected bool startBlinking = false;

    protected ItemController ItemController;

    void Start()
    {
        ItemController = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemController>();
    }



    public virtual void UsingItem()
    {
        Debug.Log("Empty item");
    }

}
