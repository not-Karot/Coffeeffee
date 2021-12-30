using System;

using Xamarin.Forms;
using Color = System.Drawing.Color;
namespace Coffeeffee.Models
{
    public class Teeth
    {
       
        
        public static Tooth A1 =   new Tooth("A1"  , "Coffeeffee.Resources.ToothColors.A1.png", Color.FromArgb(222, 209, 177),"A1"  );
        public static Tooth A2 =   new Tooth("A2"  , "Coffeeffee.Resources.ToothColors.A2.png", Color.FromArgb(219, 201, 161),"A2"  );
        public static Tooth A3 =   new Tooth("A3"  , "Coffeeffee.Resources.ToothColors.A3.png", Color.FromArgb(219, 199, 152),"A3"  );
        public static Tooth A3_5 = new Tooth("A3,5","Coffeeffee.Resources.ToothColors.A3,5.png",Color.FromArgb(216, 192, 139),"A3,5");
        public static Tooth A4 =   new Tooth("A4"  , "Coffeeffee.Resources.ToothColors.A4.png", Color.FromArgb(208, 180, 125),"A4"  );
        public static Tooth B1 =   new Tooth("B1"  , "Coffeeffee.Resources.ToothColors.B1.png", Color.FromArgb(221, 211, 184),"B1"  );
        public static Tooth B2 =   new Tooth("B2"  , "Coffeeffee.Resources.ToothColors.B2.png", Color.FromArgb(219, 203, 162),"B2"  );
        public static Tooth B3 =   new Tooth("B3"  , "Coffeeffee.Resources.ToothColors.B3.png", Color.FromArgb(217, 196, 142),"B3"  );
        public static Tooth B4 =   new Tooth("B4"  , "Coffeeffee.Resources.ToothColors.B4.png", Color.FromArgb(215, 189, 127),"B4"  );
        public static Tooth C1 =   new Tooth("C1"  , "Coffeeffee.Resources.ToothColors.C1.png", Color.FromArgb(211, 197, 164),"C1"  );
        public static Tooth C2 =   new Tooth("C2"  , "Coffeeffee.Resources.ToothColors.C2.png", Color.FromArgb(208, 189, 142),"C2"  );
        public static Tooth C3 =   new Tooth("C3"  , "Coffeeffee.Resources.ToothColors.C3.png", Color.FromArgb(205, 186, 142),"C3"  );
        public static Tooth C4 =   new Tooth("C4"  , "Coffeeffee.Resources.ToothColors.C4.png", Color.FromArgb(197, 170, 118),"C4"  );
        public static Tooth D2 =   new Tooth("D2"  , "Coffeeffee.Resources.ToothColors.D2.png", Color.FromArgb(213, 198, 162),"D2"  );
        public static Tooth D3 =   new Tooth("D3"  , "Coffeeffee.Resources.ToothColors.D3.png", Color.FromArgb(214, 196, 153),"D3"  );
        public static Tooth D4 =   new Tooth("D4"  , "Coffeeffee.Resources.ToothColors.D4.png", Color.FromArgb(212, 194, 146), "D4");

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