using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialPhobiaAPP.Models
{
    class Section
    {
        private string _title;
        private string _chapterText;
        private string _image;

        [JsonPropertyName("Title")]
        public string Title {
            get => _title;
            set { _title = value; } 
        
        }

        [JsonPropertyName("ChapterText")]
        public string ChapterText { 
            get => _chapterText;
            set { _chapterText = value; }
        }

        [JsonPropertyName("Image")]
        public string Image
        {
            get => _image;
            set { _image = value; }
        }

        public Section(string title, string chapterText, string image)
        {
            _title = title;
            _chapterText = chapterText;
            _image = image;
        }
        
    }
}
