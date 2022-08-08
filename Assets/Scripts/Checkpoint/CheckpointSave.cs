using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSave : MonoBehaviour
{
    public int currentLevel = 1;

    private bool _chekpointActive = false;


    private void OnTriggerEnter(Collider other) {
        Player p = other.transform.GetComponent<Player>();

        if(!_chekpointActive && p != null)
        {
            _chekpointActive = true;

            SaveManager.Instance.SaveLastCheckpoint(currentLevel);
        }
    }
}