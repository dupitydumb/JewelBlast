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
                        case BlockItemEnum.melon:
                            if (NewScore.instance.melonCount == 0)
                            {
                                //If the melon count is 0, return
                                return;
                            }
                            //Increase the melon count
                            NewScore.instance.melonCount--;
                            //Update the score
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.apple:
                            if (NewScore.instance.appleCount == 0)
                            {
                                //If the apple count is 0, return
                                return;
                            }
                            //Increase the apple count
                            NewScore.instance.appleCount--;
                            //Update the score
                            NewScore.instance.UpdateScore();
                            break;
                        case BlockItemEnum.grape:
                            if (NewScore.instance.grapeCount == 0)
                            {
                                //If the grape count is 0, return
                                return;
                            }
                            //Increase the grape count
                            NewScore.instance.grapeCount--;
                            //Update the score
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
