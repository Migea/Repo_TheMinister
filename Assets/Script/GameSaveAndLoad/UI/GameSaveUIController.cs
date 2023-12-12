using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveUIController : MonoBehaviour
{
    public SaveAndLoadManager Manager => FindObjectOfType<SaveAndLoadManager>();
    public SOGameSaveDatabase GameSaveDatabase = null;
    public List<GameSaveUI> pages;
    public Transform pageHolder;
    public GameSaveUI pageTemp;
    public Button nextPageButton;
    public Button prevPageButton;
    public int pageIndex = 0;
    public int lastPageIndex => pages.Count - 1;
    private void Reset()
    {
        foreach (GameSaveUI page in pages) Destroy(page.gameObject);
        pages.Clear();
        pageIndex = 0;
    }
    public void OnEnable()
    {
        Reset();
        pageTemp.gameObject.SetActive(false);
        var manager = Manager;
        if (manager != null) GameSaveDatabase = manager.GameSaveDatabase;
        else GameSaveDatabase.FindAllSaves();
        if (GameSaveDatabase == null) return;
        var saves = GameSaveDatabase.OutputGameSaves();
        saves.Reverse();
        SetPages(saves);
        pages[0].gameObject.SetActive(true);
        ButtonCheck();
    }
    public void SetPages(List<GameSave> saves)
    {
        pageIndex = 0;
        int pageCount = (saves.Count + 1) / 4;
        if ((saves.Count + 1) % 4 > 0) pageCount++;

        int saveIndex = 0;
        for (int i = 0; i < pageCount; i++)
        {
            var page = Instantiate(pageTemp, pageHolder);
            pages.Add(page);
            var saveList = new List<GameSave>();
            if (saveIndex < saves.Count)
            {
                saveList.Add(saves[saveIndex]);
            }
            if (saveIndex + 1 < saves.Count)
            {
                saveList.Add(saves[saveIndex + 1]);
            }
            if (saveIndex + 2 < saves.Count)
            {
                saveList.Add(saves[saveIndex + 2]);
            }
            page.Setup(saveList);
            saveIndex += 2;
            if (i == 0)
            {
                page.SetupFirst();
            }
            else
            {
                if (saveIndex + 3 < saves.Count)
                {
                    saveList.Add(saves[saveIndex + 3]);
                    saveIndex += 1;
                }
            }
            page.Setup(saveList);
        }
    }

    public void NextPage()
    {
        if (pageIndex >= lastPageIndex)
        {
            return;
        }
        pages[pageIndex].GetComponent<Animator>().Play("PageHide");
        pageIndex++;
        pages[pageIndex].gameObject.SetActive(true);
        pages[pageIndex].GetComponent<Animator>().Play("PageShow");
        ButtonCheck();
    }

    public void PrevPage()
    {
        if (pageIndex == 0)
        {
            return;
        }
        pages[pageIndex].GetComponent<Animator>().Play("PageHide");
        pageIndex--;
        pages[pageIndex].gameObject.SetActive(true);
        pages[pageIndex].GetComponent<Animator>().Play("PageShow");
        ButtonCheck();
    }

    public void ButtonCheck()
    {
        if (pageIndex <= 0)
        {
            prevPageButton.gameObject.SetActive(false);
        }
        else
        {
            prevPageButton.gameObject.SetActive(true);
        }
        if (pageIndex >= lastPageIndex)
        {
            nextPageButton.gameObject.SetActive(false);
        }
        else
        {
            nextPageButton.gameObject.SetActive(true);
        }
    }
}
