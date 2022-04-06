using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace HandsomeStudio.Tools
{

    public static class DebugHepler 
	{
        public static void GizmosDrawText(string text, Vector3 position, Color color, GUISkin guiSkin = null, int fontSize = 12)
        {
#if UNITY_EDITOR
            //DrawGizmoPoint(position, 0.025f, color);

            var prevSkin = GUI.skin;

            var newSkin = guiSkin;
            if (newSkin == null)
                newSkin = prevSkin;
            else
                GUI.skin = guiSkin;

            GUIContent textContent = new GUIContent(text);

            GUIStyle style = (guiSkin != null) ? new GUIStyle(guiSkin.GetStyle("Label")) : new GUIStyle();
            if (color != null)
                style.normal.textColor = (Color)color;
            if (fontSize > 0)
                style.fontSize = fontSize;

            Vector2 textSize = style.CalcSize(textContent);
            Vector3 screenPoint = Camera.current.WorldToScreenPoint(position);

            if (screenPoint.z > 0) // checks necessary to the text is not visible when the camera is pointed in the opposite direction relative to the object
            {
                var worldPosition = Camera.current.ScreenToWorldPoint(new Vector3(screenPoint.x - textSize.x * 0.5f, screenPoint.y + textSize.y * 0.5f, screenPoint.z));
                UnityEditor.Handles.Label(worldPosition, textContent, style);
            }
            GUI.skin = prevSkin;
#endif
        }

        /// <summary>
        /// Outputs the message object to the console, prefixed with the current timestamp
        /// </summary>
        /// <param name="message">Message.</param>
        public static void DebugLogTime(object message)
		{
			Debug.Log (Time.time + " " + message);

		}

        /// <summary>
        /// Draws a gizmo arrow going from the origin position and along the direction Vector3
        /// </summary>
        /// <param name="origin">Origin.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="color">Color.</param>
        public static void GizmosDrawArrow(Vector3 origin, Vector3 direction, Color color)
	    {
			float arrowHeadLength = 3.00f;
			float arrowHeadAngle = 25.0f;

	        Gizmos.color = color;
	        Gizmos.DrawRay(origin, direction);
	       
			DrawArrowEnd(true,origin,direction,color,arrowHeadLength,arrowHeadAngle);
	    }

	    /// <summary>
		/// Draws a debug arrow going from the origin position and along the direction Vector3
	    /// </summary>
	    /// <param name="origin">Origin.</param>
	    /// <param name="direction">Direction.</param>
	    /// <param name="color">Color.</param>
	    public static void DebugDrawArrow(Vector3 origin, Vector3 direction, Color color)
	    {
			float arrowHeadLength = 0.20f;
			float arrowHeadAngle = 35.0f;

	        Debug.DrawRay(origin, direction, color);
	       
			DrawArrowEnd(false,origin,direction,color,arrowHeadLength,arrowHeadAngle);
	    }


		private static void DrawArrowEnd (bool drawGizmos, Vector3 arrowEndPosition, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 40.0f)
	    {
	        Vector3 right = Quaternion.LookRotation (direction) * Quaternion.Euler (arrowHeadAngle, 0, 0) * Vector3.back;
	        Vector3 left = Quaternion.LookRotation (direction) * Quaternion.Euler (-arrowHeadAngle, 0, 0) * Vector3.back;
	        Vector3 up = Quaternion.LookRotation (direction) * Quaternion.Euler (0, arrowHeadAngle, 0) * Vector3.back;
	        Vector3 down = Quaternion.LookRotation (direction) * Quaternion.Euler (0, -arrowHeadAngle, 0) * Vector3.back;
	        if (drawGizmos) 
	        {
	            Gizmos.color = color;
	            Gizmos.DrawRay (arrowEndPosition + direction, right * arrowHeadLength);
	            Gizmos.DrawRay (arrowEndPosition + direction, left * arrowHeadLength);
	            Gizmos.DrawRay (arrowEndPosition + direction, up * arrowHeadLength);
	            Gizmos.DrawRay (arrowEndPosition + direction, down * arrowHeadLength);
	        }
	        else
	        {
	            Debug.DrawRay (arrowEndPosition + direction, right * arrowHeadLength, color);
	            Debug.DrawRay (arrowEndPosition + direction, left * arrowHeadLength, color);
	            Debug.DrawRay (arrowEndPosition + direction, up * arrowHeadLength, color);
	            Debug.DrawRay (arrowEndPosition + direction, down * arrowHeadLength, color);
	        }
	    }

		/// <summary>
		/// Draws a gizmo sphere of the specified size and color at a position
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="size">Size.</param>
		/// <param name="color">Color.</param>
		public static void DrawGizmoPoint(Vector3 position, float size, Color color)
		{
	    	Gizmos.color = color;
			Gizmos.DrawWireSphere(position,size);
		}


	}
}
