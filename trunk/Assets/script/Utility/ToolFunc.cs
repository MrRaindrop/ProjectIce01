using UnityEngine;
using System.Collections;

public static class ToolFunc {

    // shuffle cards
    public static void Shuffle<T>(T[] set) {
        for (int i = 0; i < set.Length; i++) {
            T tmp = set[i];
            int ri = Random.Range(0, set.Length);
            set[i] = set[ri];
            set[ri] = tmp;
        }
    }

    // choose a probility from a set of probilities
    public static int ChooseProb(float[] probs)
    {
        float total = 0f;
        
        foreach(float p in probs){
            total += p;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++) {
            if (randomPoint < probs[i])
                return i;
            else
                randomPoint -= probs[i];
        }

        return probs.Length - 1;
    }

    // random choose 'numRequired' items from a item set 'from'
    public static T[] ChooseSet<T>(int numRequired, T[] from)
    {

        T[] results = new T[numRequired];

        int numToChoose = numRequired;
        int numLeft;
        for (numLeft = from.Length; numLeft > 0; numLeft--)
        {
            float prob = (numToChoose + 0.0f) / (numLeft + 0.0f);
            if (Random.value <= prob)
            {
                numToChoose--;
                results[numToChoose] = from[numLeft - 1];

                if (numToChoose == 0)
                    break;
            }
        }

        return results;
    }
}