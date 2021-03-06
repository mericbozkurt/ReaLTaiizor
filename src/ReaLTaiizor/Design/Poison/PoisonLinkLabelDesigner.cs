﻿#region Imports

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace ReaLTaiizor.Design.Poison
{
    #region PoisonLinkLabelDesignerDesign

    internal class PoisonLinkLabelDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules => base.SelectionRules;

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("AutoEllipsis");
            properties.Remove("UseCompatibleTextRendering");

            //properties.Remove("Image");
            //properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("TextImageRelation");

            properties.Remove("UseVisualStyleBackColor");

            properties.Remove("Font");
            properties.Remove("RightToLeft");

            base.PreFilterProperties(properties);
        }
    }

    #endregion
}