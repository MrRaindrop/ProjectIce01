using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    private float _moveSpeed;
    private float _runSpeed;
    private float _jumpSpeed;

    private int _enemyIndex = -1;
    private Loop.Enemy _enm = null;

    public int EnemyIndex
    {
        get { return _enemyIndex; }
        set { _enemyIndex = value; }
    }

	// Use this for initialization
	void Start () {

	    if(_enemyIndex == -1)
            throw new System.MissingFieldException("enemyIndex missing @ EnemyAI.Start()");
        
        // 初始化能力值
        _enm = GetEnemyInstance(_enemyIndex);
        _moveSpeed = _enm.MoveSpeed;
        _runSpeed = _enm.RunSpeed;
        _jumpSpeed = _enm.JumpSpeed;

	}
	
	// Update is called once per frame
	void Update () {
	    
        // TODO : ...敌人行动

	}

    // 获取当前物件所对应Enemy类的实例
    private Loop.Enemy GetEnemyInstance(int index) {

        return Loop.CharacterManager.GetEnemyInstance(index);

    }
}
