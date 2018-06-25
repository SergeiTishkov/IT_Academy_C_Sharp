
﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;

using MusicLibrary;

namespace IO_HW 
{
    class Program
    {
        static void Main(string[] args) // не стал морочиться с трай-кетчами, можно было, но зачем, я же без ошибок все ввел, для себя
        {
            AppSettingsReader ar = new AppSettingsReader();
            string pathOfAlbumsFolder = (string)ar.GetValue("MusicFolderPath", typeof(string));

            SerializeBinary(SetInSilicoPendulumAlbum(), pathOfAlbumsFolder);

            string pathOfFile = Path.Combine(pathOfAlbumsFolder, "Pendulum", "In Silico.txt");

            byte[] serializedAlbum = GetSerializedAlbum(pathOfFile);

            Album inSilico = DeserializeFromByteArray(serializedAlbum);

            Console.WriteLine(inSilico);

            Console.ReadKey(true);
        }

        static Album SetInSilicoPendulumAlbum()
        {
            Track[] tracks = new Track[] // да, можно было использовать для длительности песни не инт, а DateTime, и там указать минуты
            {                            // но мне было лень, простите. Суть задачи ведь не в этом была, верно?
                new Track("Showdown", 1, 327),
                new Track("Different", 2, 351),
                new Track("Propane Nightmares", 3, 313),
                new Track("Visions", 4, 336),
                new Track("Midnight Runner", 5, 415),
                new Track("The Other Side", 6, 315),
                new Track("Mutiny", 7, 309),
                new Track("9,000 Miles", 8, 386),
                new Track("Granite", 9, 281),
                new Track("The Tempest", 10, 447)
            };
            return new Album("In Silico", "Pendulum", 2008, tracks);
        }

        static void SerializeBinary(Album album, string pathOfAlbumsFolder)
        {
            string dirPath = $"{pathOfAlbumsFolder}{album.Author}";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string filePath = Path.Combine(pathOfAlbumsFolder, album.Author, $"{album.Name}.txt");

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                binaryFormatter.Serialize(stream, album);
            }
            Console.WriteLine($"Album \"{album.Name}\" of author \"{album.Author}\" was successfully serialized.");
            Console.ReadKey();
        }

        static Album DeserializeBinary(string pathOfFile)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            Album result;

            using (FileStream stream = File.Open(pathOfFile, FileMode.Open, FileAccess.Read))
            {
                result = binaryFormatter.Deserialize(stream) as Album;
            }
            return result;
        }

        static byte[] GetSerializedAlbum(string pathOfFile)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileInfo fi = new FileInfo(pathOfFile);

            byte[] result = new byte[fi.Length];

            using (FileStream stream = File.Open(pathOfFile, FileMode.Open, FileAccess.Read))
            {
                stream.Read(result, 0, (int)fi.Length);
            }
            return result;
        }

        static Album DeserializeFromByteArray(byte[] serializedAlbum)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Album result = null;

            using (MemoryStream ms = new MemoryStream(serializedAlbum))
            {
                result = binaryFormatter.Deserialize(ms) as Album;
            }
            return result;
        }

    }
}