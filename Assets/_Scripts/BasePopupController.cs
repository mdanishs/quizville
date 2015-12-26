using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class BasePopupController : MonoBehaviour {

    public Text Heading;
    public Text Description;
    public GameObject ParentCanvas;
    public GameObject Overlay;
    Animator _animator;

    public void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }

	public virtual void ShowPopup()
    {
        _animator.SetTrigger("Show");
    }

    public virtual void HidePopup()
    {
        _animator.SetTrigger("Hide");
    }

    public virtual IEnumerator DeActivate(float secondsToWait, System.Action onComplete)
    {
        yield return new WaitForSeconds(secondsToWait);
        gameObject.SetActive(false);
        if (onComplete != null)
            onComplete();
    }

}
