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
    /// A DebugButtonPanel is a component used to contain and accommodate the DebugButtons associated with it.
    /// </summary>
    public class DebugButtonPanel : MonoBehaviour
    {
        private DebugButtonPanel() { }

        private int ButtonQuantity = 0;

        /// <summary>
        /// Instantiate and add to a DebugButtonPanel a new DebugButton that instantiates to its right a TextPopup with a message when clicked.
        /// </summary>
        /// <param name="btnPanel">Debug button panel to add the new button</param>
        /// <param name="btnLabel">The label of the new button</param>
        /// <param name="btnMessage">The message instatiated from the new button</param>
        /// <returns>The new DebugButton gameobject</returns>
        public static GameObject AddButtonWithMessage(DebugButtonPanel btnPanel, string btnLabel, string btnMessage)
        {
            Vector3 btnPos = btnPanel.transform.position;
            btnPos += btnPanel.transform.up * (btnPanel.ButtonQuantity * _3OGS_Utils.GetButtonSize().y);

            if (btnPanel.ButtonQuantity != 0)
                btnPos += btnPanel.transform.up * btnPanel.ButtonQuantity * _3OGS_Utils.GetButtonPanelOffset();

            GameObject newBtn = _3OGS_Debug.CreateDebugButton(btnLabel, btnPos, () => { return; }, false);

            newBtn.transform.rotation = btnPanel.transform.rotation;
            newBtn.transform.parent = btnPanel.transform;
            newBtn.GetComponent<DebugButton>().SetOnClickAction(() => { _3OGS_Debug.TextPopup(btnMessage, newBtn.transform.position + newBtn.transform.right * (_3OGS_Utils.GetButtonSize().x / 2 + _3OGS_Utils.GetButtonPanelOffset())); });

            btnPanel.ButtonQuantity++;
            return newBtn;
            
        }

        /// <summary>
        /// Instantiate and add to a DebugButtonPanel a new DebugButton that executes a function when clicked
        /// </summary>
        /// <param name="btnPanel">Debug button panel to add the new button</param>
        /// <param name="btnLabel">The label of the new button</param>
        /// <param name="onClickFunction">The method executed when click button</param>
        /// <returns>The new DebugButton gameobject</returns>
        public static GameObject AddButton(DebugButtonPanel btnPanel, string btnLabel, Action onClickFunction)
        {
            Vector3 btnPos = btnPanel.transform.position;
            btnPos += btnPanel.transform.up * (btnPanel.ButtonQuantity * _3OGS_Utils.GetButtonSize().y);

            if (btnPanel.ButtonQuantity != 0)
                btnPos += btnPanel.transform.up * btnPanel.ButtonQuantity  * _3OGS_Utils.GetButtonPanelOffset();

            GameObject newBtn = _3OGS_Debug.CreateDebugButton(btnLabel, btnPos, onClickFunction, false);

            newBtn.transform.rotation = btnPanel.transform.rotation;
            newBtn.transform.parent = btnPanel.transform;

            btnPanel.ButtonQuantity++;
            return newBtn;
        }
    }
}