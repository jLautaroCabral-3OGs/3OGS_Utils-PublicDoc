/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using _3OGS.Utils;
using System;
using UnityEngine;

namespace _3OGS.Debug
{
    /// <summary>
    /// A DebugButton is a component used to create buttons in the world that can execute a method when pressed.
    /// </summary>
    public class DebugButton : MonoBehaviour
    {
        private DebugButton() { }

        /// <summary>
        /// Button background color
        /// </summary>
        [field: Header("Button Settings")]
        public Color BackgroundColor { get; set; }
        /// <summary>
        /// Button background color on mouse click
        /// </summary>
        public Color BackgroundOnClickColor { get; set; }
        /// <summary>
        /// Button background color on mouse over
        /// </summary>
        public Color BackgroundOnOverColor { get; set; }

        /// <summary>
        /// Button background sprite
        /// </summary>
        [field: Header("References")]
        public SpriteRenderer BackgroundSprite { get; set; }
        public TextMesh ButtonLabel { get; set; }

        private Action _onClickAction;

        private void OnMouseDown()
        {
            BackgroundSprite.color = BackgroundOnClickColor;
        }
        private void OnMouseEnter()
        {
            BackgroundSprite.color = BackgroundOnOverColor;
        }
        private void OnMouseExit()
        {
            BackgroundSprite.color = BackgroundColor;
        }
        private void OnMouseUp()
        {
            BackgroundSprite.color = BackgroundColor;
            if (_onClickAction != null)
                _onClickAction();
            else
                _3OGS_Debug.TextPopup("This button is not assigned a function", transform.position + transform.right * (_3OGS_Utils.GetButtonSize().x / 2 + _3OGS_Utils.GetButtonPanelOffset()));
        }

        /// <summary>
        /// Set the button text label
        /// </summary>
        /// <param name="text">New text for the label</param>
        public void SetButtonLabelText(string text)
        {
            ButtonLabel.text = text;
        }

        /// <summary>
        /// Set the button action on click
        /// </summary>
        public void SetOnClickAction(Action action)
        {
            _onClickAction = action;
        }
    }
}
