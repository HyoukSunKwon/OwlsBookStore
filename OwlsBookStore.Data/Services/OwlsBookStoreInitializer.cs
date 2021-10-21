using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public class OwlsBookStoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OwlsBookStoreDbContext>
    {
        protected override void Seed(OwlsBookStoreDbContext context)
        {        
            var writers = new List<Writer>
            {
                new Writer{ Name="Rick Riordan", BirthDate=DateTime.Parse("2000-09-01"), Portrayal="ddddd", UrlWriter="https://images.gr-assets.com/authors/1608906571p5/15872.jpg" },
                new Writer{ Name="Sarah J. Maas", BirthDate=DateTime.Parse("2000-09-01"), Portrayal="ddddd", UrlWriter="https://images.gr-assets.com/authors/1582137198p8/3433047.jpg" },
                new Writer{ Name="Stephenie Meyer", BirthDate=DateTime.Parse("2000-09-01"), Portrayal="ddddd", UrlWriter="https://api.time.com/wp-content/uploads/2016/07/stephenie-meyer.jpeg?w=800&quality=85" }
            };

            writers.ForEach(w => context.Writers.Add(w));
            context.SaveChanges();

            context.Genres.Add(new Genre { Name = "Fantasy" });
            context.Genres.Add(new Genre { Name = "Fiction" });
            context.Genres.Add(new Genre { Name = "Advanture" });
            context.SaveChanges();

            var Rick = context.Writers.SingleOrDefault(w => w.Name == "Rick Riordan");
            var Sarah = context.Writers.SingleOrDefault(w => w.Name == "Sarah J. Maas");
            var Stephenie = context.Writers.SingleOrDefault(w => w.Name == "Stephenie Meyer");

            var bookSerieses = new List<BookSeries>
            {
               new BookSeries{Id=1, Name="Percy Jackson", Writer=Rick, Genre= "Fantasy", Publisher="Desney Publishing Worldwide", UrlBookSeries="https://www.amazon.ca/images/I/51BfYSYSfxL._SX336_BO1,204,203,200_.jpg", Depiction="Percy Jackson & the Olympians, often shortened to Percy Jackson, PJO, or PJatO is a pentalogy of fantasy adventure novels written by American author Rick Riordan, and the first book series in the Camp Half-Blood Chronicles."},
               new BookSeries{Id=2, Name="Thron of Glass", Writer=Sarah, Genre= "Fiction", Publisher="Bloomsbury Publishing", UrlBookSeries="https://sarahjmaas.com/wp-content/uploads/2015/06/TOG-NYT-Cover.jpg", Depiction="Throne of Glass is a young adult high fantasy novel series by American author Sarah J. Maas, beginning with Throne of Glass, released in August 2012. The story follows the journey of Celaena Sardothien, a teenage assassin in a corrupt kingdom with a tyrannical ruler, The King of Adarlan."},
               new BookSeries{Id=3, Name="The twilight Saga", Writer=Stephenie, Genre="Fiction", Publisher="Little, Brown and Company", UrlBookSeries="https://www.syfy.com/sites/syfy/files/styles/1200x680/public/2018/12/the-complete-twilight-saga-movie-poster.jpg", Depiction="The Twilight Saga is a series of four vampire-themed fantasy romance novels, two companion novels, and one novella, written by American author Stephenie Meyer."}
            };
            bookSerieses.ForEach(bs => context.BookSerieses.Add(bs));
            context.SaveChanges();


            var percy = context.BookSerieses.SingleOrDefault(b => b.Name == "Percy Jackson");
            var thron = context.BookSerieses.SingleOrDefault(b => b.Name == "Thron of Glass");
            var twilight = context.BookSerieses.SingleOrDefault(b => b.Name == "The twilight Saga");

            var books = new List<Book>
            {
                new Book{ Name="The lightning thief", ReleaseDate=DateTime.Parse("2005-01-01"), BookSerieses=percy, UrlBook="https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1400602609i/28187.jpg"},
                new Book{ Name="The sea of monster", ReleaseDate=DateTime.Parse("2006-01-01"), BookSerieses=percy, UrlBook="https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1400602661i/28186.jpg"},
                new Book{ Name="The titan's curse", ReleaseDate=DateTime.Parse("2007-01-01"), BookSerieses=percy, UrlBook="https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1361038385i/561456.jpg"},
                new Book{ Name="Assassin's blade", ReleaseDate=DateTime.Parse("2005-01-01"), BookSerieses=thron, UrlBook="https://sarahjmaas.com/wp-content/uploads/2015/06/AB-NYT-Cover.jpg"},
                new Book{ Name="Thron of glass", ReleaseDate=DateTime.Parse("2005-01-01"), BookSerieses=thron, UrlBook="https://sarahjmaas.com/wp-content/uploads/2015/06/TOG-NYT-Cover.jpg"},
                new Book{ Name="Crown of midnight", ReleaseDate=DateTime.Parse("2005-01-01"), BookSerieses=thron, UrlBook="https://sarahjmaas.com/wp-content/uploads/2015/06/COM-NYT-Cover.jpg"},
                new Book{ Name="Twilight", ReleaseDate=DateTime.Parse("2005-10-05"), BookSerieses=twilight, UrlBook="https://stepheniemeyer.com/wp-content/uploads/2016/02/twilight-book-cover.jpg"}
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}
