using UnityEngine;
using System.Collections;


namespace Loop
{

    public class Test
    {

        public static void TestPlayerPrefsX(){

            bool b1 = true;
            bool _b1;
            bool b2 = false;

            Vector2 v1 = new Vector2(1, 1);
            Vector2 _v1;
            Vector2 v2 = new Vector2(2, 2);

            Vector3 v3 = new Vector3(1, 1, 1);
            Vector3 _v3;
            Vector3 v4 = new Vector3(2, 2, 2);

            Quaternion q1 = Quaternion.Euler(v3);
            Quaternion _q1;
            Quaternion q2 = Quaternion.Euler(v4);

            Color c1 = new Color(0, 1, 1);
            Color _c1;
            Color c2 = new Color(1, 0, 0);

            int[] ia = new int[2] { 0, 1 };
            int[] _ia;
            float[] fa = new float[2] { 0.5f, 1.5f };
            float[] _fa;
            bool[] ba = new bool[2] { true, false };
            bool[] _ba;
            string[] sa = new string[2] { "abc", "def" };
            string[] _sa;
            Vector2[] v2a = new Vector2[2] { v1, v2 };
            Vector2[] _v2a;
            Vector3[] v3a = new Vector3[2] { v3, v4 };
            Vector3[] _v3a;
            Quaternion[] qa = new Quaternion[2] { q1, q2 };
            Quaternion[] _qa;
            Color[] ca = new Color[2] { c1, c2 };
            Color[] _ca;

            // save data.
            Loop.PlayerPrefsX.SetBool("b1", b1);
            Loop.PlayerPrefsX.SetVector2("v1", v1);
            Loop.PlayerPrefsX.SetVector3("v3", v3);
            Loop.PlayerPrefsX.SetQuaternion("q1", q1);
            Loop.PlayerPrefsX.SetColor("c1", c1);
            Loop.PlayerPrefsX.SetIntArray("ia", ia);
            Loop.PlayerPrefsX.SetFloatArray("fa", fa);
            Loop.PlayerPrefsX.SetBoolArray("ba", ba);
            Loop.PlayerPrefsX.SetVector2Array("v2a", v2a);
            Loop.PlayerPrefsX.SetVector3Array("v3a", v3a);
            Loop.PlayerPrefsX.SetQuaternionArray("qa", qa);
            Loop.PlayerPrefsX.SetColorArray("ca", ca);

            // load data.
            _b1 = Loop.PlayerPrefsX.GetBool("b1");
            _v1 = Loop.PlayerPrefsX.GetVector2("v1");
            _v3 = Loop.PlayerPrefsX.GetVector3("v3");
            _q1 = Loop.PlayerPrefsX.GetQuaternion("q1");
            _c1 = Loop.PlayerPrefsX.GetColor("c1");
            _ia = Loop.PlayerPrefsX.GetIntArray("ia");
            _fa = Loop.PlayerPrefsX.GetFloatArray("fa");
            _ba = Loop.PlayerPrefsX.GetBoolArray("ba");
            _v2a = Loop.PlayerPrefsX.GetVector2Array("v2a");
            _v3a = Loop.PlayerPrefsX.GetVector3Array("v3a");
            _qa = Loop.PlayerPrefsX.GetQuaternionArray("qa");
            _ca = Loop.PlayerPrefsX.GetColorArray("ca");

            bool p1 = (_b1 == b1);
            bool p2 = (_v1 == v1);
            bool p3 = (_v3 == v3);
            bool p4 = (_q1 == q1);
            bool p5 = (_c1 == c1);
            bool p6 = true, p7 = true, p8 = true, p9 = true, p10 = true, p11 = true, p12 = true;

            for (int i = 0; i < _ia.Length; i++)
                if (_ia[i] != ia[i])
                    p6 = false;

            for (int i = 0; i < _fa.Length; i++)
                if (_fa[i] != fa[i])
                    p7 = false;

            for (int i = 0; i < _ba.Length; i++)
                if (_ba[i] != ba[i])
                    p8 = false;

            for (int i = 0; i < _v2a.Length; i++)
                if (_v2a[i] != v2a[i])
                    p9 = false;

            for (int i = 0; i < _v3a.Length; i++)
                if (_v3a[i] != v3a[i])
                    p10 = false;

            for (int i = 0; i < _qa.Length; i++)
                if (_qa[i] != qa[i])
                    p11 = false;

            for (int i = 0; i < _ca.Length; i++)
                if (_ca[i] != ca[i])
                    p12 = false;

            if (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12)
                Debug.Log("Test PlayerPrefsX.cs is worked correctly!");
            else
                Debug.LogError("Error : Test PlayerPrefsX.cs not working");
        }

    }

}
