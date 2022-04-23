using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : Singleton<BlockController>
{
    public int BlocksCount { get; private set; }

    [SerializeField]
    private GameObject blockPrefab;

    private List<Vector3> _blockPositions = new List<Vector3>();
    private List<int> _blockHits = new List<int>();
    private List<int> _blocksScore = new List<int>();
    private List<GameObject> _blockEffects = new List<GameObject>();

    private Block[] _blocks;

    protected override void Awake()
    {
        base.Awake();
        _blocks = GetComponentsInChildren<Block>();

        foreach(Block block in _blocks)
        {
            _blockPositions.Add(block.transform.position);
            _blockHits.Add(block.Hits);
            _blocksScore.Add(block.ScoreValue);
            _blockEffects.Add(block.Effect);
        }

        ResetBlocks();
    }

    private void Update()
    {
        BlocksCount = GetComponentsInChildren<Block>().Length;
    }

    public void ResetBlocks()
    {
        // Remove old blocks
        for(int i = _blocks.Length -1; i>=0; i--)
        {
            if(_blocks[i] != null)
            {
                Destroy(_blocks[i].gameObject);
            }
        }
        // Add new blocks
        for(int i=0; i<_blockPositions.Count; ++i)
        {
            GameObject newBlockObj = Instantiate(blockPrefab, _blockPositions[i], Quaternion.identity, transform);
            newBlockObj.GetComponent<Block>().Hits = _blockHits[i];
            newBlockObj.GetComponent<Block>().ScoreValue = _blocksScore[i];
            newBlockObj.GetComponent<Block>().Effect = _blockEffects[i];
            _blocks[i] = newBlockObj.GetComponent<Block>();
        }
    }

   
}
