﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace simhukdis.Models
{
    public class clsMonitoring
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("No Surat")]
        public string NoSurat { get; set; }
        public string Perihal { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Disposisi By 1")]
        public string DisposisiBy1 { get; set; }
        [DisplayName("Disposisi By 2")]
        public string DisposisiBy2 { get; set; }
        [DisplayName("Disposisi By 3")]
        public string DisposisiBy3 { get; set; }

        [DisplayName("Disposisi Status 1")]
        public string DisposisiStatus1 { get; set; }
        [DisplayName("Disposisi Status 2")]
        public string DisposisiStatus2 { get; set; }
        [DisplayName("Disposisi Status 3")]
        public string DisposisiStatus3 { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Disposisi Date 1")]
        public string DisposisiDate1 { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Disposisi Date 2")]
        public string DisposisiDate2 { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Disposisi Date 3")]
        public string DisposisiDate3 { get; set; }
        [DisplayName("Tanggal Surat")]
        public string TanggalSurat { get; set; }
        public string Tanggal_Telaah { get; set; }
        public string Tanggal_PraDPK { get; set; }
        public string Tanggal_DPK { get; set; }
    }
    public class clsMonitoringDB
    {
        public List<clsMonitoring> MonitoringList(string UserGroup, string userlogin)
        {
                string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<clsMonitoring> cm = new List<clsMonitoring>();
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    Int32 pNom = 0;
                    string q = "sp_Kasus_Monitoring_Sel";
                    MySqlCommand cmd = new MySqlCommand(q, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("iGroupID", UserGroup);
                    cmd.Parameters.AddWithValue("UserLogin", userlogin);
                    con.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        clsMonitoring data = new clsMonitoring();
                        data.ID = Convert.ToInt32(rd["id"].ToString());
                        data.Status = rd["Status"].ToString();
                        data.NoSurat = rd["nomor_surat"].ToString();
                        data.Perihal = rd["Perihal"].ToString();
                        data.TanggalSurat = rd["tanggal_surat"].ToString();
                        data.Tanggal_Telaah = rd["telaah_date"].ToString();
                        data.Tanggal_DPK = rd["dpk_date"].ToString();
                        data.Tanggal_PraDPK = rd["pradpk_date"].ToString();
                        data.DisposisiBy2 = rd["Disposisi2_By"].ToString();
                        data.DisposisiBy3 = rd["Disposisi3_By"].ToString();

                        data.DisposisiDate1 = rd["Disposisi1_Date"].ToString();
                        data.DisposisiDate2 = rd["Disposisi2_Date"].ToString();
                        data.DisposisiDate3 = rd["Disposisi3_Date"].ToString();

                        data.DisposisiStatus1 = rd["Disposisi1_Status"].ToString();
                        data.DisposisiStatus2 = rd["Disposisi2_Status"].ToString();
                        data.DisposisiStatus3 = rd["Disposisi3_Status"].ToString();
                        cm.Add(data);
                    }
                    return cm;
                }
            }
        }

    }