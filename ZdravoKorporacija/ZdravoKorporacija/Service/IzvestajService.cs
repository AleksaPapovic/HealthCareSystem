using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Factory;
using ZdravoKorporacija.Repository;
using ZdravoKorporacija.Service;

namespace Service
{
    public class IzvestajService : IIzvestajService
    {
        private static IIzvestajRepozitorijum _izvestajRepozitorijum;
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapIzvestaj");
        public static ObservableCollection<Izvestaj> izvestaji;
        private static IzvestajService _instance;
        

        public static IzvestajService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _izvestajRepozitorijum = IzvestajRepozitorijumFactory.Create();
                    _instance = new IzvestajService();
                    izvestaji = _izvestajRepozitorijum.DobaviSve();
                }
                return _instance;
            }
        }

        public bool DodajIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map)
        {

            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    return false;
                }
            }
            izvestaji.Add(convertToModel(izvestaj));
            //Trace.WriteLine(convertToModel(izvestaj).Id);
            _izvestajRepozitorijum.Sacuvaj(izvestaji);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool ObrisiIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map)
        {
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    izvestaji.Remove(iz);
                    _izvestajRepozitorijum.Sacuvaj(izvestaji);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajIzvestaj(IzvestajDTO izvestaj)
        {
            ObservableCollection<Izvestaj> izvestaji = _izvestajRepozitorijum.DobaviSve();
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    izvestaji.Remove(iz);
                    izvestaji.Add(convertToModel(izvestaj));
                    _izvestajRepozitorijum.Sacuvaj(izvestaji);
                    return true;
                }
            }
            return false;
        }

        public IzvestajDTO PregledIzvestaj(string id)
        {
            ObservableCollection<Izvestaj> izvestaji = _izvestajRepozitorijum.DobaviSve();
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(id))
                {
                    return new IzvestajDTO(iz);
                }
            }
            return null;
        }

        public ObservableCollection<IzvestajDTO> PregledSvihIzvestaja()
        {
            ObservableCollection<Izvestaj> izvestaji = _izvestajRepozitorijum.DobaviSve();
            ObservableCollection<IzvestajDTO> izvestajDTOs = new ObservableCollection<IzvestajDTO>();
            foreach (Izvestaj i in izvestaji)
            {
                izvestajDTOs.Add(convertToDTO(i));
            }
            return izvestajDTOs;
        }

        public Izvestaj convertToModel(IzvestajDTO izvestaj)
        {
            return new Izvestaj(izvestaj);
        }

        public IzvestajDTO convertToDTO(Izvestaj izvestaj)
        {
            return new IzvestajDTO(izvestaj);
        }

    }
}