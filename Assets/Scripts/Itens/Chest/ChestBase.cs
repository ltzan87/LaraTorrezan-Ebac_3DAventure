using System.Data;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.E;

    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]
    public GameObject icon;
    public float tweenDuration = .2f; 
    public Ease tweemEase = Ease.OutBack;

    [Space]
    public ChestItemBase chestItem;

    private float startScale;
    private bool _chestOpened = false;


    private void Start() {
        startScale = icon.transform.localScale.x;
        HideIcon();
    }

    private void Update() {
        if(Input.GetKeyDown(keyCode) && icon.activeSelf)
        {
            OpenChest();
        }
    }


    [NaughtyAttributes.Button]
    private void OpenChest()
    {
        if(_chestOpened) return;

        animator.SetTrigger(triggerOpen);
        _chestOpened = true;
        HideIcon();
        Invoke(nameof(ShowItem), 1f);
    }

    private void ShowItem()
    {
        chestItem.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }

    private void CollectItem()
    {
        chestItem.Collect();
    }

    private void OnTriggerEnter(Collider other) {
        Player p = other.transform.GetComponent<Player>();
        if(p != null)
        {
            ShowIcon();
        }
    }
    private void OnTriggerExit(Collider other) {
        Player p = other.transform.GetComponent<Player>();
        if(p != null)
        {
            HideIcon();
        }
    }

    [NaughtyAttributes.Button]
    private void ShowIcon()
    {
        icon.SetActive(true);
        icon.transform.localScale = Vector3.zero;
        icon.transform.DOScale(startScale, tweenDuration);
    }
    [NaughtyAttributes.Button]
    private void HideIcon()
    {
        icon.SetActive(false);
    }
}