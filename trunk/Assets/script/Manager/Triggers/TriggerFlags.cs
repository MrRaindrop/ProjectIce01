using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerFlags : MonoBehaviour {

    public bool[] conditionFlags = new bool[Loop.FlagConstants.TOTAL_NUM];
    public bool[] isToReverse = new bool[Loop.FlagConstants.TOTAL_NUM];
    public bool[] isToSet = new bool[Loop.FlagConstants.TOTAL_NUM];
    public bool[] setFlagTo = new bool[Loop.FlagConstants.TOTAL_NUM];
    //public Dictionary<int, bool> dic = new Dictionary<int, bool>(10);

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Loop.FlagConstants.TOTAL_NUM; i++) {
            if (isToReverse[i] && isToSet[i])
            {
                Debug.LogError("Name : " + gameObject.name);
                Debug.LogError("Error : TriggerFlags -> 同一个Flag不能同时设置isToReverse和isToSet两个选项");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        
        // 测试是否满足条件flag
        if (Loop.FlagManager.TestFlags(conditionFlags)) {

            for (int i = 0; i < Loop.FlagConstants.TOTAL_NUM; i++) {
                if (isToReverse[i])
                    Loop.FlagManager.ReverseFlag(i);
                else if (isToSet[i] && setFlagTo[i])
                    Loop.FlagManager.SetFlag(i);
                else if (isToSet[i] && !setFlagTo[i])
                    Loop.FlagManager.ResetFlag(i);
            }

        };
    }
}
