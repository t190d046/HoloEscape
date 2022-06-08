using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzlePanel : MonoBehaviour
{
    [SerializeField] SlidePuzzle slidePuzzle;
    [SerializeField] int row, column;

    private int defaultRow, defauleColumn;
    private void Awake()
    {
        defaultRow = row;
        defauleColumn = column;
    }

    public void init()
    {
        row = defaultRow;
        column = defauleColumn;
    }

    public void SetPosition(int r, int c)
    {
        transform.localPosition = new Vector3((c - 1) * 0.3f, (r - 1) * 0.3f, 0);
    }
    public void SetRowColumn(int r, int c)
    {
        row = r;
        column = c;
    }

    // Update is called once per frame
    public void Slide()
    {
        Debug.Log("Call_Slide()");
        if (slidePuzzle.canSlide == false) return;

        SlideDirection sd = slidePuzzle.CheckAdjacent(row, column);

        float moveLength = 0.03f;
        switch (sd)
        {
            case SlideDirection.top:
                row = row - 1;
                StartCoroutine(PanelSlideCoroutine(0f, moveLength));
                break;
            case SlideDirection.bottom:
                row = row + 1;
                StartCoroutine(PanelSlideCoroutine(0f, -moveLength));
                break;
            case SlideDirection.left:
                column = column - 1;
                StartCoroutine(PanelSlideCoroutine(-moveLength, 0f));
                break;
            case SlideDirection.right:
                column = column + 1;
                StartCoroutine(PanelSlideCoroutine(moveLength, 0f));
                break;
        }

    }

    IEnumerator PanelSlideCoroutine(float r, float c)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Translate(r, c, 0);
        }
        Debug.Log(transform.localPosition);
        slidePuzzle.canSlide = true;
    }
}
