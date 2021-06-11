using Model;
using Service;
using System;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.ServiceZaKonverzije;
using ZdravoKorporacija.ServiceSekretarUtility;

namespace ZdravoKorporacija.Controller
{
    class RadniDaniController

    {
        private RadniDanService danServis = new RadniDanService();
        private RadniDaniServiceZaKonverzije danKonverzije = new RadniDaniServiceZaKonverzije();
        private RadniDanSekretarUtility danSekretar = new RadniDanSekretarUtility();
        public RadniDan NadjiDanZaLekara(DateTime dan, double lekar)
        {
            return danServis.NadjiDanZaLekara(dan, lekar);
        }

        public void InicijalizujRadneDane()
        {
            danServis.InicijalizujRadneDane();
        }
        public bool AzurirajRadniDan(RadniDan dan)
        {
            return danServis.AzurirajRadniDan(dan);
        }
        public List<RadniDanDTO> PregledSvihRadnihDana2DTO(List<RadniDan> modeli)
        {
            return danKonverzije.PregledSvihRadnihDana2DTO(modeli);
        }
        public void DodajSlobodneDane(DateTime Od, DateTime Do, double lekar)
        {
            danSekretar.DodajSlobodneDane(Od, Do, lekar);
        }
        public void PromeniSmenu(PromeniSmenuDTO smenaDTO)
        {
            danSekretar.PromeniSmenu(smenaDTO);
        }
        public List<RadniDan> PregledSvihRadnihDana2Model(List<RadniDanDTO> dtos)
        {
            return danKonverzije.PregledSvihRadnihDana2Model(dtos);
        }
        public List<RadniDan> NadjiSveDaneZaLekara(double lekar)
        {
            return danServis.NadjiSveDaneZaLekara(lekar);
        }
        public List<RadniDan> PregledSvihRadnihDana()
        {
            return danServis.PregledSvihRadnihDana();
        }
        public RadniDanDTO Model2DTO(RadniDan model)
        {
            return danKonverzije.Model2DTO(model);
        }
        public RadniDan DTO2Model(RadniDanDTO dto)
        {
            return danKonverzije.DTO2Model(dto);
        }
        public List<RadniDan> PregledOdDo(DateTime Od, DateTime Do, double lekar)
        {
            return danSekretar.PregledOdDo(Od, Do, lekar);
        }
    }
}
