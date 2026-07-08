using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EdgePackaging
{
    
    // An abastract class that implements the functionality of an image button
    // except for a single abstract method to load the Normal, Hot and Disabled 
    // images that represent the icon that is displayed on the button. The loading
    // of these images is done in each derived concrete class.
    public abstract class DataGridViewImageButtonCell : DataGridViewButtonCell
    {
        private bool _enabled;                // Is the button enabled
        private PushButtonState _buttonState; // What is the button state
        protected Image _buttonImageHot;      // The hot image
        protected Image _buttonImageNormal;   // The normal image
        protected Image _buttonImageDisabled; // The disabled image
        private int _buttonImageOffset;       // The amount of offset or border around the image

        protected DataGridViewImageButtonCell()
        {
            // In my project, buttons are disabled by default
            _enabled = false;
            _buttonState = PushButtonState.Disabled;

            // Changing this value affects the appearance of the image on the button.
            _buttonImageOffset = 2;

            // Call the routine to load the images specific to a column.
            LoadImages();
        }

        // Button Enabled Property
        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
                _buttonState = value ? PushButtonState.Normal : PushButtonState.Disabled;
            }
        }

        // PushButton State Property
        public PushButtonState ButtonState
        {
            get { return _buttonState; }
            set { _buttonState = value; }
        }

        // Image Property
        // Returns the correct image based on the control's state.
        public Image ButtonImage
        {
            get
            {
                switch (_buttonState)
                {
                    case PushButtonState.Disabled:
                        return _buttonImageDisabled;

                    case PushButtonState.Hot:
                        return _buttonImageHot;

                    case PushButtonState.Normal:
                        return _buttonImageNormal;

                    case PushButtonState.Pressed:
                        return _buttonImageNormal;

                    case PushButtonState.Default:
                        return _buttonImageNormal;

                    default:
                        return _buttonImageNormal;
                }
            }
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            //base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // Draw the cell background, if specified.
            if ((paintParts & DataGridViewPaintParts.Background) ==
                DataGridViewPaintParts.Background)
            {
                SolidBrush cellBackground =
                    new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(cellBackground, cellBounds);
                cellBackground.Dispose();
            }

            // Draw the cell borders, if specified.
            if ((paintParts & DataGridViewPaintParts.Border) ==
                DataGridViewPaintParts.Border)
            {
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                    advancedBorderStyle);
            }

            // Calculate the area in which to draw the button.
            // Adjusting the following algorithm and values affects
            // how the image will appear on the button.
            Rectangle buttonArea = cellBounds;

            Rectangle buttonAdjustment =
                BorderWidths(advancedBorderStyle);

            buttonArea.X += buttonAdjustment.X;
            buttonArea.Y += buttonAdjustment.Y;
            buttonArea.Height -= buttonAdjustment.Height;
            buttonArea.Width -= buttonAdjustment.Width;

            Rectangle imageArea = new Rectangle(
                buttonArea.X + _buttonImageOffset,
                buttonArea.Y + _buttonImageOffset,
                30,
                40);

            ButtonRenderer.DrawButton(graphics, buttonArea, ButtonImage, imageArea, false, ButtonState);
        }

        // An abstract method that must be created in each derived class.
        // The images in the derived class will be loaded here.
        public abstract void LoadImages();
    }


    public class DataGridViewImageButtonDeleteCell : DataGridViewImageButtonCell
    {
        public override void LoadImages()
        {
            // Load the Normal, Hot and Disabled "Delete" images here.
            // Load them from a resource file, local file, hex string, etc.

            _buttonImageHot = Image.FromFile(Application.StartupPath + "\\Image\\SecurityAndMaintenance_Error.png");
            _buttonImageNormal = Image.FromFile(Application.StartupPath + "\\Image\\SecurityAndMaintenance_Error.png");
            _buttonImageDisabled = Image.FromFile(Application.StartupPath + "\\Image\\SecurityAndMaintenance_Error.png");
        }
    }
    public class DataGridViewImageButtonDeleteColumn : DataGridViewButtonColumn
    {
        public DataGridViewImageButtonDeleteColumn()
        {
            this.CellTemplate = new DataGridViewImageButtonDeleteCell();
            this.Width = 40;
           
            this.Resizable = DataGridViewTriState.False;
        }
    }
    public class DataGridViewImageButtonEditCell : DataGridViewImageButtonCell
    {
        public override void LoadImages()
        {
            // Load the Normal, Hot and Disabled "Delete" images here.
            // Load them from a resource file, local file, hex string, etc.

            _buttonImageHot = Image.FromFile(Application.StartupPath + "\\Image\\Vigor_edit-writing-content-editing-48.png");
            _buttonImageNormal = Image.FromFile(Application.StartupPath + "\\Image\\Vigor_edit-writing-content-editing-48.png");
            _buttonImageDisabled = Image.FromFile(Application.StartupPath + "\\Image\\Vigor_edit-writing-content-editing-48.png");
        }
    }
    public class DataGridViewImageButtonEditColumn : DataGridViewButtonColumn
    {
        public DataGridViewImageButtonEditColumn()
        {
            this.CellTemplate = new DataGridViewImageButtonEditCell();
            this.Width = 40;
            this.Resizable = DataGridViewTriState.False;
        }
    }

    public class DataGridViewImageButtonPrintColumn : DataGridViewButtonColumn
    {
        public DataGridViewImageButtonPrintColumn()
        {
            this.CellTemplate = new DataGridViewImageButtonPrintCell();
            this.Width = 40;
            this.Resizable = DataGridViewTriState.False;
        }
    }

    public class DataGridViewImageButtonPrintCell : DataGridViewImageButtonCell
    {
        public override void LoadImages()
        {
            // Load the Normal, Hot and Disabled "Delete" images here.
            // Load them from a resource file, local file, hex string, etc.

            _buttonImageHot = Image.FromFile(Application.StartupPath + "\\Image\\15-128.png");
            _buttonImageNormal = Image.FromFile(Application.StartupPath + "\\Image\\15-128.png");
            _buttonImageDisabled = Image.FromFile(Application.StartupPath + "\\Image\\15-128.png");
        }
    }

}
