using System;
using System.Collections.Generic;
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
            Pfad = pfad;
        }

        /// <summary>
        /// Konstruktor mit ueberschreiber
        /// </summary>
        /// <param name="pfad">Pfad der Datei</param>
        /// <param name="ueberschreiben">true = Inhalt wird überschrieben. Standard = false</param>
        public CsvWriter(string pfad, bool ueberschreiben)
            : this(pfad)
        {
            Ueberschreiben = ueberschreiben;
        }

        /// <summary>
        /// Schreibt alle Linien im Array in die Csv-Datei.
        /// </summary>
        /// <param name="linien">Liste aller Linien</param>
        /// <param name="feld_trennzeichen">Gibt an wie die Felder in jeder Linie(jedes Feld in der Liste) getrennt sind</param>
        /// /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void AddLines(List<string> linien, char feld_trennzeichen)
        {
            string datenalle = "";

            foreach (var linie in linien)
            {
                string daten = "";

                string[] felder = linie.Split(feld_trennzeichen);

                foreach (var feld in felder)
                {
                    if (feld == felder[0])
                        daten = $"{feld}";
                    else
                        daten += $";{feld}";
                }

                datenalle += daten + "\n";

            }

            var streamWriter = new StreamWriter(Pfad, !Ueberschreiben);

            streamWriter.Write(datenalle);

            streamWriter.Close();
        }
    }
}
