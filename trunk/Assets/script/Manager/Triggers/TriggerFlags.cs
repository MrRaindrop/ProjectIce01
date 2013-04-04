using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Loop/Trigger Flags")]

public class TriggerFlags : MonoBehaviour {

    public bool[] conditionFlags = new bool[Loop.FlagConstants.TOTAL_NUM];
    public bool[] conditionFlagsValue = new bool[Loop.FlagConstants.TOTAL_NUM];
    public bool[] isToReverse = new bool[Loop.FlagConstants.TOTAL_NUM];
    public bool[] isToSet = new bool[Loop.FlagConstants.TOTAL_NUM];
    public bool[] setFlagTo = new bool[Loop.FlagConstants.TOTAL_NUM];
    //public Dictionary<int, bool> dic = new Dictionary<int, bool>(10);

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Loop.FlagConstants.TOTAL_NUM; i++) {

            if (!conditionFlags[i] && conditionFlagsValue[i]) {
                Debug.LogError("Name : " + gameObject.name);
                Debug.LogError("Error : TriggerFlags -> ��" + (i+1) + "����־û�й�ѡ��ȴ������ֵΪtrue");
            }

            if (isToReverse[i] && isToSet[i])
            {
                Debug.LogError("Name : " + gameObject.name);
                Debug.LogError("Error : TriggerFlags -> ͬһ����־����ͬʱ����isToReverse��isToSet����ѡ��");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        
        // �����Ƿ���������flag
        if (Loop.FlagManager.TestFlags(conditionFlags, conditionFlagsValue)) {

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

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 0.7f, 0.9f);
        Gizmos.DrawSphere(transform.position + new Vector3(-0.5f, 1.0f, 0), 0.2f);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-0.5f, 1.0f, 0));
    }
}
