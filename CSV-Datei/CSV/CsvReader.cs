using System;
using System.Collections.Generic;
using System.IO;

namespace CSV
{
    /// <summary>
    /// CsvReader Klasse zum auslesen einer Csv-Datei
    /// </summary>
    public class CsvReader
    {
        /// <summary>
        /// Pfad der Datei
        /// </summary>
        private string pfad;

        public string Pfad
        {
            get { return pfad; }
            set
            {
                if (File.Exists(value))
                    pfad = value;
                else
                    throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="pfad">Pfad der Datei</param>
        /// <exception cref="FileNotFoundException"></exception>
        public CsvReader(string pfad)
        {
            Pfad = pfad;
        }

        /// <summary>
        /// Liest alle Linien in der Csv-Datei und gibt diese als Liste zurück.
        /// </summary>
        /// <returns>Liste aller Linien. Felder getrennt mit Semikolon</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public List<string> ReadAllLines()
        {
            List<string> list = new List<string>();

            foreach (var line in File.ReadAllLines(Pfad))
            {
                list.Add(line);
            }

            return list;
        }

        /// <summary>
        /// Liest eine maximale Anzahl Linien in der Csv-Datei und gibt diese als Liste zurück.
        /// Falls die maximale Anzahl grösser ist als die Anzahl Linien in der Datei, werden alle Zurückgegeben.
        /// </summary>
        /// <param name="max">Maximale Anzahl Linien</param>
        /// <returns>Liste der Linien. Felder getrennt mit Semikolon.</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public List<string> ReadLines(int max)
        {
            List<string> list = new List<string>();
            list = ReadAllLines();

            if (max < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (max >= list.Count)
            {
                return list;
            }

            list.RemoveRange(max, list.Count - max);

            return list;
        }

        /// <summary>
        /// Liest eine maximale Anzahl Linien in der Csv-Datei ab einem index und gibt diese als Liste zurück.
        /// Falls die maximale Anzahl grösser ist als die Anzahl Linien in der Datei, werden alle Zurückgegeben.
        /// </summary>
        /// <param name="max">Maximale Anzahl Linien</param>
        /// <param name="index">Start Index</param>
        /// <returns>Liste der Linien. Felder getrennt mit Semikolon.</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public List<string> ReadLines(int max, int index)
        {
            List<string> list = new List<string>();

            list = ReadLinesIndex(index);

            if (max < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (max >= list.Count)
            {
                return list;
            }

            list.RemoveRange(max, list.Count - max);

            return list;

        }

        /// <summary>
        /// Liest alle Linien in der Csv-Datei ab einem index und gibt diese als Liste zurück.
        /// </summary>
        /// <param name="index">Start Index</param>
        /// <returns>Liste von Linien ab einem idex. Felder getrennt mit Semikolon.</returns>
        /// /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public List<string> ReadLinesIndex(int index)
        {
            List<string> list = new List<string>();
            list = ReadAllLines();

            if (index == 0)
            {
                return ReadAllLines();
            }
            if (index < 0 || index >= list.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            list.RemoveRange(0, index);

            return list;
        }

        /// <summary>
        /// Liest eine Linie an einem Index ein und gibt sie als String zurück.
        /// </summary>
        /// <param name="index">Index </param>
        /// <returns>String mit einer Linie. Felder getrennt mit Semikolon.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string ReadLine(int index)
        {
            List<string> list = new List<string>();
            list = ReadAllLines();

            if (index < 0 || index >= list.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return list[index];
        }
    }
}
