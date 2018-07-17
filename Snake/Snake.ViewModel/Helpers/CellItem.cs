using GalaSoft.MvvmLight;

namespace Snake.ViewModel.Helpers
{
    public class CellItem : ObservableObject
    {
        #region Fields

        private int _id;
        private double _x;
        private double _y;
        private double _width;
        private double _height;
        private string _fill;

        #endregion

        #region Properties

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged();
            }
        }

        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                if (_x == value)
                {
                    return;
                }

                _x = value;
                RaisePropertyChanged();
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                if (_y == value)
                {
                    return;
                }

                _y= value;
                RaisePropertyChanged();
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }

            set
            {
                if (_width == value)
                {
                    return;
                }

                _width = value;
                RaisePropertyChanged();
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }

            set
            {
                if (_height == value)
                {
                    return;
                }

                _height = value;
                RaisePropertyChanged();
            }
        }

        public string Fill
        {
            get
            {
                return _fill;
            }

            set
            {
                if (_fill == value)
                {
                    return;
                }

                _fill = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public CellItem(int id, double x, double y, double width, double height, string fill)
        {
            Id = id;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Fill = fill;
        }

        #endregion
    }
}