/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using _3OGS.Utils;
using _3OGS.Debug.Cameras;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _3OGS.Debug
{
    /// <summary>
    /// This class contains several utility methods related to debugging and Debug gmeObjects
    /// </summary>
    public static class _3OGS_Debug
    {
        /// <summary>
        /// Instantiate a FreeLookCamera on Vector3.zero position, and it is set as the current camera
        /// </summary>
        public static void UseFreeLookCamera()
        {
            UseFreeLookCamera(Vector3.zero);
        }

        /// <summary>
        /// Instantiate a FreeLookCamera on <paramref name="position"/> and it is set as the current camera
        /// </summary>
        /// <param name="position">Position to spawn camera</param>
        public static void UseFreeLookCamera(Vector3 position)
        {
            CameraSwitcher.SetupCurrentCamera(_3OGS_FreeLookCamera.CreateFreeLookCamera(position));
        }

        /// <summary>
        /// Instantiate a RotateArounTargerCamera on <paramref name="target"/> position and it is set as the current camera
        /// </summary>
        /// <param name="target">Target to generate the camera and the target that the camera will follow</param>
        public static void UseRotateAroundTargetCamera(Transform target)
        {
            CameraSwitcher.SetupCurrentCamera(_3OGS_RotateAroundCamera.CreateRotateAroundToTargetCamera(target));
        }

        /// <summary>
        /// Create a DebugButton that will execute an action when is pressed
        /// </summary>
        /// <param name="btnLabel">Label of the button</param>
        /// <param name="position">Position of the button spawn</param>
        /// <param name="onClickFunction">Action that button will execute</param>
        /// <param name="rotateToCamera">The button will be rotate to the camera</param>
        /// <returns>The DebugButton gameobject</returns>
        public static GameObject CreateDebugButton(string btnLabel, Vector3 position, Action onClickFunction, bool rotateToCamera = true)
        {
            return LC_GraphicsDebugUtils.CreateDebugButton(null, btnLabel, position, onClickFunction, rotateToCamera);
        }

        /// <summary>
        /// Create a DebugButton that will execute an action when is pressed
        /// </summary>
        /// <param name="parent">The parent that be will setted to DebugButton</param>
        /// <param name="btnLabel">Label of the button</param>
        /// <param name="position">Position of the button spawn</param>
        /// <param name="onClickFunction">Action that button will execute</param>
        /// <param name="rotateToCamera">The button will be rotate to the camera</param>
        /// <returns>The DebugButton gameobject</returns>
        public static GameObject CreateDebugButton(Transform parent, string btnLabel, Vector3 position, Action onClickFunction, bool rotateToCamera = true)
        {
            return LC_GraphicsDebugUtils.CreateDebugButton(parent, btnLabel, position, onClickFunction, rotateToCamera);
        }

        /// <summary>
        /// Create a ButtonPanel for DebugButtons containing
        /// </summary>
        /// <param name="position">Position to spawn ButtonPanel</param>
        /// <returns>The ButtonPanel gameobject</returns>
        public static GameObject CreateButtonPanel(Vector3 position)
        {
            return LC_GraphicsDebugUtils.CreateButtonPanel(null, position);
        }

        /// <summary>
        /// Create a ButtonPanel for DebugButtons containing
        /// </summary>
        /// <param name="parent">The parent that be will setted to ButtonPanel</param>
        /// <param name="position">Position to spawn ButtonPanel</param>
        /// <returns>The ButtonPanel gameobject</returns>
        public static GameObject CreateButtonPanel(Transform parent, Vector3 position)
        {
            return LC_GraphicsDebugUtils.CreateButtonPanel(parent, position);
        }

        /// <summary>
        /// Create a WorldText with custom configuration
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="parent">Parent</param>
        /// <param name="localPosition">Position</param>
        /// <param name="fontSize">Font size</param>
        /// <param name="color">Font color</param>
        /// <param name="textAnchor">Text anchor</param>
        /// <param name="textAlignment">Text alignment</param>
        /// <param name="sortingOrder">Sorting order</param>
        /// <returns>The WorldText gameobject</returns>
        public static GameObject WorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = _3OGS_Utils.SortingOrderDefault)
        {
            if (color == null) color = Color.white;
            return LC_GraphicsDebugUtils.CreateWorldText(parent, text, localPosition, fontSize, color, textAnchor, textAlignment, sortingOrder).gameObject;
        }

        /// <summary>
        /// Create a WorldText Popup
        /// </summary>
        /// <param name="text">Text of the WorldText</param>
        /// <param name="position">Position to spawn WorldText</param>
        public static void TextPopup(string text, Vector3 position)
        {
            LC_GraphicsDebugUtils.CreateWorldTextPopup(text, position);
        }

        /// <summary>
        /// Create a Text Popup in the World, no parent
        /// </summary>
        /// <param name="text">Text of the WorldText</param>
        /// <param name="localPosition">Position to spawn WorldText</param>
        /// <param name="popupTime">Duration of the popup</param>
        public static void TextPopup(string text, Vector3 localPosition, float popupTime)
        {
            LC_GraphicsDebugUtils.CreateWorldTextPopup(null, text, localPosition, 40, Color.white, localPosition + new Vector3(0, .5f), popupTime);
        }

        private static class LC_GraphicsDebugUtils
        {
            internal static GameObject CreateDebugButton(Transform parent, string btnLabel, Vector3 position, Action onClickFunction, bool rotateToCamera = true)
            {
                GameObject btnObj = new GameObject("DebugButton_" + btnLabel);
                DebugButton btnDebugComponent = btnObj.AddComponent<DebugButton>();
                BoxCollider btnCollider = btnObj.AddComponent<BoxCollider>();

                btnObj.layer = LayerMask.GetMask(_3OGS_Utils.GetSettings().ButtonsLayerMask.ToString());

                if (rotateToCamera)
                    btnObj.AddComponent<LookToCamera>().SetRotateY(true);
                if (parent != null)
                    btnObj.transform.parent = parent;

                if (onClickFunction != null)
                    btnDebugComponent.SetOnClickAction(onClickFunction);

                btnCollider.isTrigger = true;
                btnCollider.size = _3OGS_Utils.GetButtonSize();

                btnObj.transform.position = position;

                TextMesh buttonLabel =
                    CreateWorldText(
                        text: btnLabel,
                        parent: btnObj.transform,
                        localPosition: Vector3.zero,
                        color: Color.black,
                        textAlignment: TextAlignment.Center,
                        textAnchor: TextAnchor.MiddleCenter,
                        fontSize: _3OGS_Utils.GetFontSize()
                        );

                GameObject buttonBackground =
                    CreateWorldSprite(
                        parent: btnObj.transform,
                        name: "DebugButton_Background",
                        sprite: _3OGS_Utils.GetDefaultSquareSprite(),
                        position: Vector3.zero,
                        localScale: _3OGS_Utils.GetButtonSize(),
                        color: _3OGS_Utils.GetDefaultButtonColor()
                        );

                CreateWorldSprite(
                    parent: btnObj.transform,
                    name: "DebugButton_BackgroundBorder",
                    sprite: _3OGS_Utils.GetDefaultSquareSprite(),
                    position: Vector3.zero + btnObj.transform.forward * 0.01f,
                    localScale: _3OGS_Utils.GetButtonSize() + new Vector3(.05f, .05f, .05f),
                    color: Color.gray
                    );

                btnDebugComponent.ButtonLabel = buttonLabel;
                btnDebugComponent.BackgroundSprite = buttonBackground.GetComponent<SpriteRenderer>();
                btnDebugComponent.BackgroundColor = _3OGS_Utils.GetDefaultButtonColor();
                btnDebugComponent.BackgroundOnClickColor = _3OGS_Utils.GetButtonColorOnClick();
                btnDebugComponent.BackgroundOnOverColor = _3OGS_Utils.GetButtonColorOnOver();

                btnDebugComponent.SetButtonLabelText(btnLabel);

                _3OGS_Debug.RuntimeDebugObjectsManager.DebugObjects.Add(btnObj);

                return btnObj;
            }

            internal static GameObject CreateButtonPanel(Transform parent, Vector3 position)
            {
                GameObject btnPanelObj = new GameObject("DebugPanel", typeof(DebugButtonPanel));

                btnPanelObj.AddComponent<LookToCamera>().SetRotateY(true);

                if (parent != null)
                    btnPanelObj.transform.parent = parent;

                btnPanelObj.transform.position = position;

                _3OGS_Debug.RuntimeDebugObjectsManager.DebugObjects.Add(btnPanelObj);

                return btnPanelObj;
            }

            internal static void CreateWorldTextUpdater(Func<string> GetTextFunc, Vector3 localPosition, Transform parent = null)
            {
                TextMesh textMesh = CreateWorldText(GetTextFunc(), parent, localPosition);

                FunctionUpdater.Create(() => {
                    textMesh.text = GetTextFunc();
                    return false;
                }, "WorldTextUpdater");
            }

            internal static void CreateWorldTextPopup(string text, Vector3 localPosition)
            {
                CreateWorldTextPopup(null, text, localPosition, 40, Color.white, localPosition + new Vector3(0, .5f), 1f);
            }
            internal static void CreateWorldTextPopup(string text, Vector3 localPosition, float popupTime)
            {
                CreateWorldTextPopup(null, text, localPosition, 40, Color.white, localPosition + new Vector3(0, .5f), popupTime);
            }
            internal static void CreateWorldTextPopup(string text, Vector3 localPosition, Vector3 finalPos)
            {
                CreateWorldTextPopup(null, text, localPosition, 40, Color.white, localPosition + finalPos, 1f);
            }

            internal static void CreateWorldTextPopup(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, Vector3 finalPopupPosition, float popupTime)
            {
                TextMesh textMesh = CreateWorldText(parent, text, localPosition, fontSize, color, TextAnchor.LowerLeft, TextAlignment.Left, _3OGS_Utils.SortingOrderDefault);
                Transform transform = textMesh.transform;
                Vector3 moveAmount = (finalPopupPosition - localPosition) / popupTime;
                textMesh.gameObject.AddComponent<LookToCamera>();
                FunctionUpdater.Create(delegate () {

                    transform.position += moveAmount * Time.deltaTime;
                    popupTime -= Time.deltaTime;

                    if (popupTime <= 0f)
                    {
                        UnityEngine.Object.Destroy(transform.gameObject);
                        _3OGS_Debug.RuntimeDebugObjectsManager.DebugObjects.Remove(transform.gameObject);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }, "WorldTextPopup");
            }

            internal static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = _3OGS_Utils.SortingOrderDefault)
            {
                return CreateWorldText(parent, text, localPosition, fontSize, color, textAnchor, textAlignment, sortingOrder);
            }

            internal static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color? color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
            {
                if (color == null) color = Color.white;

                GameObject gameObject = new GameObject("LC_WorldText", typeof(TextMesh));
                Transform transform = gameObject.transform;

                #region Custom conf - jLautaroCabral

                transform.localScale = Vector3.one * 0.1f;

                #endregion Custom conf - jLautaroCabral

                transform.SetParent(parent, false);
                transform.localPosition = localPosition;

                TextMesh textMesh = gameObject.GetComponent<TextMesh>();
                textMesh.anchor = textAnchor;
                textMesh.alignment = textAlignment;
                textMesh.text = text;
                textMesh.fontSize = fontSize;
                textMesh.color = (Color)color;
                textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

                _3OGS_Debug.RuntimeDebugObjectsManager.DebugObjects.Add(gameObject);

                return textMesh;
            }

            internal static GameObject CreateWorldSprite(Transform parent, string name, Sprite sprite, Vector3 position, Vector3 localScale, Color color)
            {
                return CreateWorldSprite(parent, name, sprite, position, localScale, 0, color);
            }

            internal static GameObject CreateWorldSprite(string name, Sprite sprite, Vector3 position, Vector3 localScale, Color color)
            {
                return CreateWorldSprite(null, name, sprite, position, localScale, 0, color);
            }

            internal static GameObject CreateWorldSprite(string name, Sprite sprite, Vector3 position, Vector3 localScale, int sortingOrder, Color color)
            {
                return CreateWorldSprite(null, name, sprite, position, localScale, sortingOrder, color);
            }

            internal static GameObject CreateWorldSprite(Transform parent, string name, Sprite sprite, Vector3 localPosition, Vector3 localScale, int sortingOrder, Color color)
            {
                GameObject gameObject = new GameObject(name, typeof(SpriteRenderer));
                Transform transform = gameObject.transform;
                transform.SetParent(parent, false);
                transform.localPosition = localPosition;
                transform.localScale = localScale;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                spriteRenderer.sortingOrder = sortingOrder;
                spriteRenderer.color = color;

                _3OGS_Debug.RuntimeDebugObjectsManager.DebugObjects.Add(gameObject);
                return gameObject;
            }

            internal static Text DrawTextUI(string textString, Vector2 anchoredPosition, int fontSize, Font font)
            {
                return DrawTextUI(textString, _3OGS_Utils.GetCanvasTransform(), anchoredPosition, fontSize, font);
            }

            internal static Text DrawTextUI(string textString, Transform parent, Vector2 anchoredPosition, int fontSize, Font font)
            {
                GameObject textGo = new GameObject("LC_UIText", typeof(RectTransform), typeof(Text));
                textGo.transform.SetParent(parent, false);
                Transform textGoTrans = textGo.transform;
                textGoTrans.SetParent(parent, false);
                textGoTrans.localPosition = Vector3.zero;
                textGoTrans.localScale = Vector3.one;

                RectTransform textGoRectTransform = textGo.GetComponent<RectTransform>();
                textGoRectTransform.sizeDelta = new Vector2(0, 0);
                textGoRectTransform.anchoredPosition = anchoredPosition;

                Text text = textGo.GetComponent<Text>();
                text.text = textString;
                text.verticalOverflow = VerticalWrapMode.Overflow;
                text.horizontalOverflow = HorizontalWrapMode.Overflow;
                text.alignment = TextAnchor.MiddleLeft;
                if (font == null) font = _3OGS_Utils.GetDefaultFont();
                text.font = font;
                text.fontSize = fontSize;

                _3OGS_Debug.RuntimeDebugObjectsManager.DebugObjects.Add(textGo);

                return text;
            }

            internal static FunctionUpdater CreateUITextUpdater(Func<string> GetTextFunc, Vector2 anchoredPosition)
            {
                Text text = DrawTextUIAnchoredPos(GetTextFunc(), anchoredPosition, 20, _3OGS_Utils.GetDefaultFont());
                return FunctionUpdater.Create(() => {
                    text.text = GetTextFunc();
                    return false;
                }, "UITextUpdater");
            }

            internal static Text DrawTextUIAnchoredPos(string textString, Vector2 anchoredPosition, int fontSize, Font font)
            {
                return DrawTextUIWithAnchoredPos(textString, _3OGS_Utils.GetCanvasTransform(), anchoredPosition, fontSize, font);
            }

            internal static Text DrawTextUIWithAnchoredPos(string textString, Transform parent, Vector2 anchoredPosition, int fontSize, Font font)
            {
                GameObject textGo = new GameObject("Text", typeof(RectTransform), typeof(Text));
                textGo.transform.SetParent(parent, false);
                Transform textGoTrans = textGo.transform;
                textGoTrans.SetParent(parent, false);
                textGoTrans.localPosition = Vector3.zero;
                textGoTrans.localScale = Vector3.one;

                RectTransform textGoRectTransform = textGo.GetComponent<RectTransform>();
                textGoRectTransform.sizeDelta = new Vector2(0, 0);
                textGoRectTransform.anchoredPosition = anchoredPosition;

                Text text = textGo.GetComponent<Text>();
                text.text = textString;
                text.verticalOverflow = VerticalWrapMode.Overflow;
                text.horizontalOverflow = HorizontalWrapMode.Overflow;
                text.alignment = TextAnchor.MiddleLeft;
                if (font == null) font = _3OGS_Utils.GetDefaultFont();
                text.font = font;
                text.fontSize = fontSize;

                return text;
            }

        }

        /// <summary>
        /// Manage the runtime debug objects gererates from <c>_3OGS_Debug</c> class
        /// </summary>
        public static class RuntimeDebugObjectsManager
        {
            /// <summary>
            /// Runtime debug gameobjects
            /// </summary>
            public static List<GameObject> DebugObjects { get; private set; } = new List<GameObject>();
            private static bool _hidingObjects;

            /// <summary>
            /// Disable all debug gameobjects
            /// </summary>
            public static void DisableDebugObjects()
            {
                _hidingObjects = true;
                foreach (GameObject debugObj in DebugObjects)
                    debugObj.SetActive(false);
            }

            /// <summary>
            /// Enable all debug gameobjects
            /// </summary>
            public static void EnableDebugObjects()
            {
                _hidingObjects = false;
                foreach (GameObject debugObj in DebugObjects)
                    debugObj.SetActive(true);
            }

            /// <summary>
            /// The debug gameobjects will be disable when their position is greater than <c>_3OGS_Utils.GetSettings().DebugObjectsDrawDistance</c>
            /// </summary>
            public static void HandleDebugObjectsFarFromCamera()
            {
                foreach (GameObject debugObj in DebugObjects)
                {
                    if(Vector3.Distance(debugObj.transform.position, CameraSwitcher.CurrentCamera.transform.position) > _3OGS_Utils.GetSettings().DebugObjectsDrawDistance)
                    {
                        debugObj.SetActive(false);
                    } else
                    {
                        if (!_hidingObjects) debugObj.SetActive(true);
                    }
                        
                }
            }
        }
    }
}

