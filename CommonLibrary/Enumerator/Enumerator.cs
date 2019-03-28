using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary.Enumerator
{
    public class Enumerator
    {
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
