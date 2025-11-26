using SocialPhobiaAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace SocialPhobiaAPP.Services
{
    class ChapterTextReader
    {
        // Accept a chapter number 
        // Read from the corresponding text file
        // Save text to a collection and return it

        public async static Task<String> LoadChapter(int chapterNumber)
        {
            
            string jsonString = await readTextFromFile(chapterNumber);
;
            return jsonString;
        }

        public async static Task<string> readTextFromFile(int chapterNumber)
        {
            string fileName = $"chapter{chapterNumber}.json";
            string jsonString = string.Empty;
            try
            {
                using Stream stream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
                using StreamReader reader = new StreamReader(stream);
                jsonString = await reader.ReadToEndAsync();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"The chapter file '{fileName}' was not found in the app package.");
            }
            return jsonString;
        }
    }
}
