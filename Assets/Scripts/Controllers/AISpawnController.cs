using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnController : Singleton<AISpawnController>
{
    [SerializeField]
    private PaddleSpawn leftSpawn;
    [SerializeField]
    private PaddleSpawn rightSpawn;

    private GameObject _paddleObj;

    public void SpawnPaddle()
    {
        if (_paddleObj != null)
        {
            DestroyPaddle();
        }

        if (leftSpawn.IsFree)
        {
            _paddleObj = leftSpawn.Spawn();
        }
        else
        {
            _paddleObj = rightSpawn.Spawn();
        }
    }

    public void DestroyPaddle()
    {
        if(_paddleObj == null)
            return;

        Destroy(_paddleObj);
    }
}
