using Mobile.Gestures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

        }

        private Color _backgroundColor = Color.Black;
        public Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }

        private Color _textColor = Color.White;
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
                OnPropertyChanged();
            }
        }

        private ICommand _pressedCommand = null;
        public ICommand PressedGestureCommand
        {
            get
            {
                if (_pressedCommand == null)
                    _pressedCommand = new Command((parameter) =>
                    {
                        BackgroundColor = Color.White;
                        TextColor = Color.Black;
                    });

                return _pressedCommand;
            }


        }

        private ICommand _releasedCommand = null;
        public ICommand ReleasedGestureCommand
        {
            get
            {
                if (_releasedCommand == null)
                    _releasedCommand = new Command((parameter) =>
                    {
                        BackgroundColor = Color.Black;
                        TextColor = Color.White;
                    });

                return _releasedCommand;
            }

        }
    }
}
