using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace Service
{
    public class StatickaOpremaService
    {
        StatickaOpremaRepozitorijum statickaRepozitorijum = StatickaOpremaRepozitorijum.Instance;
        TerminService terminServis = new TerminService();
        public bool DodajOpremu(StatickaOpremaDTO statickaOpremaDTO, TerminDTO terminDTO, String sati)
        {
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            Dictionary<int, int> ids = datotekaID.dobaviSve();
            int slobodanId = nadjiSlobodanID(ids);
            ids[slobodanId] = 1;


            String s = terminDTO.Pocetak.ToString();
            String date = s.Split(" ")[0];

            TerminDTO termin = new TerminDTO();
            termin.Id = slobodanId;
            termin.prostorija = terminDTO.prostorija;
            termin.Pocetak = terminDTO.Pocetak;


            terminServis.ZakaziTerminDTO(termin, ids);
            StatickaOprema statickaOprema = new StatickaOprema(statickaOpremaDTO);

            StatickaOpremaRepozitorijum.Instance.magacinStatickaOprema.Add(statickaOprema);
            statickaRepozitorijum.Sacuvaj();
            return true;
        }

        private int nadjiSlobodanID(Dictionary<int, int> id_map)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    return id;
                }
            }
            return id;
        }

        public bool ObrisiOpremu(StatickaOprema oprema)
        {
            // TODO: implement
            return false;
        }

        public bool AzurirajOpremu(StatickaOprema oprema)
        {
            // TODO: implement
            return false;
        }

        public ObservableCollection<StatickaOprema> PregledSveOpreme()
        {
            return statickaRepozitorijum.DobaviSve();
        }

        public ObservableCollection<StatickaOpremaDTO> PregledSveOpremeDTO()
        {
            ObservableCollection<StatickaOprema> statickaOprema = statickaRepozitorijum.DobaviSve();
            ObservableCollection<StatickaOpremaDTO> statickaOpremaDTO = new ObservableCollection<StatickaOpremaDTO>();
            foreach (StatickaOprema oprema in statickaOprema)
            {
                statickaOpremaDTO.Add(konvertujEntitetUDTO(oprema));
            }
            return statickaOpremaDTO;

        }

        public StatickaOpremaDTO konvertujEntitetUDTO(StatickaOprema zahtevLek)
        {
            return new StatickaOpremaDTO(zahtevLek);
        }

        public StatickaOprema PregledJedneOpreme()
        {
            // TODO: implement
            return null;
        }


    }
}
