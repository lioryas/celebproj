namespace CelebsWebApi.Models
{
    public class Celeb
    {
        protected string fullName = string.Empty;
        protected string birthDate = string.Empty;
        protected string gender = "Male\\Female";
        protected string title = string.Empty;
        protected string picture = string.Empty;

       

        public Celeb(string fullName, string birthDate, string title, string picture)
        {
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.title = title;
            this.picture = picture;
            // Try to define a person's gender by his title
            if (Constants.ACTOR.Equals(title) || Constants.WRITER.Equals(title))
            {
                this.gender = Constants.MALE;
            }
            else if (Constants.ACTRESS.Equals(title))
            {
                this.gender = Constants.FEMALE;
            }

            //default --> Male/Female


        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public override string ToString()
        {
            return $@"fullName: {fullName}, birthDate: {birthDate}, title: {title}, gender: {gender}";
        }
    }
}