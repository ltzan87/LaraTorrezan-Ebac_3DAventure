using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]
    public GameObject icon;
    public float tweenDuration = .2f; 
    public Ease tweemEase = Ease.OutBack;
    private float startScale;


    private void Start() {
        startScale = icon.transform.localScale.x;
        HideIcon();
    }

    [NaughtyAttributes.Button]
    private void OpenChest()
    {
        animator.SetTrigger(triggerOpen);
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