using UnityEngine;

public class Tweener : MonoBehaviour
{   
    [Header("Tween Values")]
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float tweenInDelay;

    [Header("Move Values")]
    [SerializeField] private Vector2 target;
    [SerializeField] private float moveTime;

    [Header("Scale Values")]
    [SerializeField] private Vector3 sizeTarget;
    [SerializeField] private float scaleTime;
    private Vector3 originSize;

    [Header("Fade Values")]
    [SerializeField] private float fadeTime;

    [Header("Actions")]
    public bool loop;
    public int loopCount;
    public bool pingPong;

    [HideInInspector] public bool isAnimating = false;

    private void Awake() {
        if(loop){
            loopCount = int.MaxValue;
        }
    }

    public void Move(float direction, bool hide){
        isAnimating = true;
        gameObject.SetActive(true);
        if(pingPong){
            LeanTween.moveLocal(gameObject,gameObject.GetComponent<RectTransform>().anchoredPosition + target*direction,moveTime).setLoopPingPong().setDelay(tweenInDelay).setEase(curve).setOnComplete(()=>{
                if(hide){
                    gameObject.SetActive(false);
                }
                isAnimating = false;
            });
        }
        else{
            LeanTween.moveLocal(gameObject,gameObject.GetComponent<RectTransform>().anchoredPosition + target*direction,moveTime).setDelay(tweenInDelay).setEase(curve).setOnComplete(()=>{
                if(hide){
                    gameObject.SetActive(false);
                }
                isAnimating = false;
            });
        }
    }

    public void Scale(int direction, bool hide){
        isAnimating = true;
        originSize = gameObject.GetComponent<RectTransform>().localScale;
        if(pingPong){
            LeanTween.scale(gameObject,originSize + sizeTarget*direction,scaleTime).setLoopPingPong().setDelay(tweenInDelay).setLoopCount(loopCount).setEase(curve).setOnComplete(()=>{
                if(hide){
                    gameObject.SetActive(false);
                }
                isAnimating = false;
            });
        }
        else{
            LeanTween.scale(gameObject,originSize + sizeTarget*direction,scaleTime).setDelay(tweenInDelay).setLoopCount(loopCount).setEase(curve).setOnComplete(()=>{
                if(hide){
                    gameObject.SetActive(false);
                }
                isAnimating = false;
            });
        }
    }

    public void Fade(float fadeTo, bool hide){
        if(gameObject.GetComponent<CanvasGroup>() == null){
            gameObject.AddComponent<CanvasGroup>();
        }
        isAnimating = true;
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(),fadeTo,fadeTime).setDelay(tweenInDelay).setLoopCount(loopCount).setEase(curve).setOnComplete(()=>{
            if(hide){
                gameObject.SetActive(false);
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(100);
            }
            isAnimating = false;
        });
    }
}