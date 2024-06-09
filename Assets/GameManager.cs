using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int eggCount = 1;
    public int chickCount = 0;
    public int henCount = 0;
    public int roosterCount = 0;

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(10f);
        HatchEgg();
    }

    void HatchEgg()
    {
        if (eggCount > 0)
        {
            eggCount--;
            chickCount++;
            StartCoroutine(MatureFirstChick());
        }
    }

    IEnumerator MatureFirstChick()
    {
        yield return new WaitForSeconds(10f); 

        chickCount--;

        
        henCount++;
        StartCoroutine(FirstHenLifeCycle());
    }

    IEnumerator FirstHenLifeCycle()
    {
        yield return new WaitForSeconds(30f); 

        int newEggs = Random.Range(2, 11); 
        eggCount += newEggs;

        
        for (int i = 0; i < newEggs; i++)
        {
            StartCoroutine(HatchNewEgg());
        }

        yield return new WaitForSeconds(10f); 

        henCount--;
    }

    IEnumerator HatchNewEgg()
    {
        yield return new WaitForSeconds(10f);
        HatchAnotherEgg();
    }

    void HatchAnotherEgg()
    {
        if (eggCount > 0)
        {
            eggCount--;
            chickCount++;
            StartCoroutine(MatureChick());
        }
    }

    IEnumerator MatureChick()
    {
        yield return new WaitForSeconds(10f); 

        chickCount--;

        
        if (Random.Range(0, 2) == 0)
        {
            henCount++;
            StartCoroutine(HenLifeCycle());
        }
        else
        {
            roosterCount++;
            StartCoroutine(RoosterLifeCycle());
        }
    }

    IEnumerator HenLifeCycle()
    {
        yield return new WaitForSeconds(10f); 

        int newEggs = Random.Range(2, 11); 
        eggCount += newEggs;

        // Start hatching the new eggs
        for (int i = 0; i < newEggs; i++)
        {
            StartCoroutine(HatchNewEgg());
        }

        yield return new WaitForSeconds(30f); 

        henCount--;
    }

    IEnumerator RoosterLifeCycle()
    {
        yield return new WaitForSeconds(40f); 
        roosterCount--;
    }
}
