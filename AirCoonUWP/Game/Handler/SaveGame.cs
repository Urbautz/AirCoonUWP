using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Geo;
using AirCoon.Game.Models.Aircraft;
using AirCoon.Game.Models.Routing;
using AirCoon.Game.Models.Airlines;

namespace AirCoon.Game.Handler
{
    [Serializable]
    public class SaveGame
    {

        private List<String> AllSaveGameNames;
        private String SaveGameFolder;
        private String[] SaveGamePath = new String[] { "AirCoon", "saves"};
        private String ConcreteSaveGameFolder;
        private String ConfigPath;

        public Dictionary<String, Continent> Continents = new Dictionary<String, Continent>();
        public Dictionary<String, Country> Countries = new Dictionary<String, Country>();
        public Dictionary<String, Region> Regions = new Dictionary<String, Region>();
        public Dictionary<String, Airport> Airports = new Dictionary<string, Airport>();
        public Dictionary<String, Manufacturer> Manufacturers = new Dictionary<string, Manufacturer>();
        public Dictionary<String, Aircraft> Aircrafts = new Dictionary<string, Aircraft>();

        public Dictionary<Int64, Tick> Ticks = new Dictionary<Int64, Tick>();

        public Dictionary<String, Connection> Connections = new Dictionary<String, Connection>();
        public Dictionary<String, Models.Routing.Path> Paths = new Dictionary<String, Models.Routing.Path>();
        public Dictionary<String, Airline> Airlines = new Dictionary<string, Airline>();
        /*
         
         */
        public SaveGame()
        {

        }

