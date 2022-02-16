/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using UnityEngine;

namespace _3OGS.Utils
{
    /// <summary>
    /// Contain a reference of a sprite in the world, this class is experimental
    /// </summary>
    public class World_Sprite
    {

        private const int _sortingOrderDefault = 5000;

        private GameObject _gameObject;
        private Transform _transform;
        private SpriteRenderer _spriteRenderer;

        public static int GetSortingOrder(Vector3 position, int offset, int baseSortingOrder = _sortingOrderDefault)
        {
            return (int)(baseSortingOrder - position.y) + offset;
        }

        public void SetSortingOrderOffset(int sortingOrderOffset)
        {
            SetSortingOrder(GetSortingOrder(_gameObject.transform.position, sortingOrderOffset));
        }

        public void SetSortingOrder(int sortingOrder)
        {
            _gameObject.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        }

        public void SetLocalScale(Vector3 localScale)
        {
            _transform.localScale = localScale;
        }

        public void SetPosition(Vector3 localPosition)
        {
            _transform.localPosition = localPosition;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void Show()
        {
            _gameObject.SetActive(true);
        }

        public void Hide()
        {
            _gameObject.SetActive(false);
        }

        public void DestroySelf()
        {
            Object.Destroy(_gameObject);
        }
    }
}