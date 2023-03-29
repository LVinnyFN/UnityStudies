using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LerpType
{
    Linear,
    Quadratic,
    InversedQuadratic,
    MedianPoint,
}

public class SpriteLerp : MonoBehaviour
{
    [SerializeField] private Transform A, B, M, L;
    public float duration = 5f;
    private float timer;

    public float pow = 2f;
    public LerpType lerpTypeA;
    public LerpType lerpTypeB;
    [Range(0,1)]public float blend;

    public bool autoRestart;

    private void Update()
    {
        float t = timer / duration;
        Vector3 lerpA = Vector3.zero;
        Vector3 lerpB = Vector3.zero;
        
        if(lerpTypeA == LerpType.Linear)
        {
            lerpA = Vector3.Lerp(A.position, B.position, t);
        }
        else if (lerpTypeA == LerpType.Quadratic)
        {
            lerpA = Vector3.Lerp(A.position, B.position, Mathf.Pow(t, pow));           
        }
        else if (lerpTypeA == LerpType.InversedQuadratic)
        {
            lerpA = Vector3.Lerp(A.position, B.position, 1 - Mathf.Pow(1 - t, pow));
        }
        else if(lerpTypeA == LerpType.MedianPoint)
        {
            lerpA = Vector3.Lerp(Vector3.Lerp(A.position,M.position, t), Vector3.Lerp(M.position,B.position, t), t);
        }

        if (lerpTypeB == LerpType.Linear)
        {
            lerpB = Vector3.Lerp(A.position, B.position, t);
        }
        else if (lerpTypeB == LerpType.Quadratic)
        {
            lerpB = Vector3.Lerp(A.position, B.position, Mathf.Pow(t, pow));
        }
        else if (lerpTypeB == LerpType.InversedQuadratic)
        {
            lerpB = Vector3.Lerp(A.position, B.position, 1 - Mathf.Pow(1 - t, pow));
        }
        else if (lerpTypeB == LerpType.MedianPoint)
        {
            lerpB = Vector3.Lerp(Vector3.Lerp(A.position, M.position, t), Vector3.Lerp(M.position, B.position, t), t);
        }

        L.position = Blend(lerpA, lerpB, blend);

        if (timer > duration)
        {
            gameObject.SetActive(false);
            if (autoRestart) Restart();
        }
        timer += Time.deltaTime;
    }

    private Vector3 Blend(Vector3 a, Vector3 b, float blend) => a + blend * (b - a);

    [ContextMenu("Restart")]
    public void Restart() => Set(A, B, duration);
    public void Set(Transform A, Transform B, float duration)
    {
        this.A = A;
        this.B = B;
        this.duration = duration;
        timer = 0;
        gameObject.SetActive(true);
    }
}