        /* Return all availibe SaveGames
         */
        public void SetPaths()
        {
            // Config Path
            ConfigPath = Environment.CurrentDirectory;
            ConfigPath += "\\Data";

            // Savegamepath
            this.SaveGameFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            
            AllSaveGameNames = new List<String>();
            SaveGameFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            SaveGameFolder = localFolder.Path;
            //

            if (!Directory.Exists(SaveGameFolder))
            {
                throw new System.InvalidOperationException("Savegame-Folder cannot be found");
            }
            foreach (String folder in SaveGamePath)
            {
                SaveGameFolder += "\\" + folder;
                
                if (!Directory.Exists(SaveGameFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(SaveGameFolder);
                    Debug.Write("Savegamefolder had to be created - might be first launch", 3);
                }

            } // End foreach

        } // End set path

        public static List<String> GetAvailibleSavegames()
        {
            SaveGame sg = new SaveGame();
            sg.SetPaths();
            

           String[] AllSaveGamePath =  Directory.GetDirectories(sg.SaveGameFolder);
           foreach(String path in AllSaveGamePath)
            {
                sg.AllSaveGameNames.Add(path.Substring(path.Length-3));
            }
           return sg.AllSaveGameNames;

        } // end getavailiblesavegames


        public List<Dictionary<string, string>> GetAvailibleHubNames()
        {
            List<Dictionary<string, string>> airports = new List<Dictionary<string, string> >();
            this.SetPaths();
            StreamReader stream = new StreamReader(ConfigPath + "\\airports.dat");
            DataCsvLoader csv = new DataCsvLoader(stream, false,true);
            Dictionary<string,string> line = csv.GetNextLineHeaders();
            while (line != null)
            {
                if (line["IsHub"] == "1")

                        airports.Add(line);
                line = csv.GetNextLineHeaders();
            }

                return airports;
        }


        /* This just loads the savegame*/
        public SaveGame(String savegamename) {
            SaveGamePublic.SaveGame = this;
            this.Load(savegamename);
            
        } // end constructor




        /* This copies all the files to a new savegamefolder and then loads the savegame */
        public SaveGame(String hub, String code, String name)
        {
            SaveGamePublic.SaveGame = this;
            this.SetPaths();
            // Get Config Path
            // Check Code
            // check if name already exists

            if(code.Length < 2 || code.Length > 3)
            {
                throw new SaveGameException("Code " + code + " must be 2 or 3 digits long");
            }
            code = code.ToUpper();


            // Check letters
            string pattern = @"^[a-zA-Z]+$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(code))
            {
                throw new SaveGameException("Code " + code + " is not valid.");
            }


            // Check Savegamefolder

            if (Directory.Exists(SaveGameFolder + "\\" + code))
            {
                throw new SaveGameException("Savegame" + code + " already exists.");
            }

            // Create directory
            //Debug.Write("Creating Directory: " + SaveGameFolder + "\\" + code, 2);
            ConcreteSaveGameFolder = SaveGameFolder + "\\" + code;
            Directory.CreateDirectory(ConcreteSaveGameFolder);

            // Load Continents
            Debug.Write("Loading Continents", 3);
            StreamReader stream = new StreamReader(ConfigPath + "\\Continents.dat");
            DataCsvLoader csv = new DataCsvLoader(stream, true);
            List<Continent> continents = new List<Continent>();
            string[] line = csv.GetNextLine();
            do
            {
                String contcode = line[0];
                String contname = line[1];
                int[] weather = new int[12];
                for (int i = 2; i < 14; i++)
                {
                    weather[i - 2] = Int32.Parse(line[i]);
                }
                Continent c = new Continent(contcode, contname, weather);
                line = csv.GetNextLine();
            } while (line != null);
            stream = null;


            // Initialize Countries
            Debug.Write("Loading Countries", 3);
            stream = new StreamReader(ConfigPath + "\\Countries.dat");
            csv = new DataCsvLoader(stream, true);
            line = csv.GetNextLine();
            while(line != null)
            {   
                if (!this.Continents.ContainsKey(line[2])) {
                    throw new Exception("Continent not found: " + line[3]);
                }
                Continent cont = this.Continents[line[2]];
                Country country = new Country(line[0], line[1], cont);
                line = csv.GetNextLine();
            }

            // Initialize Regions
            Debug.Write("Loading Regions", 3);
            stream = new StreamReader(ConfigPath + "\\regions.dat");
            csv = new DataCsvLoader(stream, true);
            line = csv.GetNextLine();
            while (line != null)
            {
                if (!this.Countries.ContainsKey(line[1]))
                {
                    throw new Exception("Country not found: " + line[1]);
                }
                Country c = this.Countries[line[1]];
                Region r = new Region(line[0], line[2], c);
                line = csv.GetNextLine();
            }

            //Regionen und Flughäfen laden.
            Debug.Write("Loading Airports", 3);

            stream = new StreamReader(ConfigPath + "\\airports.dat");
            csv = new DataCsvLoader(stream, true);
            line = csv.GetNextLine();
            while (line != null)
            {
                if (!this.Regions.ContainsKey(line[2]))
                {
                    throw new Exception("Region not found: " + line[2]);
                }
                Region r = this.Regions[line[2]];
                bool Ishub;
                if (line[5] == "1")
                    Ishub = true;
                else Ishub = false;

                GeoCoordinate g;
                short RunwayLength;
                short RunwayCount;
                short slots;
                int passengers;

                try
                {
                    g = new GeoCoordinate(Decimal.Parse(line[6]), Decimal.Parse(line[7]), Int32.Parse(line[8]));
                    RunwayLength = Int16.Parse(line[10]);
                    RunwayCount = Int16.Parse(line[11]);
                    slots = Int16.Parse(line[12]);
                    passengers = Int32.Parse(line[13]);

                } catch (FormatException e)
                {
                    Debug.Write(e.Message);
                    throw new SaveGameException("Airport data corrupted. Airport: " + line[0] + "Not a number:" 
                                + line[6] + ", " + line[8] + ", " + line[8] + ", "+ line[10] + ", "+ line[11] + ", " + line[12] + ", " + line[13]
                                );
                }

                Airport a = new Airport(line[0], line[1], line[4], r, Ishub, g, line[9], line[3], RunwayLength, RunwayCount, slots, passengers);
                foreach (KeyValuePair<String, Airport> b in this.Airports)
                {
                    if (a.Continent.Code == b.Value.Continent.Code)
                    {
                        Connection c = new Connection(a, b.Value);
                        if (c.Distance < 200 && a.Iata != b.Key)
                        {
                            c = c.Register();
                            Models.Routing.Path p = new GroundPath(c);
                        }
                    }
                } // end Floreach

                line = csv.GetNextLine();
            } // End Load Airports


            
            // Loading Manufacturers
            Debug.Write("Loading Manufacturers",3);
            stream = new StreamReader(ConfigPath + "\\manufacturers.dat");
            csv = new DataCsvLoader(stream, false,true);
            Dictionary<string,string> dic = csv.GetNextLineHeaders();
            while (dic != null)
            {
                Manufacturer M = new Manufacturer(dic["Manufacturer"], 
                                                  Int32.Parse(dic["Parallel"]),
                                                  Int32.Parse(dic["PointsPerDay"])
                                                 );
                dic = csv.GetNextLineHeaders();
            }

            // Loading Manufacturers
            Debug.Write("Loading Aircrafts", 3);
            stream = new StreamReader(ConfigPath + "\\aircraft.dat");
            csv = new DataCsvLoader(stream, false, true);
            dic = csv.GetNextLineHeaders();
            while (dic != null)
            {
                Aircraft A = new Aircraft(dic);
                dic = csv.GetNextLineHeaders();
            }


            Debug.Write("Load complete", 1);
            this.Save();
            
        } // End constructor 

        /* will load an existing savegame, to be called by the Constructors */
        private void Load(String savegamename)
        {
            this.SetPaths();
        } // end savegameload


        // Saves the game
        public void Save()
        {
            // Inspired by https://www.codeproject.com/Articles/1789/Object-Serialization-using-C
            this.SetPaths();
            BinaryFormatter bformatter = new BinaryFormatter();
            Debug.Write("Saving ...", 1);

            Debug.Write("Saving Continents", 2);
            // Continents
            using (Stream stream = File.Open(this.ConcreteSaveGameFolder + "\\continents.dat", FileMode.Create))
            {
                bformatter.Serialize(stream, this.Continents);
                stream.Close();
            }

            Debug.Write("Saving Countries", 2);
            // Countries
            using (Stream stream = File.Open(this.ConcreteSaveGameFolder + "\\countries.dat", FileMode.Create))
            {
                bformatter.Serialize(stream, this.Countries);
                stream.Close();
            }

            Debug.Write("Saving Regions", 2);
            // Regions
            using (Stream stream = File.Open(this.ConcreteSaveGameFolder + "\\regions.dat", FileMode.Create))
            {
                bformatter.Serialize(stream, this.Regions);
                stream.Close();
            }

            /*
             // Loadtest Region
            this.Regions = null;
            Stream stream2 = File.Open(this.ConcreteSaveGameFolder + "\\regions.dat", FileMode.Open);
            this.Regions = (Dictionary<string, Region>) bformatter.Deserialize(stream2);
            Debug.Write("Regionloader test: " + Regions["AE-FU"].Name);
            Console.ReadLine();
             */

            Debug.Write("Saving Airports", 2);
            using (Stream stream = File.Open(this.ConcreteSaveGameFolder + "\\airports.dat", FileMode.Create))
            {
                bformatter.Serialize(stream, this.Airports);
                stream.Close();
            }
            // Loadtest Airport
            /*this.Airports = null;
            Stream stream2 = File.Open(this.ConcreteSaveGameFolder + "\\airports.dat", FileMode.Open);
            this.Airports = (Dictionary<string, Airport>)bformatter.Deserialize(stream2);
            Debug.Write("Regionloader test: " + this.Airports["FRA"].Size);
            Console.ReadLine();*/
            
            Debug.Write("Saving Manufacturers", 2);
                        using (Stream stream = File.Open(this.ConcreteSaveGameFolder + "\\manufacturers.dat", FileMode.Create))
            {
                bformatter.Serialize(stream, this.Manufacturers);
                stream.Close();
            }
            /*//Loadtest Manufacturers
            this.Manufacturers = null;
            Stream stream2 = File.Open(this.ConcreteSaveGameFolder + "\\manufacturers.dat", FileMode.Open);
            this.Manufacturers = (Dictionary<string, Manufacturer>)bformatter.Deserialize(stream2);
            Debug.Write("Manufacturerloader test: " + this.Manufacturers.Count);
            Console.ReadLine();*/


            Debug.Write("Saving Aircraft", 2);
            using (Stream stream = File.Open(this.ConcreteSaveGameFolder + "\\aircraft.dat", FileMode.Create))
            {
                bformatter.Serialize(stream, this.Aircrafts);
                stream.Close();
            }
            //Loadtest Manufacturers
            this.Aircrafts = null;
            Stream stream2 = File.Open(this.ConcreteSaveGameFolder + "\\aircraft.dat", FileMode.Open);
            this.Aircrafts = (Dictionary<string, Aircraft>)bformatter.Deserialize(stream2);
            Debug.Write("Manufacturerloader test: " + this.Aircrafts.Count);
            Console.ReadLine();


            Debug.Write("Saved!", 1);
        }

    } // end class

    public class SaveGamePublic
    {
        public static SaveGame SaveGame;
        public static Page OuterFrame;
        public static TickHandler TickHandler;
    }

    public class SaveGameException : Exception
    {
        public SaveGameException(string message)
            : base(message)
        {
        }
    } //end Exception


} // end namepsace

