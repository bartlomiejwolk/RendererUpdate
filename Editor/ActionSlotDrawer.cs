﻿using UnityEditor;
using UnityEngine;

namespace RendererUpdate {

    [CustomPropertyDrawer(typeof(ActionSlot))]
    public sealed class ActionSlotDrawer : PropertyDrawer {

        #region CONSTANTS

        // Hight of a single property.
        private const int PropHeight = 16;

        // Margin between properties.
        private const int PropMargin = 4;

        // Space between rows.
        private const int RowSpace = 8;

        // Number of rows.
        private const int Rows = 2;

        #endregion

        #region UNITY METHODS

        public override float GetPropertyHeight(
            SerializedProperty property,
            GUIContent label) {

            // Calculate property height.
            return base.GetPropertyHeight(property, label)
                   * Rows // Each row is 16 px high.
                   + (Rows - 1) * RowSpace;
        }

        public override void OnGUI(
            Rect pos,
            SerializedProperty prop,
            GUIContent label) {

            var action = prop.FindPropertyRelative("action");
            var renderingMode =
                prop.FindPropertyRelative("renderingMode");
            var alphaInValue =
                prop.FindPropertyRelative("alphaInValue");
            var alphaOutValue =
                prop.FindPropertyRelative("alphaOutValue");

            DrawActionDropdown(pos, action);
            HandleDrawRenderingMode(pos, action, renderingMode);
        }

        private void HandleDrawRenderingMode(
            Rect pos,
            SerializedProperty action,
            SerializedProperty renderingMode) {

            if (action.enumValueIndex != (int) RendererAction.SetRenderingMode) {
                return;
            }

            EditorGUI.PropertyField(
                new Rect(
                    pos.x,
                    pos.y + 1 * (PropHeight + PropMargin),
                    pos.width,
                    PropHeight),
                renderingMode,
                new GUIContent("Mode", "Rendering Mode"));
        }

        #endregion

        #region METHODS

        private void DrawActionDropdown(
            Rect pos,
            SerializedProperty action) {

            EditorGUI.PropertyField(
                new Rect(
                    pos.x,
                    pos.y,
                    pos.width,
                    PropHeight),
                action,
                new GUIContent("Action Type", ""));
        }

        #endregion

    }

}