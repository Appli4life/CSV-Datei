using System;
using System.IO;

namespace CSV
{
    /// <summary>
    /// CsvWriter Klasse zum schreiben in eine Csv-Datei
    /// </summary>
    public class CsvWriter
    {
        /// <summary>
        /// Pfad der Datei
        /// </summary>
        public string Pfad { get; private set; }

        /// <summary>
        /// Überschreiben oder nicht
        /// </summary>
        public bool Ueberschreiben { get; set; } = true;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="pfad">Pfad der Datei</param>
        /// <exception cref="FileNotFoundException"></exception>
        public CsvWriter(string pfad)
        {
            if (File.Exists(pfad))
            {
                Pfad = pfad;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Konstruktor mit ueberschreiber
        /// </summary>
        /// <param name="pfad">Pfad der Datei</param>
        /// <param name="ueberschreiben">true = Inhalt wird überschrieben. Standard = false</param>
        public CsvWriter(string pfad, bool ueberschreiben)
            :this(pfad)
        {
            Ueberschreiben = ueberschreiben;
        }

        /// <summary>
        /// Schreibt alle Felder in die Csv-Datei.
        /// </summary>
        /// <param name="felder">Alle Felder in einem Array</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void AddLine(string[] felder)
        {
            string daten = "";

            foreach (var feld in felder)
            {
                if (feld == felder[0])
                    daten = $"{feld}";
                else
                    daten += $";{feld}";
            }

            var streamWriter = new StreamWriter(Pfad, !Ueberschreiben);

            streamWriter.Write(daten + "\n");

            streamWriter.Close();
        }

        /// <summary>
        /// Schreibt alle Linien im Array in die Csv-Datei.
        /// </summary>
        /// <param name="linien">Liste aller Linien</param>
        /// <param name="feld_trennzeichen">Gibt an wie die Felder in jeder Linie(Jedes Array Feld) getrennt sind</param>
        /// /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void AddLines(string[] linien, char feld_trennzeichen)
        {
            foreach (var linie in linien)
            {
                AddLine(linie.Split(feld_trennzeichen));
            }
        }
    }
}
