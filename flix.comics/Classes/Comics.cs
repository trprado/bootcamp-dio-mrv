using System;
using flix.comics.Enums;
using flix.comics.BaseEntity;

namespace Classes
{
    public class Comics : BaseEntity
    {
        public string Name { get; protected set; }
        public short Year { get; protected set; }
        public Genre Genre { get; protected set; }
        public string Description { get; protected set; }
        public Status PublishStatus { get; protected set; }
        public bool Excluded { get; protected set; }

        public Comics(string Name, short Year, Genre Genre, Status PublishStatus, string Description)
        {
            this.Name = Name;
            this.Year = Year;
            this.Genre = Genre;
            this.Description = Description;
            this.PublishStatus = PublishStatus;
            this.Excluded = false;
        }
        public void Exclude()
        {
            this.Excluded = true;
        }

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public override string ToString()
        {
            if (this.Excluded)
            {
                return "Comics Excluded!";
            }
            string comics_data = "";
            comics_data += $"Name: {this.Name} \n";
            comics_data += $"ID: {this.Id} \n";
            comics_data += $"Year: {this.Year} \n";
            comics_data += $"Description {this.Description} \n";
            comics_data += $"Publish Status: {PublishStatus.ToString()} \n";
            return comics_data;
        }
    }
}
