using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TallyMarksWidgetController : MonoBehaviour {

    public List<GameObject> TallyMarks;

    int _currentIndex = 0;
    
    public void FillNext(TallyMarkController.TALLY_MARK mark)
    {
        TallyMarks[_currentIndex].GetComponent<TallyMarkController>().Fill(mark);
        _currentIndex++;
        
        if(_currentIndex == TallyMarks.Count)
        {
            _currentIndex = 0;
            StartCoroutine(Reset());
        }
    }
    
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1.5f);
        foreach (GameObject tallyMark in TallyMarks)
        {
            tallyMark.GetComponent<TallyMarkController>().UnFill();
        }
    }
}
