using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanelGroupController : MonoBehaviour {

    public LifePanelController lifePanelControllerPrefab;

    private List<LifePanelController> LifePanelConterllers = new List<LifePanelController>();

    private void Awake()
    {
        GameManager.onHealthChangeEvent.AddListener(RefreshLifePanel);
    }

    public void AddLifePanel()
    {
        LifePanelController lifePanelControllerClone = Instantiate(lifePanelControllerPrefab, transform);
        lifePanelControllerClone.SetActive(false);

        LifePanelConterllers.Add(lifePanelControllerClone);
    }

    public void RefreshLifePanel(int amount)
    {
        int lifeDelta = amount - LifePanelConterllers.Count;

        for (int i = 0; i < lifeDelta; i++)
        {
            AddLifePanel();
        }

        for (int i = 0; i < LifePanelConterllers.Count; i++)
        {
            if (i < GameManager.Instance.currentNumOfLives)
                LifePanelConterllers[i].SetActive(true);
            else
                LifePanelConterllers[i].SetActive(false);
        }
    }

}
