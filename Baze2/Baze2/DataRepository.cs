using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2
{
    public class DataRepository
    {
        private static DataRepository instance = null;

        private Model1Container _data = null;

        private DataRepository()
        {
            _data = new Model1Container();
        }
        

        public static DataRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataRepository();
                }
                return instance;
            }
        }

        #region AERODROM
        public List<Aerodrom> GetAerodome()
        {
            return _data.Aerodromi.ToList();
        }

        public void AddAerodrom(Aerodrom a)
        {
            if(a != null)
            {
                _data.Aerodromi.Add(a);
                _data.SaveChanges();
            }
            
        }

        public Aerodrom GetAerodrom(int id)
        {
            foreach (Aerodrom item in _data.Aerodromi.ToList())
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public bool ModifyAerodrom(Aerodrom a)
        {
            bool retVal = true;
            var find = _data.Aerodromi.Where(item => item.Id == a.Id).SingleOrDefault();
            if (find != null)
            {
                if(a.Naziv != string.Empty)
                    find.Naziv = a.Naziv;
                if(a.Adresa != string.Empty)
                    find.Adresa = a.Adresa;
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        public bool DeleteAerodrom(int id)
        {
            bool retVal = true;
            var find = _data.Aerodromi.Where(item => item.Id == id).SingleOrDefault();
            if (find != null)
            {
                foreach (var item in GetOsobljes().ToList())
                {
                    if (item.AerodromId == id)
                        DeleteOsoblje(item.Id);
                }
                foreach (var item in GetAvioni().ToList())
                {
                    if (item.AerodromId == id)
                        DeleteAvion(item.Id);
                }

                _data.Aerodromi.Remove(find);
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        #endregion

        #region AVION
        public List<Avion> GetAvioni()
        {
            return _data.Avioni.ToList();
        }

        public void AddAvion(Avion a)
        {
            if (a != null)
            {
                _data.Avioni.Add(a);
                _data.SaveChanges();
            }
        }

        public Avion GetAvion(int id)
        {
            foreach (Avion item in _data.Avioni.ToList())
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public bool ModifyAvion(Avion a)
        {
            bool retVal = true;
            var find = _data.Avioni.Where(item => item.Id == a.Id).SingleOrDefault();
            if (find != null)
            {
                if(a.Naziv != string.Empty)
                    find.Naziv = a.Naziv;
                if(a.BrojMesta != string.Empty)
                    find.BrojMesta = a.BrojMesta;
                if (a.AerodromId != 0)
                    find.AerodromId = a.AerodromId;
                if (a.CentralaId != 0)
                    find.CentralaId = a.CentralaId;
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        public bool DeleteAvion(int id)
        {
            bool retVal = true;
            var find = _data.Avioni.Where(item => item.Id == id).SingleOrDefault();
            if (find != null)
            {
                _data.Avioni.Remove(find);
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }
        #endregion

        #region CENTRALA

        public void AddCentrala(Centrala c)
        {
            if (c != null)
            {
                _data.Centrale.Add(c);
                _data.SaveChanges();
            }
        }

        public List<Centrala> GetCentrale()
        {
            return _data.Centrale.ToList();
        }

        public Centrala GetCentrala(int id)
        {
            foreach (Centrala item in _data.Centrale.ToList())
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public bool ModifyCentrala(Centrala c)
        {
            bool retVal = true;
            var find = _data.Centrale.Where(item => item.Id == c.Id).SingleOrDefault();
            if (find != null)
            {
                find.Naziv = c.Naziv;
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        public bool DeleteCentrala(int id)
        {
            bool retVal = true;
            var find = _data.Centrale.Where(item => item.Id == id).SingleOrDefault();
            if (find != null)
            {
                foreach (var item in GetOsobljes().ToList())
                {
                    if(item is Op_Letova)
                    {
                        Op_Letova op = (Op_Letova)item;
                        if (op.CentralaId == id)
                            DeleteOsoblje(item.Id);
                    }
                }
                foreach (var item in GetAvioni().ToList())
                {
                    if (item.CentralaId == id)
                        DeleteAvion(item.Id);
                }


                _data.Centrale.Remove(find);
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        #endregion

        #region KOMPANIJA

        public void AddKompanija(Kompanija k)
        {
            if (k != null)
            {
                _data.Kompanije.Add(k);
                _data.SaveChanges();
            }
        }

        public List<Kompanija> GetKompanije()
        {
            return _data.Kompanije.ToList();
        }

        public Kompanija GetKompanija(int id)
        {
            foreach (Kompanija item in _data.Kompanije.ToList())
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public bool ModifyKompanija(Kompanija k)
        {
            bool retVal = true;
            var find = _data.Kompanije.Where(item => item.Id == k.Id).SingleOrDefault();
            if (find != null)
            {
                find.Naziv = k.Naziv;
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        public bool DeleteKompanija(int id)
        {
            bool retVal = true;
            var find = _data.Kompanije.Where(item => item.Id == id).SingleOrDefault();
            if (find != null)
            {
                _data.Kompanije.Remove(find);
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        #endregion

        #region LET

        public void AddLet(Let l)
        {
            if (l != null)
            {
                _data.Letovi.Add(l);
                _data.SaveChanges();
            }
        }

        public List<Let> GetLetovi()
        {
            return _data.Letovi.ToList();
        }

        public Let GetLet(int id)
        {
            foreach (Let item in _data.Letovi.ToList())
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public bool ModifyLet(Let l)
        {
            bool retVal = true;
            var find = _data.Letovi.Where(item => item.Id == l.Id).SingleOrDefault();
            if (find != null)
            {
                if (l.CentralaId != 0)
                    find.CentralaId = l.CentralaId;
                if (l.Datum != string.Empty)
                    find.Datum = l.Datum;
                if (l.Vreme != string.Empty)
                    find.Vreme = l.Vreme;
                if (l.MestoPolaska != string.Empty)
                    find.MestoPolaska = l.MestoPolaska;
                if (l.Destinacija != string.Empty)
                    find.Destinacija = l.Destinacija;

                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        public bool DeleteLet(int id)
        {
            bool retVal = true;
            var find = _data.Letovi.Where(item => item.Id == id).SingleOrDefault();
            if (find != null)
            {
                _data.Letovi.Remove(find);
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        #endregion

        #region OSOBLJE

        public void AddOsoblje(Osoblje c)
        {
            if (c != null)
            {
                _data.Osobljes.Add(c);
                _data.SaveChanges();
            }
        }

        public List<Osoblje> GetOsobljes()
        {
            return _data.Osobljes.ToList();
        }

        public Osoblje GetOsoblje(int id)
        {
            foreach (Osoblje item in _data.Osobljes.ToList())
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public bool ModifyOsoblje(Osoblje osoblje)
        {
            bool retVal = true;
            var find = _data.Osobljes.Where(item => item.Id == osoblje.Id).SingleOrDefault();
            if (find != null)
            {
                if (osoblje.AerodromId != 0)
                    find.AerodromId = osoblje.AerodromId;
                if (osoblje.Ime != string.Empty)
                    find.Ime = osoblje.Ime;
                if (osoblje.Prezime != string.Empty)
                    find.Prezime = osoblje.Prezime;

                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        public bool DeleteOsoblje(int id)
        {
            bool retVal = true;
            var find = _data.Osobljes.Where(item => item.Id == id).SingleOrDefault();
            if (find != null)
            {
                _data.Osobljes.Remove(find);
                _data.SaveChanges();
            }
            else
                retVal = false;

            return retVal;
        }

        #endregion



    }
}
