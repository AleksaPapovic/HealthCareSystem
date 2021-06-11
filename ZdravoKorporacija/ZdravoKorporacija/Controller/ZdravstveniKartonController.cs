using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class ZdravstveniKartonController
    {
        ZdravstveniKartonServis zkServis = ZdravstveniKartonServis.Instance;

        private static ZdravstveniKartonController _instance;

        public static ZdravstveniKartonController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ZdravstveniKartonController();
                }
                return _instance;
            }
        }

        public bool KreirajZdravstveniKarton(ZdravstveniKarton ZdravstveniKarton, Dictionary<int, int> id_map)
        {
            return zkServis.KreirajZdravstveniKarton(ZdravstveniKarton, id_map);
        }

        public bool KreirajZdravstveniKarton(ZdravstveniKartonDTO ZdravstveniKarton, Dictionary<int, int> id_map)
        {
            return zkServis.KreirajZdravstveniKarton(ZdravstveniKarton, id_map);
        }

        public bool KreirajZdravstveniKarton2(ZdravstveniKartonDTO ZdravstveniKarton)
        {
            return zkServis.KreirajZdravstveniKarton2(ZdravstveniKarton);
        }

        public bool KreirajZdravstveniKartonJMBG(ZdravstveniKarton ZdravstveniKarton)
        {
            return zkServis.KreirajZdravstveniKartonJMBG(ZdravstveniKarton);
        }

        public bool ObrisiZdravstveniKarton(ZdravstveniKarton zdravstveniKarton, Dictionary<int, int> id_map)
        {
            return zkServis.ObrisiZdravstveniKarton(zdravstveniKarton, id_map);
        }


        public ZdravstveniKarton findById(long id)
        {
            return zkServis.findById(id);
        }


        public void DodajAlergen(ZdravstveniKartonDTO k1DTO, ZdravstveniKartonDTO k2DTO, string alergija, Pacijent pacijent)
        {
            zkServis.DodajAlergen(k1DTO, k2DTO, alergija, pacijent);
        }
        public bool AzurirajZdravstveniKarton(ZdravstveniKarton zdravstveniKarton)

        {
            return zkServis.AzurirajZdravstveniKarton(zdravstveniKarton);
        }

        public ZdravstveniKarton PregledZdravstvenogKartona(long id)
        {
            return zkServis.PregledZdravstvenogKartona(id);
        }

        public List<ZdravstveniKarton> PregledSvihZdravstvenihKartona()
        {
            return zkServis.PregledSvihZdravstvenihKartona();
        }
    }
}
