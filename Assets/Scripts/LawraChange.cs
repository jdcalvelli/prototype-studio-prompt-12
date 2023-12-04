using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawraChange : MonoBehaviour
{
    public enum lawraStates
    {
        CLEAR,
        PEEKING,
        LOOKING,
    }

    public lawraStates currentState = lawraStates.CLEAR;

    [SerializeField] private Sprite lawraPeeking;
    [SerializeField] private Sprite lawraLooking;

    /// <summary>
    /// check if lawra should go to a new state
    /// </summary>
    public IEnumerator LawraBehavior()
    {
        // so as to not create a bunch of coroutines by doing it recursively
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 4));
            // switch to lawraPeeking state, and start a new wait for seconds
            currentState = lawraStates.PEEKING;
            GetComponent<SpriteRenderer>().sprite = lawraPeeking;
            yield return new WaitForSeconds(Random.Range(2, 5));
            // set a 50 percent-ish chance that lawra will look in the window
            if (Random.value >= 0.5f)
            {
                // change to looking for a random amount of time
                currentState = lawraStates.LOOKING;
                GetComponent<SpriteRenderer>().sprite = lawraLooking;
                yield return new WaitForSeconds(Random.Range(1, 4));
                // set back to clear
                currentState = lawraStates.CLEAR;
                GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                // set back to clear by default
                currentState = lawraStates.CLEAR;
                GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}
