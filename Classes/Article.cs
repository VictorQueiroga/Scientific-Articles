
using System;
namespace ScientificArticles
{
    public class Article : Entity
    {
        private Subject subject { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private string Magazine { get; set; }
        private int Year { get; set; }

        private bool Delete { get; set; }

        public Article(int Id, Subject subject, string Title, string Description, string Magazine, int Year) {
            this.Id = Id;
            this.subject = subject;
            this.Title = Title;
            this.Description = Description;
            this.Magazine = Magazine;
            this.Year = Year;
            this.Delete = false;
        }

        public override string ToString()
        {
            string Output = "";
            Output += "Subject: " + this.subject + Environment.NewLine;
            Output += "Title: " + this.Title + Environment.NewLine;
            Output += "Description: " + this.Description + Environment.NewLine;
            Output += "Magazine: " + this.Magazine + Environment.NewLine;
            Output += "Year: " + this.Year + Environment.NewLine;
            Output += "Deleted: " + this.Delete;
            return Output;
        }

        public string ReturnTitle() {
            return this.Title;
        }

        public int ReturnId() {
            return this.Id;
        }

        public bool ReturnDeleted()
        {
            return this.Delete;
        }

        public void Deleted() {
            this.Delete = true;
        }
    }
}
