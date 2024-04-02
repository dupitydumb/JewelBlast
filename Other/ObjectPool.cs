using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Other
{
    public class ObjectPool
    {
        private GameObject _prefab;
        private readonly List<GameObject> _list = new List<GameObject>();

        public void CreateObject(GameObject prefab, int count = 1, bool worldPositionStays = false)
        {
            _prefab = prefab;
            for (var i = 0; i < count; ++i)
            {
                var obj = Object.Instantiate(prefab, null, worldPositionStays);
                obj.gameObject.SetActive(false);
                _list.Add(obj);
            }
        }

        public GameObject Get()
        {
            if (_list.Count > 0)
            {
                var obj = _list[0];
                _list.RemoveAt(0);
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                return Object.Instantiate(_prefab, null, false);
            }
        }

        
        public void Put(GameObject obj)
        {
            if (obj.tag == "blockitems")
            {
                //Get the block item script
                var blockItem = obj.GetComponent<BlockItem>();
                //get blockItemEnum
                var blockItemEnum = blockItem.blockItemEnum;

                if (blockItemEnum != BlockItemEnum.empty)
                {
                    //Switch case to check the blockItemEnum
                    switch (blockItemEnum)
                    {
                        case BlockItemEnum.Arabic:
                            if (NewScore.instance.arabicCount == 0)
                            {
                                //If the melon count is 0, return
                                return;
                            }
                            //Increase the melon count
                            NewScore.instance.arabicCount -= 1;
                            //Update the score
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.China:
                            if (NewScore.instance.chinaCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.chinaCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.Germany:
                            if (NewScore.instance.germanyCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.germanyCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.England:
                            if (NewScore.instance.englandCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.englandCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.Espanol:
                            if (NewScore.instance.espanolCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.espanolCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.France:
                            if (NewScore.instance.franceCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.franceCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.Greece:
                            if (NewScore.instance.greeceCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.greeceCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.Indonesia:
                            if (NewScore.instance.indonesiaCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.indonesiaCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.Italy:
                            if (NewScore.instance.italyCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.italyCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.Japan:
                            if (NewScore.instance.japanCount == 0)
                            {
                                return;
                            }
                            NewScore.instance.japanCount -= 1;
                            NewScore.instance.UpdateScore();
                            break;
                    
                        
                    }
                }
            }
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(false);
            _list.Add(obj);
        }

        public bool HaveObjectBase()
        {
            return _prefab != null;
        }
    }
}
