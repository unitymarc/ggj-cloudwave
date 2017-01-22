using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceComicAnimation : MonoBehaviour {

    public Animator graphicNovelAnimator;
    public Animator buttonAnimator;
    public BoxCollider2D boxCollider;
    public Animator fadeScreenAnimator;
    public AudioSource music;
    public AudioSource clickSound;

    bool buttonCanShow = true;
    bool fading = false;

    void Update()
    {
        AnimatorStateInfo graphicStateInfo = graphicNovelAnimator.GetCurrentAnimatorStateInfo (0);

        if (!graphicStateInfo.IsName ("GraphicNovelWait") && 
            graphicStateInfo.normalizedTime > 1 && buttonCanShow) {
            ShowButton ();
        }
        if (Input.GetMouseButtonDown(0)) {
            CastRay();
        }
        AnimatorStateInfo fadeStateInfo = fadeScreenAnimator.GetCurrentAnimatorStateInfo (0);
        if (fading) {
            music.volume *= .97f;
            if (music.volume <= .001f) {
                Debug.Log ("TODO: go to game");
            }
        } else if (fadeStateInfo.IsName ("FadeScreen") && graphicStateInfo.normalizedTime > 1) {
            //trigger transition to next scene
            fading = true;
        }
    }

    void CastRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.origin, Mathf.Infinity);
        if (hit) {
            if (hit.collider == boxCollider) {
                OnMouseDown ();
            }
        }
    }

    void OnMouseDown()
    {
        clickSound.Play ();
        AnimatorStateInfo stateInfo = graphicNovelAnimator.GetCurrentAnimatorStateInfo (0);
        if (stateInfo.IsName ("GraphicNovel3")) {
            TriggerFadeOut ();
        } else {
            TriggerAdvance ();

        }
    }

    void ShowButton()
    {
        buttonAnimator.SetBool ("showButton", true);
        boxCollider.size = Vector2.one * 3f;
    }

    void HideButton()
    {
        buttonAnimator.SetBool ("showButton", false);
        boxCollider.size = Vector3.zero;
    }

    IEnumerator TimeoutButton()
    {
        buttonCanShow = false;
        yield return new WaitForSeconds (3f);
        buttonCanShow = true;
    }

    void TriggerAdvance()
    {
        HideButton ();
        StartCoroutine (TimeoutButton());
        graphicNovelAnimator.SetTrigger ("advance");
    }

    void TriggerFadeOut()
    {
        HideButton ();
        buttonCanShow = false;
        fadeScreenAnimator.SetTrigger ("advance");
    }
}
