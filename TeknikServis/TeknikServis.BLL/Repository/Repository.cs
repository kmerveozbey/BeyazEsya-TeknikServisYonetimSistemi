using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.DAL;
using TeknikServis.Entity.Entities;

namespace TeknikServis.BLL.Repository
{
    public class ArizaKayitRepo : RepositoryBase<ArizaKayit, int> { }
    public class DosyaRepo : RepositoryBase<Dosya, int> { }
    public class TeknisyenRepo : RepositoryBase<Teknisyen, int> { }
    public class MesajRepo : RepositoryBase<Message, int>
    {

        public MesajRepo()
        {
            try
            {
                MyContext db = new MyContext();
                db.Mesajlar.Add(new Message()
                {
                    SendBy = "46f0cc49-62d0-4ffc-9a96-af5f9a5da0ae",
                    SentTo = "46f0cc49-62d0-4ffc-9a96-af5f9a5da0ae"
                });
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    public class ArizaDurumDetayRepo : RepositoryBase<ArizaDurumDetay, int> { }
    public class AnketRepo : RepositoryBase<Anket, int> { }
    public class AnketSoruRepo : RepositoryBase<AnketSoru, int> { }




}
