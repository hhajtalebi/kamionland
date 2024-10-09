using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace SlideManagement.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Picture { get; private set; }
        public string Picturefull { get; private set; }
        public string Picturethum { get; private set; }
        public string PictureAlte { get; private set; }
        public string PictureTitel { get; private set; }
        public bool IsDelete { get; private set; }
        public string Titel { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public string Heading { get; private set; }
        public long? CategoryId { get; private set; }
        public string Link { get; private set; }
        public long? CanonicalId { get;private set; }

        public Slide(string picture,string picturefull, string picturethum, string pictureAlte, string pictureTitel,
            string titel, string btnText, string heading, string text, string link, long? categoryId, long? canonicalId)
        {
            Picture = picture;
            Picturefull = picturefull;
            Picturethum = picturethum;
            PictureAlte = pictureAlte;
            PictureTitel = pictureTitel;
            IsDelete = false;
            Titel = titel;
            BtnText = btnText;
            Heading = heading;
            Text = text;
            Link = link;
            CategoryId = categoryId;
            CanonicalId = canonicalId;
        }
        public void Edit(string picture, string picturefull, string picturethum, string pictureAlte, string pictureTitel,
            string titel, string btnText, string heading, string text, string _Link, long? categoryId, long? canonicalId)
        {
            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picturethum = picturethum;
                Picture = picture;
                Picturefull = picturefull;

            }
            PictureAlte = pictureAlte;
            PictureTitel = pictureTitel;
            Titel = titel;
            BtnText = btnText;
            Heading = heading;
            Text = text;
            Link = _Link;
            CategoryId = categoryId;
            CanonicalId = canonicalId;
        }

        public void Delete()
        {
            this.IsDelete = true;
        }

        public void Restore()
        {
            this.IsDelete = false;
        }
    }
}
