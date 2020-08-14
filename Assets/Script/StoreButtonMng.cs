using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreButtonMng : MonoBehaviour, IPointerClickHandler, IBeginDragHandler
{

    public GameObject chunbae, quest, shop, center;
    public GameObject cafe, chicken, gobchang, gym, land;
    bool isStoreClicked;
    public NestedScrollManager scrollMng;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isStoreClicked = true;

        chunbae.SetActive(false);
        quest.SetActive(false);
        shop.SetActive(false);
        center.SetActive(false);

        cafe.SetActive(true);
        chicken.SetActive(true);
        gobchang.SetActive(true);
        gym.SetActive(true);
        land.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isStoreClicked == false)
        {
            isStoreClicked = true;

            chunbae.SetActive(false);
            quest.SetActive(false);
            shop.SetActive(false);
            center.SetActive(false);

            cafe.SetActive(true);
            chicken.SetActive(true);
            gobchang.SetActive(true);
            gym.SetActive(true);
            land.SetActive(true);
        }
        else
        {
            isStoreClicked = false;

            chunbae.SetActive(true);
            quest.SetActive(true);
            shop.SetActive(true);
            center.SetActive(true);

            cafe.SetActive(false);
            chicken.SetActive(false);
            gobchang.SetActive(false);
            gym.SetActive(false);
            land.SetActive(false);
        }
    }

    void Update()
    {
        if (isStoreClicked == false)
        {
            chunbae.SetActive(true);
            quest.SetActive(true);
            shop.SetActive(true);
            center.SetActive(true);

            cafe.SetActive(false);
            chicken.SetActive(false);
            gobchang.SetActive(false);
            gym.SetActive(false);
            land.SetActive(false);
        }
    }

    public void MoveToCafe()
    {
        scrollMng.targetPos = 0f;
        isStoreClicked = false;

        chunbae.SetActive(true);
        quest.SetActive(true);
        shop.SetActive(true);
        center.SetActive(true);

        cafe.SetActive(false);
        chicken.SetActive(false);
        gobchang.SetActive(false);
        gym.SetActive(false);
        land.SetActive(false);
    }
    public void MoveToChicken()
    {
        scrollMng.targetPos = 0.25f;
        isStoreClicked = false;

        chunbae.SetActive(true);
        quest.SetActive(true);
        shop.SetActive(true);
        center.SetActive(true);

        cafe.SetActive(false);
        chicken.SetActive(false);
        gobchang.SetActive(false);
        gym.SetActive(false);
        land.SetActive(false);
    }
    public void MoveToGobchang()
    {
        scrollMng.targetPos = 0.5f;
        isStoreClicked = false;

        chunbae.SetActive(true);
        quest.SetActive(true);
        shop.SetActive(true);
        center.SetActive(true);

        cafe.SetActive(false);
        chicken.SetActive(false);
        gobchang.SetActive(false);
        gym.SetActive(false);
        land.SetActive(false);
    }
    public void MoveToGym()
    {
        scrollMng.targetPos = 0.75f;
        isStoreClicked = false;

        chunbae.SetActive(true);
        quest.SetActive(true);
        shop.SetActive(true);
        center.SetActive(true);

        cafe.SetActive(false);
        chicken.SetActive(false);
        gobchang.SetActive(false);
        gym.SetActive(false);
        land.SetActive(false);
    }
    public void MoveToLand()
    {
        scrollMng.targetPos = 1f;
        isStoreClicked = false;

        chunbae.SetActive(true);
        quest.SetActive(true);
        shop.SetActive(true);
        center.SetActive(true);

        cafe.SetActive(false);
        chicken.SetActive(false);
        gobchang.SetActive(false);
        gym.SetActive(false);
        land.SetActive(false);
    }

}
