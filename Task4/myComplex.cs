using System;
namespace Task4
{
    public class myComplex
    {
        #region Fields
        private double _real;
        private double _image;
        public const double EPS = 1E-10;
        #endregion


        #region Constructors
        public myComplex() : this(0, 0)
        {
        }

        public myComplex(double real) : this(real, 0)
        {
        }

        public myComplex(double real, double image)
        {
            Re = real;
            Im = image;
        }
        #endregion


        #region Properties
        public double Re
        {
            get { return _real; }
            set { _real = value; }
        }

        public double Im
        {
            get { return _image; }
            set { _image = value; }
        }

        public double Module
        {
            get { return Math.Sqrt(Math.Pow(Im, 2) + Math.Pow(Re, 2)); }
        }

        public double Argument
        {
            get { return Math.Atan2(Im, Re); }
        }
        #endregion


        #region Methods
        public static myComplex? MakeTrigonometricComplex(double r, double phi)
        {
            if (r < 0)
            {
                return null;
            }
            return new myComplex(r * Math.Cos(phi), r * Math.Sin(phi));
        }
        #endregion


        #region Base Methods Overriding

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is myComplex))
            {
                return false;
            }

            myComplex complex = (myComplex)obj;

            double ReDiff = Math.Abs(Re - complex.Re);
            double ImDiff = Math.Abs(Im - complex.Im);

            return (ReDiff <= EPS) && (ImDiff <= EPS);

        }

        public override int GetHashCode()
        {
            return (Re.GetHashCode() << 2) ^ Im.GetHashCode();
        }

        public override string ToString()
        {
            string result = "";
            double real = Math.Round(Re, 10);
            double image = Math.Round(Im, 10);

            if (real != 0)
            {
                result += real;
            }

            if (image != 0)
            {
                if (image > 0)
                {
                    result += (result.Length > 0) ? "+" : "";
                }
                else
                {
                    result += "-";
                }

                if (Math.Abs(image) != 1)
                {
                    result += Math.Abs(image);
                }
                result += "i";
            }

            if (result.Length == 0)
            {
                result += "0";
            }

            return result;
        }
        #endregion


        #region Operators Overloading
        public static myComplex? operator +(myComplex lhs, myComplex rhs)
        {
            if (lhs is null || rhs is null)
            {
                return null;
            }
            return new myComplex(lhs.Re + rhs.Re, lhs.Im + rhs.Im);
        }


        public static myComplex? operator -(myComplex lhs, myComplex rhs)
        {
            if (lhs is null || rhs is null)
            {
                return null;
            }
            return new myComplex(lhs.Re - rhs.Re, lhs.Im - rhs.Im);
        }

        public static myComplex? operator *(myComplex lhs, myComplex rhs)
        {
            if (lhs is null || rhs is null)
            {
                return null;
            }
            double resultRe = lhs.Re * rhs.Re - lhs.Im * rhs.Im;
            double resultIm = lhs.Im * rhs.Re + lhs.Re * rhs.Im;
            return new myComplex(resultRe, resultIm);
        }

        public static myComplex? operator /(myComplex lhs, myComplex rhs)
        {
            if (lhs is null || rhs is null)
            {
                return null;
            }
            double resultRe = (lhs.Re * rhs.Re + lhs.Im * rhs.Im) / (Math.Pow(rhs.Re, 2) + Math.Pow(rhs.Im, 2));
            double resultIm = (lhs.Im * rhs.Re - lhs.Re * rhs.Im) / (Math.Pow(rhs.Re, 2) + Math.Pow(rhs.Im, 2));
            return new myComplex(resultRe, resultIm);
        }

        public static bool operator ==(myComplex lhs, myComplex rhs)
        {
            if (!(lhs is null))
            {
                return lhs.Equals(rhs);
            }

            if (!(rhs is null))
            {
                return rhs.Equals(lhs);
            }

            return true;
        }

        public static bool operator !=(myComplex lhs, myComplex rhs)
        {
            if (!(lhs is null))
            {
                return !lhs.Equals(rhs);
            }

            if (!(rhs is null))
            {
                return !rhs.Equals(lhs);
            }

            return false;
        }
        #endregion


        #region Type Conversions
        public static implicit operator myComplex(double real)
        {
            return new myComplex(real);
        }

        public static explicit operator double(myComplex complex)
        {
            if (complex is null)
            {
                return double.NaN;
            }
            return complex.Re;
        }
        #endregion
    }
}
