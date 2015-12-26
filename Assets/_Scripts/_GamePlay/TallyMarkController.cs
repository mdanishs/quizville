using UnityEngine;
using System.Collections;

public class TallyMarkController : MonoBehaviour {

    public enum TALLY_MARK
    {
        TICK,
        CROSS,
    }

    public GameObject FilledCircle;
    public GameObject Check, Cross;

    string _scaleUp = "ScaleUp", _scaleDown = "ScaleDown";

    public void UnFill()
    {
        if(FilledCircle.activeInHierarchy)
            FilledCircle.GetComponent<Animator>().SetTrigger(_scaleDown);

        if(Check.activeInHierarchy)
            Check.GetComponent<Animator>().SetTrigger(_scaleDown);

        if(Cross.activeInHierarchy)
            Cross.GetComponent<Animator>().SetTrigger(_scaleDown);
    }

    public void Fill(TALLY_MARK mark)
    {
        Animator animator = FilledCircle.GetComponent<Animator>();
        animator.SetTrigger(_scaleUp);

        GameObject obj = null;
        switch (mark)
        {
            case TALLY_MARK.TICK:
                obj = Check;
                break;
            case TALLY_MARK.CROSS:
                obj = Cross;
                break;
            default:
                break;
        }

        if(obj != null)
        {
            obj.SetActive(true);
            obj.GetComponent<Animator>().SetTrigger(_scaleUp);
        }
    }
	
}
