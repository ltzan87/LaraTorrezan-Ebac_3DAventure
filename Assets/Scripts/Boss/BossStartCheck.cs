using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour
{
    public string tagToCheck = "Player";


    public GameObject boss;
    public GameObject bossCamera;

    public Color gizmoColor = Color.yellow;


    private void Awake() {
        boss.SetActive(false);
        bossCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == tagToCheck)
        {
            TurnBossOn();
            TurnCameraOn();
        }
    }

    private void TurnBossOn()
    {
        boss.SetActive(true);
    }

    private void TurnCameraOn()
    {
        bossCamera.SetActive(true);
    }

    private void OnDrawGizmos() {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, transform.localScale.y);
    }
}