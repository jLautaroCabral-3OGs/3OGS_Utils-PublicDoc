/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using _3OGS.Utils;
using UnityEngine;

/// <summary>
/// Contain the configuration for the debug gameobjects behaviour and grapics
/// </summary>
public class _3OGS_DebuggerConfig : MonoBehaviour
{
    [Header("Build Settings")]
    public bool IsBuildForProduction;

    [Header("Debug buttons")]
    public Vector3 DefaultButtonSize;
    public float DefaultButtonPanelOffset;
    public Sprite DefaultButtonSprite;
    public Color DefaultButtonColor;
    public Color DefaultButtonColorOnOver;
    public Color DefaultButtonColorOnClick;
    public LayerMask ButtonsLayerMask;

    [Header("Other settings")]
    public float DebugObjectsDrawDistance;
    public Font DefaultFont;
    public int DefaultFontSize;

    /// <summary>
    /// Create the default settings
    /// </summary>
    /// <returns>An instance of settings</returns>
    public static _3OGS_DebuggerConfig CreateDefaultSettings()
    {
        _3OGS_DebuggerConfig newSettigs = new _3OGS_DebuggerConfig();

        newSettigs.IsBuildForProduction = false;
        newSettigs.DefaultButtonSize = new Vector3(5, 0.6f, 0.1f);
        newSettigs.DefaultButtonPanelOffset = 0.2f;
        newSettigs.DefaultButtonSprite = Resources.Load<Sprite>("DefaultButtonSprite");
        newSettigs.DefaultButtonColor = _3OGS_Utils.GetColorFromString("FFFFFF");
        newSettigs.DefaultButtonColorOnOver = _3OGS_Utils.GetColorFromString("EAEAEA"); ;
        newSettigs.DefaultButtonColorOnClick = _3OGS_Utils.GetColorFromString("BFBFBF"); ;
        newSettigs.ButtonsLayerMask = LayerMask.GetMask("Default");

        newSettigs.DebugObjectsDrawDistance = 50f;
        newSettigs.DefaultFont = Resources.Load<Font>("DefaultFont");
        newSettigs.DefaultFontSize = 24;

        return newSettigs;
    }
}
