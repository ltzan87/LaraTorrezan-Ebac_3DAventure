using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public List<CheckpointBase> checkpoints;
    public int lastCheckPointKey = 0;


    public bool HasCheckpoint()
    {
        return lastCheckPointKey > 0; 
    }

    public void SaveCheckpoint(int i)
    {
        if(i > lastCheckPointKey)
        {
            lastCheckPointKey = i;
        }
    }

    public Vector3 GetPositionFromLastCheckpoint()
    {
        var checkpoint = checkpoints.Find(i=> i.key == lastCheckPointKey);
        return checkpoint.transform.position;
    }
}