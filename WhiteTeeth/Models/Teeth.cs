using System;

using Xamarin.Forms;
using Color = System.Drawing.Color;
namespace WhiteTeeth.Models
{
    public class Teeth
    {
        private static Tooth A1 =   new Tooth("A1"  , "WhiteTeeth.Resources.ToothColors.A1.png",  Color.FromArgb(222, 209, 177),"A1"  );
        private static Tooth A2 =   new Tooth("A2"  , "WhiteTeeth.Resources.ToothColors.A2.png",  Color.FromArgb(219, 201, 161),"A2"  );
        private static Tooth A3 =   new Tooth("A3"  , "WhiteTeeth.Resources.ToothColors.A3.png",  Color.FromArgb(219, 199, 152),"A3"  );
        private static Tooth A3_5 = new Tooth("A3,5", "WhiteTeeth.Resources.ToothColors.A3,5.png",Color.FromArgb(216, 192, 139),"A3,5");
        private static Tooth A4 =   new Tooth("A4"  , "WhiteTeeth.Resources.ToothColors.A4.png",  Color.FromArgb(208, 180, 125),"A4"  );
        private static Tooth B1 =   new Tooth("B1"  , "WhiteTeeth.Resources.ToothColors.B1.png",  Color.FromArgb(221, 211, 184),"B1"  );
        private static Tooth B2 =   new Tooth("B2"  , "WhiteTeeth.Resources.ToothColors.B2.png",  Color.FromArgb(219, 203, 162),"B2"  );
        private static Tooth B3 =   new Tooth("B3"  , "WhiteTeeth.Resources.ToothColors.B3.png",  Color.FromArgb(217, 196, 142),"B3"  );
        private static Tooth B4 =   new Tooth("B4"  , "WhiteTeeth.Resources.ToothColors.B4.png",  Color.FromArgb(215, 189, 127),"B4"  );
        private static Tooth C1 =   new Tooth("C1"  , "WhiteTeeth.Resources.ToothColors.C1.png",  Color.FromArgb(211, 197, 164),"C1"  );
        private static Tooth C2 =   new Tooth("C2"  , "WhiteTeeth.Resources.ToothColors.C2.png",  Color.FromArgb(208, 189, 142),"C2"  );
        private static Tooth C3 =   new Tooth("C3"  , "WhiteTeeth.Resources.ToothColors.C3.png",  Color.FromArgb(205, 186, 142),"C3"  );
        private static Tooth C4 =   new Tooth("C4"  , "WhiteTeeth.Resources.ToothColors.C4.png",  Color.FromArgb(197, 170, 118),"C4"  );
        private static Tooth D2 =   new Tooth("D2"  , "WhiteTeeth.Resources.ToothColors.D2.png",  Color.FromArgb(213, 198, 162),"D2"  );
        private static Tooth D3 =   new Tooth("D3"  , "WhiteTeeth.Resources.ToothColors.D3.png",  Color.FromArgb(214, 196, 153),"D3"  );
        private static Tooth D4 =   new Tooth("D4"  , "WhiteTeeth.Resources.ToothColors.D4.png",  Color.FromArgb(212, 194, 146), "D4");

        public Tooth[] teeth { get; } = {A1, A2, A3, A3_5, A4,
                               B1, B2, B3, B4,
                               C1, C2, C3, C4,
                               D2, D3, D4}; 

        public Tooth getToothByName(string name)
        {
            foreach(Tooth tooth in teeth)
            {
                if (tooth.name.Equals(name)){
                    return tooth;
                }
            }

            return null;
        }
         
    }

}