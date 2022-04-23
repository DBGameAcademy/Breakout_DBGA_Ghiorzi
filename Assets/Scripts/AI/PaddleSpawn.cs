using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpawn : MonoBehaviour
{
    public float Range { get => range; }
    public bool IsFree { get; private set; }

    public GameObject spawnPrefab;

    [SerializeField]
    public float range;

    public GameObject Spawn()
    {
        if (!IsFree)
            return null;

        GameObject paddleObj = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        return paddleObj;
    }

    private void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.tag.ToLower().Equals("paddle"))
            {
                IsFree = false;
                return;
            }
        }
        IsFree = true;
    }
}
