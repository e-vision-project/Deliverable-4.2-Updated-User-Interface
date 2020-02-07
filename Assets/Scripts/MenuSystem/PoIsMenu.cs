using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PoIsMenu : MonoBehaviour {
    public GameObject ScrollerContainer;
    private List<PointsOfInterest> allPointsSorted = new List<PointsOfInterest>();

    private void OnEnable()
    {
        for (int i = 0; i < ScrollerContainer.transform.childCount; i++)
        {
            Destroy(ScrollerContainer.transform.GetChild(i).gameObject);
        }
        Populate();
    }

    private void Populate()
    {
        allPointsSorted.Clear();
        for (int i = 0; i < AppManager.GpsManager.PointsOfInterest.Length; i++)
        {
            allPointsSorted.Add(AppManager.GpsManager.PointsOfInterest[i]);
        }

        allPointsSorted = allPointsSorted.OrderBy(o => o.Name).ToList();
        for (int i = 0; i < allPointsSorted.Count; i++)
        {
            GameObject pointObject = Instantiate(Resources.Load("Prefabs/PointUiItemSimple")) as GameObject;
            PointOfInterestUiItem uiItem = pointObject.GetComponent<PointOfInterestUiItem>();
            pointObject.transform.SetParent(ScrollerContainer.transform);
            int num = i + 1;
            uiItem.PointNumberText.text = num.ToString();
            uiItem.PointNameText.text = allPointsSorted[i].Name;
            uiItem.PointAccessibleButton.m_Text = allPointsSorted[i].Name ;
            GameObject pointCanvas = allPointsSorted[i].PointCanvas;
            uiItem.PointButton.onClick.AddListener(() => {
                pointCanvas.SetActive(true);
                this.gameObject.SetActive(false);
            });
        }       
    }

    public IEnumerator WaitAndPopulate()
    {
        // Debug.Log("Waiting for GPS FIX");
        //Wait until the gps sensor provides a valid location.
        while (!AppManager.GpsManager.PointsSorted)
        {
            yield return null;
        }
        //Debug.Log("GPS FIXED");

    }
}
