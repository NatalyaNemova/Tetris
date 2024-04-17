using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class FileSystem
    {
        private static BinaryFormatter formatter = new BinaryFormatter();
     

        public static SettingOfLevel[] FormListOfSettings()
        {
            SettingOfLevel[] settings = new SettingOfLevel[3];
            using (FileStream fs = new FileStream("level.level", FileMode.Open))
                return (SettingOfLevel[])formatter.Deserialize(fs);
        }
        public static List<Figure> FormListOfFigures()
        {
            List<Figure> figures = new List<Figure>();
            using (FileStream fs = new FileStream("fig.fig", FileMode.Open))
                return (List<Figure>)formatter.Deserialize(fs);
        }
        public static List<Cup> FormListOfCups()
        {
            List<Cup> cups = new List<Cup>();
            using (FileStream fs = new FileStream("cup.cup", FileMode.Open))
                return (List<Cup>)formatter.Deserialize(fs);
        }

        public static List<Rating> FormListOfRatings()
        {
            List<Rating> ratings = new List<Rating>();
            if (new FileInfo("rating.rat").Length == 0)
            {
                Rating admin = new Rating("Admin",false,0 );
                ratings.Add(admin);
                using (FileStream fs = new FileStream("rating.rat", FileMode.Open))
                    formatter.Serialize(fs, ratings);
            }
            using (FileStream fs = new FileStream("rating.rat", FileMode.Open))
                return (List<Rating>)formatter.Deserialize(fs);
        }
    }
}
