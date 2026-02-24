using Newtonsoft.Json;
using SocialPhobiaAPP.Models;
using SocialPhobiaAPP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPhobiaAPP.ViewModels
{
    class ChapterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Section> sections { get; set; }

        private Section _currentSection;
        public Section CurrentSection 
        {
            get => _currentSection;
            set
            {
                _currentSection = value;
                OnPropertyChanged(nameof(CurrentSection));
            }
        }
        private string _image;
        public string Image {
            get => _image; set
            {
                               _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private string _title;
        public string Title {
            get=>_title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            } 
        }

        private string _chapterText;
        public string ChapterText 
        { 
            get=>_chapterText;
            set
            {
                _chapterText = value;
                OnPropertyChanged(nameof(ChapterText));
            } 
        }


        private int _index;
        public int Index
        {
            get => _index;
            set
            {
                if (_index == value) return;
                _index = value;
                OnPropertyChanged(nameof(Index));
                UpdateSection();
            }
        }

        private double _progress;
        public double Progress
        {
            get => _progress;
            set             {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public ChapterViewModel()
        {
            sections = new ObservableCollection<Section>();
            _currentSection = new Section("", "", "");
            
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                

        public async void LoadChapterByName(string name)
        {
            int number = int.Parse(string.Concat(name.Where(char.IsDigit)));

            var chapterText = await ChapterTextReader.LoadChapter(number) ?? string.Empty;
            sections = JsonConvert.DeserializeObject<ObservableCollection<Section>>(chapterText)
                       ?? new ObservableCollection<Section>();
            Index = 0; 
            Progress = 0;
            UpdateSection();
        }

        private void UpdateSection()
        {
            
            CurrentSection = sections[Index];
            Image = CurrentSection.Image;
            Title = CurrentSection.Title;
            ChapterText = CurrentSection.ChapterText;
            Progress = (double)(Index + 1) / sections.Count;
        }
    }
}
