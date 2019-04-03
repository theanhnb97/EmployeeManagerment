namespace CommonLibrary.Enumerator
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Enumerator" />
    /// </summary>
    public class Enumerator
    {
        /// <summary>
        /// The BindEnumToCombobox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comboBox">The comboBox<see cref="ComboBox"/></param>
        /// <param name="defaultSelection">The defaultSelection<see cref="T"/></param>
        /// <returns>The <see cref="object"/></returns>
        public static object BindEnumToCombobox<T>(ComboBox comboBox, T defaultSelection)
        {
            var list = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(value => new
                {
                    Description = (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute)?.Description ?? value.ToString(),
                    Value = value
                })
                .OrderBy(item => item.Value.ToString())
                .ToList();

            comboBox.DataSource = list;
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "Value";

            foreach (var opts in list)
            {
                if (opts.Value.ToString() == defaultSelection.ToString())
                {
                    comboBox.SelectedItem = opts;
                }
            }
            return list;
        }

        /// <summary>
        /// The GetDescription
        /// </summary>
        /// <param name="value">The value<see cref="Enum"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
