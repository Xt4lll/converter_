using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Serialization;

namespace converter_
{

    public class File_
    {
        public static string content;
        public static string location;
        static string[] pets_ = new string [] { "cat", "dog" };
        static model Jamal = new model("Jamal", 74, pets_ );


        public static void Save()
        {
            Console.WriteLine("нажмите F1 чтобы сохранить файл");
            ConsoleKeyInfo F = Console.ReadKey();
            if (F.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("введите название файла");
                location = Console.ReadLine();
                FileInfo fi_ = new FileInfo(location);
                if (fi_.Extension == ".txt")
                {
                    TxtSave();
                }
                if (fi_.Extension == ".json")
                {
                    JsonSave();
                }
                if (fi_.Extension == ".xml")
                {
                    XmlSave();
                }
            }
        }

        public static void Loc()
        {

            Console.WriteLine("укажите расположение файла, который хотите открыть");
            location = Console.ReadLine();
            FileInfo fi = new FileInfo(location);
            if (fi.Extension == ".txt")
            {
                Txt();
                Save();
            }
            if (fi.Extension == ".json")
            {
                Json();
                Save();
            }
            if (fi.Extension == ".xml")
            {
                Xml();
                Save();
            }

        }

        public static void Txt()
        {
            content = File.ReadAllText(location);
            Console.WriteLine(content);
        }

        public static void Json()
        {
            content = File.ReadAllText(location);
            List<model> res = JsonConvert.DeserializeObject<List<model>> (content);
            foreach(model i in res)
            {
                Console.WriteLine(i);
            }
        }

        public static void Xml()
        {
            model mod;
            XmlSerializer xml = new XmlSerializer(typeof(model));
            using (FileStream fs = new FileStream(location, FileMode.Open))
            {
                mod = (model)xml.Deserialize(fs);
            }
        }

        public static void TxtSave()
        {
            File.WriteAllText(location, content);
        }

        public static void JsonSave()
        {
            string json = JsonConvert.SerializeObject(Jamal);
            File.WriteAllText(location, json);
        }

        public static void XmlSave()
        {
            XmlSerializer xmls = new XmlSerializer(typeof(model));
            using (FileStream fss = new FileStream(location, FileMode.OpenOrCreate))
            {
                xmls.Serialize(fss, Jamal);
            }
        }

    }
}