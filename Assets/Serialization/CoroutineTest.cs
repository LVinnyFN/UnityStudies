using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    [ContextMenu("Debug")]
    public void StartDebug()
    {
        StartCoroutine(DebugCoroutine());
    }

    public IEnumerator DebugCoroutine()
    {
        Debug.Log("Debug Coroutine start");
        yield return StartCoroutine(DebugTimeCoroutine("1", 3));
        yield return StartCoroutine(DebugTimeCoroutine("2", 3));
        yield return StartCoroutine(DebugTimeCoroutine("3", 3));
        Debug.Log("Debug Coroutine end");
    }

    public IEnumerator DebugTimeCoroutine(string name, float time)
    {
        Debug.Log(name + " Coroutine start");
        yield return new WaitForSeconds(time);
        Debug.Log(name + " Coroutine finish");
    }
}

public static class StaticCoroutineTest
{
    public static IEnumerator DebugCoroutine()
    {
        Debug.Log("Debug Coroutine start");
        yield return DebugTimeCoroutine("1", 3);
        yield return DebugTimeCoroutine("2", 3);
        yield return DebugTimeCoroutine("3", 3);
        Debug.Log("Debug Coroutine end");
    }

    public static IEnumerator DebugTimeCoroutine(string name, float time)
    {
        Debug.Log(name + " Coroutine start");
        yield return new WaitForSeconds(time);
        Debug.Log(name + " Coroutine finish");
    }
}
