using UnityEngine;
using System.Collections;

public class WhiteBoardController : MonoBehaviour {

    Animator _animator;
    public GameObject WhiteBoard;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void ClearBoard()
    {

    }

	public IEnumerator ShowBoard()
    {
        yield return new WaitForEndOfFrame();
        _animator.SetTrigger("Show");
    }

    public IEnumerator HideBoard()
    {
        yield return new WaitForEndOfFrame();
        _animator.SetTrigger("Hide");
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    public void OnHideBoardClicked()
    {
        StartCoroutine(HideBoard());

    }
}
