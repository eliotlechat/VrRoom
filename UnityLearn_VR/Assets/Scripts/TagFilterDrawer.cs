using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TagFilterAttribute))]
public class TagFilterDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String)
        {
            // R�cup�rer tous les tags d�finis dans le projet
            string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

            // Trouver l'index actuel du tag s�lectionn�
            int index = Mathf.Max(0, System.Array.IndexOf(tags, property.stringValue));

            // Afficher la liste d�roulante et r�cup�rer l'index s�lectionn�
            index = EditorGUI.Popup(position, label.text, index, tags);

            // Mettre � jour la valeur du champ avec le tag s�lectionn�
            property.stringValue = tags[index];
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
