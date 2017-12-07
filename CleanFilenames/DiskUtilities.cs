using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanFilenames
{
	public static class DiskUtilities
	{
		public static List<string> GetDirectories(string directoryPath)
		{
			List<string> directories;
			List<string> additionaDirectories = new List<string>();
			string[] files;

			// Get initial list of directories
			directories = Directory.GetDirectories(directoryPath).ToList();
			directories.Sort();
			
			// Loop over directories and change their names
			foreach (var directory in directories)
			{
				RenameDirectory(directory);
			}

			// After changing names reload fresh directory list
			directories = Directory.GetDirectories(directoryPath).ToList();
			
			// Go one level deeper (recurrency)
			foreach (var directory in directories)
			{
				additionaDirectories.AddRange(GetDirectories(directory));
			}

			directories.AddRange(additionaDirectories);


			// Get files in direcotries
			files = GetFiles(directoryPath);

			
			// Change names of files
			foreach (var file in files)
			{
				RenameFile(file);
			}
			

			return directories;
		}


		public static string[] GetFiles(string directoryPath)
		{
			return Directory.GetFiles(directoryPath);
		}


		public static string GetFileName(string filename)
		{
			return Path.GetFileNameWithoutExtension(filename);
		}


		public static string GetFileExtension(string filename)
		{
			return Path.GetExtension(filename).ToLower();
		}

		public static string GetFullPath(string filename)
		{
			return Path.GetFullPath(filename);
		}


		public static string RenameDirectory(string directory)
		{
			var cleanedDirectory = CleanFilename(directory);
			cleanedDirectory = TextUtilities.AddBracesToYear(cleanedDirectory);

			if (directory != cleanedDirectory)			
			{
				Directory.Move(directory, cleanedDirectory);
			}

			return cleanedDirectory;
		}


		public static string RenameFile(string file)
		{
			var path = Path.GetDirectoryName(file);
			var filename = GetFileName(file);
			var extension = GetFileExtension(file);
			var cleanedFilename = CleanFilename(filename);
			cleanedFilename = TextUtilities.AddBracesToYear(cleanedFilename);

			if (filename != cleanedFilename)
			{
				File.Move(file, path + "\\" + cleanedFilename + extension);
			}
			
			return CleanFilename(file);
		}


		


		public static string CleanFilename(string filename)
		{
			string cleanFilename = filename
				.Replace("– ALLTUBE filmy i seriale online", "")
				.Replace("+HI", "")
				.Replace("1080p", "")
				.Replace("5.1", "")
				.Replace("5.1CH", "")
				.Replace("6CH", "")
				.Replace("720p", "")
				.Replace("700mb", "")
				.Replace("AAC", "")
				.Replace("aAF", "")
				.Replace("AC3", "")
				.Replace("AR", "")
				.Replace("aXXo", "")
				.Replace("anoXmous", "")
				.Replace("Bayfilms", "")
				.Replace("BDRip", "")
				.Replace("BluRay", "")
				.Replace("Bluray", "")
				.Replace("bluray", "")
				.Replace("Blu ray", "")
				.Replace("BrRip", "")
				.Replace("BRRip", "")
				.Replace("BRrip", "")
				.Replace("BugZ", "")
				.Replace("DD5.1", "")
				.Replace("DDX", "")
				.Replace("DD", "")
				.Replace("DexzAery & VectoR", "")
				.Replace("DivX", "")
				.Replace("divx", "")
				.Replace("DoNE", "")
				.Replace("DTS-JYK", "")
				.Replace("DUBPL", "")
				.Replace("DvDRip", "")
				.Replace("DvDrip", "")
				.Replace("DVDRip", "")
				.Replace("DVDRiP", "")
				.Replace("DVDRIP", "")
				.Replace("DVDrip", "")
				.Replace("dvdrip", "")
				.Replace("DvdRip", "")
				.Replace("DVDSCR", "")
				.Replace("Ehhhh", "")
				.Replace("Ekolb", "")
				.Replace("ETRG", "")
				.Replace("EVO", "")
				.Replace("FXG", "")
				.Replace("Ganool", "")
				.Replace("GAZ", "")
				.Replace("GECKOS", "")
				.Replace("geckos", "")
				.Replace("GeneGeter.com", "")
				.Replace("greenbud1969", "")
				.Replace("H264", "")
				.Replace("H 264", "")
				.Replace("HC", "")
				.Replace("HD4U", "")
				.Replace("hd4u", "")
				.Replace("HDCLUB", "")
				.Replace("HDTV", "")
				.Replace("HDTVRiP", "")
				.Replace("HDRip", "")
				.Replace("HEVC", "")
				.Replace("HighCode", "")
				.Replace("HLS", "")
				.Replace("HQHDTS", "")
				.Replace("iGNiTE", "")
				.Replace("iNTERNAL", "")
				.Replace("JTS", "")
				.Replace("JYK", "")
				.Replace("KiNGDOM", "")
				.Replace("KiT", "")
				.Replace("KLAXXON", "")
				.Replace("KORSUB", "")
				.Replace("Lektor PL", "")
				.Replace("LIMITED", "")
				.Replace("LiMiTED", "")
				.Replace("MkvCage", "")
				.Replace("Multi - Subs", "")
				.Replace("MVGroup.org", "")
				.Replace("NC-17", "")
				.Replace("pimprg", "")
				.Replace("PolishQuality[PRiME]", "")
				.Replace("PROPER", "")
				.Replace("PublicHD", "")
				.Replace("RARBG", "")
				.Replace("rarbg", "")
				.Replace("ReEnc-Max", "")
				.Replace("RiP", "")
				.Replace("ROVERS", "")
				.Replace("ShAaNiG", "")
				.Replace("SER", "")
				.Replace("SMP", "")
				.Replace("Sohu", "")
				.Replace("STiK", "")
				.Replace("sujaidr", "")
				.Replace("SUJAIDR", "")
				.Replace("SUUSW", "")
				.Replace("WEB - DL", "")
				.Replace("WEB-DL", "")
				.Replace("WEBRip", "")
				.Replace("vice", "")
				.Replace("VLiS", "")
				.Replace("VoMiT", "")
				.Replace("VPPV", "")
				.Replace("wideo w cda.pl", "")
				.Replace("YIFY", "")
				.Replace("YTS.AG", "")
				.Replace("YTS AG", "")
				.Replace("x264", "")
				.Replace("X264", "")
				.Replace("x265", "")
				.Replace("XviD", "")
				.Replace("XViD", "")
				.Replace("Xvid", "")
				.Replace("XVID", "")
				.Replace("xvid", "")
				.Replace("XVid", "")
				.Replace("Zeus Dias", "")

				.Replace(".", " ")
				.Replace("-", " ")
				.Replace("_", " ")
				.Replace("[", " ")
				.Replace("]", " ")
				.Replace("{", " ")
				.Replace("}", " ")

				.Replace("  ", " ")
				.Replace("  ", " ")
				.Trim()
				;

			

			return cleanFilename;
		}

	}
}
